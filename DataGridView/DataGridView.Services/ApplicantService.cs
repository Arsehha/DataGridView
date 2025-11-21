using DataGridView.Entities;
using DataGridView.Services.Contracts;

namespace DataGridView.Services;

/// <summary>
/// Сервис по работе со студентами
/// </summary>
public class ApplicantService : IApplicantStorage
{
    private readonly IStorage storage;

    /// <summary>
    /// Инициализировать новый экземпляр <see cref="StudentService"/>
    /// </summary>
    public ApplicantService(IStorage storage)
    {
        this.storage = storage;
    }

    public async Task Add(ApplicantModel student, CancellationToken cancellationToken)
    {
        await storage.Add(student, cancellationToken);
    }

    public async Task Remove(Guid id, CancellationToken cancellationToken)
    {
        var std = await storage.GetById(id, cancellationToken);
        await storage.Remove(std, cancellationToken);
    }

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

    public async Task<ICollection<ApplicantModel>> GetAll(CancellationToken cancellationToken)
    {
        return await storage.GetAll(cancellationToken);
    }

    public async Task<int> GetStudentsByMinScore(int count, CancellationToken cancellationToken)
    {
        var stds = await storage.GetAll(cancellationToken);
        return stds.Count(x => x.InformaticsScore + x.MathScore + x.RussianScore > count);
    }

    public async Task<int> GetCountStudents(CancellationToken cancellationToken)
    {
        return await storage.GetCount(cancellationToken);
    }

}
