using System.Diagnostics;
using DataGridView.Entities;
using DataGridView.Repository.Contracts;
using DataGridView.Services.Contracts;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;

namespace DataGridView.Services;

/// <summary>
/// Сервис по работе со студентами
/// </summary>
public class ApplicantService : IApplicantService
{

    private readonly IStorage storage;
    private readonly ILogger<ApplicantService> logger;

    /// <summary>
    /// Инициализировать новый экземпляр
    /// </summary>
    public ApplicantService(IStorage storage, ILoggerFactory loggerFactory)
    {
        this.storage = storage;
        logger = loggerFactory.CreateLogger<ApplicantService>();
    }

    /// <summary>
    /// Добавление студента
    /// </summary>
    public async Task Add(ApplicantModel student, CancellationToken cancellationToken)
    {
        var sw = Stopwatch.StartNew();
        await storage.Add(student, cancellationToken);

        logger.LogDebug("ApplicantService.Add выполнен за {ms} мс", sw.ElapsedMilliseconds);
    }

    /// <summary>
    /// Удаление студента
    /// </summary>
    public async Task Remove(Guid id, CancellationToken cancellationToken)
    {
        var sw = Stopwatch.StartNew();
        var std = await storage.GetById(id, cancellationToken);
        await storage.Remove(std, cancellationToken);

        logger.LogDebug("ApplicantService.Remove выполнен за {ms} мс", sw.ElapsedMilliseconds);
    }

    /// <summary>
    /// Редактирование студента
    /// </summary>
    public async Task Update(ApplicantModel student, CancellationToken cancellationToken)
    {
        var sw = Stopwatch.StartNew();
        var std = await storage.GetById(student.Id, cancellationToken);

        std.DateOfBirth = student.DateOfBirth;
        std.Sex = student.Sex;
        std.EducationForm = student.EducationForm;
        std.FullName = student.FullName;
        std.InformaticsScore = student.InformaticsScore;
        std.RussianScore = student.RussianScore;
        std.MathScore = student.MathScore;

        await storage.Update(std, cancellationToken);

        logger.LogDebug("ApplicantService.Update выполнен за {ms} мс", sw.ElapsedMilliseconds);
    }

    /// <summary>
    /// Получение списка студентов
    /// </summary>
    public async Task<ICollection<ApplicantModel>> GetAll(CancellationToken cancellationToken)
    {
        var sw = Stopwatch.StartNew();
        var res = await storage.GetAll(cancellationToken);

        logger.LogDebug("ApplicantService.GetAll выполнен за {ms} мс", sw.ElapsedMilliseconds);
        return res;
    }

    /// <summary>
    /// Подсчёт студентов с минимальным порогом
    /// </summary>
    public async Task<int> GetStudentsByMinScore(int count, CancellationToken cancellationToken)
    {
        var sw = Stopwatch.StartNew();
        var stds = await storage.GetAll(cancellationToken);

        var total = stds.Count(x => x.InformaticsScore + x.MathScore + x.RussianScore > count);

        logger.LogDebug("ApplicantService.GetStudentsByMinScore выполнен за {ms} мс", sw.ElapsedMilliseconds);
        return total;
    }

    /// <summary>
    /// Подсчёт количества студентов
    /// </summary>
    public async Task<int> GetCountStudents(CancellationToken cancellationToken)
    {
        var sw = Stopwatch.StartNew();
        var total = await storage.GetCount(cancellationToken);

        logger.LogDebug("ApplicantService.GetCountStudents выполнен за {ms} мс", sw.ElapsedMilliseconds);
        return total;
    }

}
