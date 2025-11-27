using DataGridView.Entities;
using DataGridView.Services;
using FluentAssertions;
using Xunit;
using DataGridView.Entities.Enums;
using DataGridView.Repository.Contracts;
using DataGridView.Services.Contracts;
using DataGridView.Repository;

/*namespace DataGridView.Service.Tests
{
    public class ApplicantServiceTests
    {
        private readonly IStorage storage;
        private readonly IApplicantService service;
        private readonly CancellationToken ct = CancellationToken.None;

        public ApplicantServiceTests()
        {
            storage = new InMemoryStorage();
            service = new ApplicantService(storage);
        }

        /// <summary>
        /// Добавление аббитуриента
        /// </summary>
        [Fact]
        public async Task Add_ShouldCallStorageAdd()
        {
            //Arrange
            var applicant = new ApplicantModel();

            //Act
            await service.Add(applicant, ct);

            //Assert

        }

        // -------------------------
        // Remove
        // -------------------------
        [Fact]
        public async Task Remove_ShouldCallGetById_AndRemove()
        {
            var id = Guid.NewGuid();
            var entity = new ApplicantModel { Id = id };

            storage.Entities.Add(entity);

            await service.Remove(id, ct);

            storage.GetByIdCalled.Should().BeTrue();
            storage.RemoveCalled.Should().BeTrue();
            storage.RemoveEntity.Should().Be(entity);
        }

        // -------------------------
        // Update
        // -------------------------
        [Fact]
        public async Task Update_ShouldLoadEntity_CopyProps_AndUpdate()
        {
            var id = Guid.NewGuid();
            var existing = new ApplicantModel { Id = id };

            storage.Entities.Add(existing);

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

            await service.Update(incoming, ct);

            existing.DateOfBirth.Should().Be(incoming.DateOfBirth);
            existing.Sex.Should().Be(incoming.Sex);
            existing.EducationForm.Should().Be(incoming.EducationForm);
            existing.FullName.Should().Be(incoming.FullName);
            existing.InformaticsScore.Should().Be(incoming.InformaticsScore);
            existing.RussianScore.Should().Be(incoming.RussianScore);
            existing.MathScore.Should().Be(incoming.MathScore);

            storage.UpdateCalled.Should().BeTrue();
            storage.UpdateEntity.Should().Be(existing);
        }

        // -------------------------
        // GetAll
        // -------------------------
        [Fact]
        public async Task GetAll_ShouldReturnAllEntities()
        {
            var list = new List<ApplicantModel>
            {
                new ApplicantModel(),
                new ApplicantModel()
            };

            storage.Entities = list;

            var result = await service.GetAll(ct);

            result.Should().BeSameAs(list);
        }

        // -------------------------
        // GetStudentsByMinScore
        // -------------------------
        [Fact]
        public async Task GetStudentsByMinScore_ShouldReturnCorrectCount()
        {
            storage.Entities = new List<ApplicantModel>
            {
                new ApplicantModel { InformaticsScore = 30, MathScore = 30, RussianScore = 30 }, // 90 > 80
                new ApplicantModel { InformaticsScore = 20, MathScore = 20, RussianScore = 20 }  // 60 <= 80
            };

            var result = await service.GetStudentsByMinScore(80, ct);

            result.Should().Be(1);
        }

        [Fact]
        public async Task GetStudentsByMinScore_ShouldReturnZero_WhenNoneMatch()
        {
            storage.Entities = new List<ApplicantModel>
            {
                new ApplicantModel { InformaticsScore = 10, MathScore = 10, RussianScore = 10 },
                new ApplicantModel { InformaticsScore = 20, MathScore = 20, RussianScore = 20 }
            };

            var result = await service.GetStudentsByMinScore(100, ct);

            result.Should().Be(0);
        }

        // -------------------------
        // GetCountStudents
        // -------------------------
        [Fact]
        public async Task GetCountStudents_ShouldReturnCount()
        {
            storage.CountValue = 3;

            var result = await service.GetCountStudents(ct);

            result.Should().Be(3);
        }
    }
}
*/
