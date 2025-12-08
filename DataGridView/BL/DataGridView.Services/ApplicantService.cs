using DataGridView.Entities;
using DataGridView.Repository.Contracts;
using DataGridView.Services.Contracts;

namespace DataGridView.Services;

/// <summary>
/// Сервис по работе со студентами
/// </summary>
public class ApplicantService : IApplicantService
{
    private readonly IStorage storage;

    /// <summary>
    /// Инициализировать новый экземпляр
    /// </summary>
    public ApplicantService(IStorage storage)
    {
        this.storage = storage;
    }

    /// <summary>
    /// Добавление студента
    /// </summary>
    public async Task Add(ApplicantModel student, CancellationToken cancellationToken)
    {
        await storage.Add(student, cancellationToken);
    }

    /// <summary>
    /// Удаление студента
    /// </summary>
    public async Task Remove(Guid id, CancellationToken cancellationToken)
    {
        var std = await storage.GetById(id, cancellationToken);
        await storage.Remove(std, cancellationToken);
    }

    /// <summary>
    /// Редактирование студента
    /// </summary>
    public async Task Update(ApplicantModel student, CancellationToken cancellationToken)
    {
        var std = await storage.GetById(student.Id, cancellationToken);

        std.DateOfBirth = student.DateOfBirth;
        std.Sex = student.Sex;
        std.EducationForm = student.EducationForm;
        std.FullName = student.FullName;
        std.InformaticsScore = student.InformaticsScore;
        std.RussianScore = student.RussianScore;
        std.MathScore = student.MathScore;

        await storage.Update(std, cancellationToken);
    }

    /// <summary>
    /// Получение списка студентов
    /// </summary>
    public async Task<ICollection<ApplicantModel>> GetAll(CancellationToken cancellationToken)
    {
        return await storage.GetAll(cancellationToken);
    }

    /// <summary>
    /// Подсчёт студентов с минимальным порогом
    /// </summary>
    public async Task<int> GetStudentsByMinScore(int count, CancellationToken cancellationToken)
    {
        var stds = await storage.GetAll(cancellationToken);
        return stds.Count(x => x.InformaticsScore + x.MathScore + x.RussianScore > count);
    }

    /// <summary>
    /// Подсчёт количества студентов
    /// </summary>
    public async Task<int> GetCountStudents(CancellationToken cancellationToken)
    {
        return await storage.GetCount(cancellationToken);
    }

}
