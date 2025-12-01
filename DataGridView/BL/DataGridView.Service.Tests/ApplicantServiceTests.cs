using DataGridView.Entities;
using DataGridView.Entities.Enums;
using DataGridView.Repository.Contracts;
using DataGridView.Services;
using DataGridView.Services.Contracts;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Xunit;

namespace DataGridView.Service.Tests
{
    /// <summary>
    /// Набор модульных тестов для проверки работы <see cref="ApplicantService"/>.
    /// </summary>
    public class ApplicantServiceTests
    {
        private readonly Mock<IStorage> storageMock;
        private readonly IApplicantService service;
        private readonly CancellationToken ct = CancellationToken.None;
        private readonly ILoggerFactory loggerFactory = NullLoggerFactory.Instance;

        public ApplicantServiceTests()
        {
            storageMock = new Mock<IStorage>();
            loggerFactory = NullLoggerFactory.Instance;
            service = new ApplicantService(storageMock.Object, loggerFactory);
        }

        /// <summary>
        /// Проверяет, что при добавлении абитуриента сервис вызывает метод Add хранилища.
        /// </summary>
        [Fact]
        public async Task AddShouldCallStorageAdd()
        {
            // Arrange
            var applicant = new ApplicantModel();

            // Act
            await service.Add(applicant, ct);

            // Assert
            storageMock.Verify(s => s.Add(applicant, ct), Times.Once);
        }

        /// <summary>
        /// Проверяет, что сервис запрашивает сущность по ID и затем удаляет её.
        /// </summary>
        [Fact]
        public async Task RemoveShouldGetByIdAndRemove()
        {
            // Arrange
            var id = Guid.NewGuid();
            var entity = new ApplicantModel { Id = id };

            storageMock
                .Setup(s => s.GetById(id, ct))
                .ReturnsAsync(entity);

            // Act
            await service.Remove(id, ct);

            // Assert
            storageMock.Verify(s => s.GetById(id, ct), Times.Once);
            storageMock.Verify(s => s.Remove(entity, ct), Times.Once);
        }

        /// <summary>
        /// Проверяет, что сервис загружает существующую сущность,
        /// копирует в неё переданные данные и вызывает обновление в хранилище.
        /// </summary>
        [Fact]
        public async Task UpdateShouldLoadEntityCopyPropsAndUpdate()
        {
            // Arrange
            var id = Guid.NewGuid();

            var existing = new ApplicantModel { Id = id };
            var incoming = new ApplicantModel
            {
                Id = id,
                DateOfBirth = new DateTime(2000, 1, 1),
                Sex = SexType.Male,
                EducationForm = EducationType.FullTime,
                FullName = "Test User",
                InformaticsScore = 90,
                RussianScore = 80,
                MathScore = 70
            };

            storageMock
                .Setup(s => s.GetById(id, ct))
                .ReturnsAsync(existing);

            // Act
            await service.Update(incoming, ct);

            // Assert
            existing.DateOfBirth.Should().Be(incoming.DateOfBirth);
            existing.Sex.Should().Be(incoming.Sex);
            existing.EducationForm.Should().Be(incoming.EducationForm);
            existing.FullName.Should().Be(incoming.FullName);
            existing.InformaticsScore.Should().Be(incoming.InformaticsScore);
            existing.RussianScore.Should().Be(incoming.RussianScore);
            existing.MathScore.Should().Be(incoming.MathScore);

            storageMock.Verify(s => s.Update(existing, ct), Times.Once);
        }

        /// <summary>
        /// Проверяет, что сервис возвращает данные, которые предоставляет хранилище.
        /// </summary>
        [Fact]
        public async Task GetAllShouldReturnDataFromStorage()
        {
            // Arrange
            var list = new List<ApplicantModel>
            {
                new ApplicantModel(),
                new ApplicantModel()
            };

            storageMock
                .Setup(s => s.GetAll(ct))
                .ReturnsAsync(list);

            // Act
            var result = await service.GetAll(ct);

            // Assert
            result.Should().BeSameAs(list);
        }

        /// <summary>
        /// Проверяет, что сервис корректно вычисляет количество абитуриентов,
        /// имеющих сумму баллов выше заданного порога.
        /// </summary>
        [Fact]
        public async Task GetStudentsByMinScoreShouldReturnCorrectCount()
        {
            // Arrange
            storageMock
                .Setup(s => s.GetAll(ct))
                .ReturnsAsync(new List<ApplicantModel>
                {
                    new ApplicantModel { InformaticsScore = 30, MathScore = 30, RussianScore = 30 },
                    new ApplicantModel { InformaticsScore = 10, MathScore = 10, RussianScore = 10 }
                });

            // Act
            var result = await service.GetStudentsByMinScore(80, ct);

            // Assert
            result.Should().Be(1);
        }

        /// <summary>
        /// Проверяет, что сервис возвращает 0,
        /// если ни один абитуриент не превышает пороговое значение суммы баллов.
        /// </summary>
        [Fact]
        public async Task GetStudentsByMinScoreShouldReturnZeroWhenNoOneIsAboveThreshold()
        {
            // Arrange
            storageMock
                .Setup(s => s.GetAll(ct))
                .ReturnsAsync(new List<ApplicantModel>
                {
                    new ApplicantModel { InformaticsScore = 10, MathScore = 10, RussianScore = 10 },
                    new ApplicantModel { InformaticsScore = 20, MathScore = 20, RussianScore = 20 }
                });

            // Act
            var result = await service.GetStudentsByMinScore(100, ct);

            // Assert
            result.Should().Be(0);
        }

        /// <summary>
        /// Проверяет, что сервис возвращает значение,
        /// предоставленное хранилищем при подсчёте количества абитуриентов.
        /// </summary>
        [Fact]
        public async Task GetCountStudentsShouldReturnValueFromStorage()
        {
            // Arrange
            storageMock
                .Setup(s => s.GetCount(ct))
                .ReturnsAsync(3);

            // Act
            var result = await service.GetCountStudents(ct);

            // Assert
            result.Should().Be(3);
        }
    }
}

