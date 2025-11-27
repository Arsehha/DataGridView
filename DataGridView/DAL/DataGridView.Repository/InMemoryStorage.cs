using DataGridView.Entities;
using DataGridView.Repository.Contracts;

namespace DataGridView.Repository;

/// <summary>
/// Хранилище студентов в оперативной памяти
/// </summary>
public class InMemoryStorage : IStorage
{
    private List<ApplicantModel> applicants;

    /// <summary>
    /// Конструктор хранилища
    /// </summary>
    public InMemoryStorage()
    {
        applicants = new List<ApplicantModel>();
    }

    /// <summary>
    /// Добавление абитуриенты
    /// </summary>
    public Task Add(ApplicantModel applicant, CancellationToken cancellationToken)
    {
        applicants.Add(applicant);
        return Task.CompletedTask;
    }

    /// <summary>
    /// Удаление абитуриента
    /// </summary>
    public Task Remove(ApplicantModel applicant, CancellationToken cancellationToken)
    {
        applicants.Remove(applicant);
        return Task.CompletedTask;
    }

    /// <summary>
    /// Редактирование абитуриента
    /// </summary>
    public Task Update(ApplicantModel applicant, CancellationToken cancellationToken)
    {
        var index = applicants.FindIndex(x => x.Id == applicant.Id);
        applicants[index] = applicant;
        return Task.CompletedTask;
    }

    /// <summary>
    /// Получение абитуриента из базы
    /// </summary>
    public Task<ApplicantModel> GetById(Guid id, CancellationToken cancellationToken)
    {
        return Task.FromResult(applicants.FirstOrDefault(x => x.Id == id))!;
    }

    /// <summary>
    /// Получение списка абитуриентов
    /// </summary>
    public Task<List<ApplicantModel>> GetAll(CancellationToken cancellationToken)
    {
        return Task.FromResult(applicants);
    }

    /// <summary>
    /// Подсчёт абитуриентов
    /// </summary>
    public Task<int> GetCount(CancellationToken cancellationToken)
    {
        return Task.FromResult(applicants.Count);
    }
}
