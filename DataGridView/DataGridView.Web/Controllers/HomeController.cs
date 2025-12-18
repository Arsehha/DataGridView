using System.Diagnostics;
using DataGridView.Entities;
using DataGridView.Services.Contracts;
using DataGridView.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataGridView.Web.Controllers
{
    /// <summary>
    /// Контроллер для управления отбором аббитуриантов
    /// </summary>
    public class HomeController(IApplicantService applicant) : Controller
    {
        private IApplicantService Service { get; set; } = applicant;

        /// <summary>
        /// Отображает главную страницу со списком всех аббитуриентов и статистикой
        /// </summary>
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var applicants = await Service.GetAll(cancellationToken);
            var countStatistics = await Service.GetCountStudents(cancellationToken);
            var countByMinStatistics = await Service.GetStudentsByMinScore(ServiceConstants.MinTotalScore, cancellationToken);

            var viewModel = new IndexViewModel
            {
                Applicants = applicants,
                CountStatistics = countStatistics,
                CountByMinStatistics = countByMinStatistics
            };

            return View(viewModel);
        }

        /// <summary>
        /// Отображает форму для создания нового аббитуриента
        /// </summary>

        [HttpGet]
        public IActionResult Create()
        {
            return View(new ApplicantEditViewModel());
        }

        /// <summary>
        /// Обрабатывает отправку формы создания нового аббитуриента
        /// </summary>

        [HttpPost]
        public async Task<IActionResult> Create(ApplicantEditViewModel applicantEditViewModel, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(applicantEditViewModel);
            }

            var applicant = new ApplicantModel
            {
                Id = Guid.NewGuid(),
                FullName = applicantEditViewModel.FullName,
                Sex = applicantEditViewModel.Sex,
                DateOfBirth = DateTime.SpecifyKind(applicantEditViewModel.DateOfBirth, DateTimeKind.Utc),
                EducationForm = applicantEditViewModel.EducationForm,
                MathScore = applicantEditViewModel.MathScore,
                RussianScore = applicantEditViewModel.RussianScore,
                InformaticsScore = applicantEditViewModel.InformaticsScore
            };

            await Service.Add(applicant, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Отображает форму для редактирования существующего аббитуриента по его идентификатору
        /// </summary>

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id, CancellationToken cancellationToken)
        {
            var applicants = await Service.GetAll(cancellationToken);
            var applicant = applicants.FirstOrDefault(p => p.Id == id);

            if (applicant == null)
            {
                return NotFound();
            }

            var applicantEditViewModel = new ApplicantEditViewModel
            {
                Id = applicant.Id,
                FullName = applicant.FullName,
                Sex = applicant.Sex,
                DateOfBirth = applicant.DateOfBirth,
                EducationForm = applicant.EducationForm,
                MathScore = applicant.MathScore,
                RussianScore = applicant.RussianScore,
                InformaticsScore = applicant.InformaticsScore
            };

            return View(applicantEditViewModel);
        }

        /// <summary>
        /// Обрабатывает отправку формы редактирования аббитуриента
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Edit(ApplicantEditViewModel applicantEditViewModel, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(applicantEditViewModel);
            }

            var applicants = await Service.GetAll(cancellationToken);
            var applicant = applicants.FirstOrDefault(p => p.Id == applicantEditViewModel.Id);

            if (applicant == null)
            {
                return NotFound();
            }

            applicant.Id = applicantEditViewModel.Id;
            applicant.FullName = applicantEditViewModel.FullName;
            applicant.Sex = applicantEditViewModel.Sex;
            applicant.DateOfBirth = DateTime.SpecifyKind(applicantEditViewModel.DateOfBirth, DateTimeKind.Utc);
            applicant.EducationForm = applicantEditViewModel.EducationForm;
            applicant.MathScore = applicantEditViewModel.MathScore;
            applicant.RussianScore = applicantEditViewModel.RussianScore;
            applicant.InformaticsScore = applicantEditViewModel.InformaticsScore;

            await Service.Update(applicant, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Отображает страницу подтверждения удаления аббитуриента
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var applicants = await Service.GetAll(cancellationToken);
            var applicant = applicants.FirstOrDefault(p => p.Id == id);

            if (applicant == null)
            {
                return NotFound();
            }

            return View(applicant);
        }

        /// <summary>
        /// Выполняет удаление аббитуриента после подтверждения
        /// </summary>
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, CancellationToken cancellationToken)
        {
            var applicants = await Service.GetAll(cancellationToken);
            var applicant = applicants.FirstOrDefault(p => p.Id == id);

            if (applicant == null)
            {
                return NotFound();
            }

            await Service.Remove(applicant.Id, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Отображает страницу "Политика конфиденциальности".
        /// </summary>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Отображает страницу ошибки с информацией о текущем запросе.
        /// </summary>
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
            });

        }
    }
}
