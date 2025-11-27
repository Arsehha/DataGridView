using DataGridView.Entities;

namespace DataGridView.Services.Contracts;

/// <summary>
/// Интерфейс для сервиса студентов
/// </summary>
public interface IApplicantService
{
    /// <summary>
    /// Добавить студента
    /// </summary>
    public Task Add(ApplicantModel student, CancellationToken cancellationToken);

    /// <summary>
    /// Удалить студента
    /// </summary>
    public Task Remove(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Обновить студента
    /// </summary>
    public Task Update(ApplicantModel student, CancellationToken cancellationToken);

    /// <summary>
    /// Получить всех студентов
    /// </summary>
    public Task<ICollection<ApplicantModel>> GetAll(CancellationToken cancellationToken);

    /// <summary>
    /// Получить всех студентов у которых общее кол-во баллов больше указанного
    /// </summary>
    public Task<int> GetStudentsByMinScore(int count, CancellationToken cancellationToken);

    /// <summary>
    /// Получить количество студентов
    /// </summary>
    public Task<int> GetCountStudents(CancellationToken cancellationToken);
}
