using DataGridView.Context;
using DataGridView.Entities;
using DataGridView.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataGridView.Repository
{
    /// <summary>
    /// Хранилище абитуриентов в БД
    /// </summary>
    public class DbRepository : IStorage
    {
        /// <summary>
        /// Добавление абитуриентов
        /// </summary>
        public async Task Add(ApplicantModel applicant, CancellationToken cancellationToken)
        {
            using var context = new ApplicantContext();
            context.Add(applicant);
            await context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Получение списка абитуриентов
        /// </summary>
        public async Task<List<ApplicantModel>> GetAll(CancellationToken cancellationToken)
        {
            using var context = new ApplicantContext();
            return await context.Applicants.ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Получение абитуриента из базы
        /// </summary>
        public async Task<ApplicantModel?> GetById(Guid id, CancellationToken cancellationToken)
        {
            using var context = new ApplicantContext();
            return await context.Applicants.FindAsync(id);
        }

        /// <summary>
        /// Подсчёт абитуриентов
        /// </summary>
        public async Task<int> GetCount(CancellationToken cancellationToken)
        {
            using var context = new ApplicantContext();
            return await context.Applicants.CountAsync(cancellationToken);
        }

        /// <summary>
        /// Удаление абитуриента
        /// </summary>
        public async Task Remove(ApplicantModel applicant, CancellationToken cancellationToken)
        {
            using var context = new ApplicantContext();
            context.Remove(applicant);
            await context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Редактирование абитуриента
        /// </summary>
        public async Task Update(ApplicantModel applicant, CancellationToken cancellationToken)
        {
            using var context = new ApplicantContext();
            context.Update(applicant);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
