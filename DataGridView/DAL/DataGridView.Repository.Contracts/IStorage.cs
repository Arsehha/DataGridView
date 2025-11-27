using DataGridView.Entities;

namespace DataGridView.Repository.Contracts
{
    /// <summary>
    /// Интерфейс хранилища
    /// </summary>
    public interface IStorage
    {
        /// <summary>
        /// Добавить студента
        /// </summary>
        public Task Add(ApplicantModel applicant, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить студента
        /// </summary>
        public Task Remove(ApplicantModel applicant, CancellationToken cancellationToken);

        /// <summary>
        /// Обновить студента
        /// </summary>
        public Task Update(ApplicantModel applicant, CancellationToken cancellationToken);

        /// <summary>
        /// Получить студента по идентификатору
        /// </summary>
        public Task<ApplicantModel> GetById(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить всех студентов
        /// </summary>
        public Task<List<ApplicantModel>> GetAll(CancellationToken cancellationToken);

        /// <summary>
        /// Получить количество студентов
        /// </summary>
        public Task<int> GetCount(CancellationToken cancellationToken);
    }
}
