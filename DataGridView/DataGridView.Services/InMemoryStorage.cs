using DataGridView.Entities;
using DataGridView.Entities.Enums;
using DataGridView.Services.Contracts;

namespace DataGridView.Services;

/// <summary>
/// Хранилище студентов в оперативной памяти
/// </summary>
public class InMemoryStorage : IStorage
{
    private List<ApplicantModel> applicants;

    public InMemoryStorage()
    {
        applicants = new List<ApplicantModel>
        {
            new ApplicantModel {
                FullName="Артем Артан Артурович",
                Sex=SexType.Male,
                DateOfBirth=new(2006,1,24),
                EducationForm = EducationType.FullTime,
                MathScore=50,
                RussianScore=50,
                InformaticsScore=0
            },
            new ApplicantModel {
                FullName="Фулл тайм Клиренс",
                Sex=SexType.Female,
                DateOfBirth=new(2006,10,21),
                EducationForm = EducationType.FullTimeAndPartTime,
                MathScore=75,
                RussianScore=34,
                InformaticsScore=12
            },
            new ApplicantModel {
                FullName="Хеликоптер",
                Sex=SexType.Female,
                DateOfBirth=new(2006,5,02),
                EducationForm = EducationType.FullTime,
                MathScore=12,
                RussianScore=4,
                InformaticsScore=100
            },
        };
    }

    public Task Add(ApplicantModel applicant, CancellationToken cancellationToken)
    {
        applicants.Add(applicant);
        return Task.CompletedTask;
    }

    public Task Remove(ApplicantModel applicant, CancellationToken cancellationToken)
    {
        applicants.Remove(applicant);
        return Task.CompletedTask;
    }

    public Task Update(ApplicantModel applicant, CancellationToken cancellationToken)
    {
        var index = applicants.FindIndex(x => x.Id == applicant.Id);
        applicants[index] = applicant;
        return Task.CompletedTask;
    }

    public Task<ApplicantModel> GetById(Guid id, CancellationToken cancellationToken)
    {
        return Task.FromResult(applicants.FirstOrDefault(x => x.Id == id))!;
    }

    public Task<List<ApplicantModel>> GetAll(CancellationToken cancellationToken)
    {
        return Task.FromResult(applicants);
    }

    public Task<int> GetCount(CancellationToken cancellationToken)
    {
        return Task.FromResult(applicants.Count);
    }
}
