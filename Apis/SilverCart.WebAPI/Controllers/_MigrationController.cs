using System.Net;
using Infrastructures;
using Infrastructures.Commons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class MigrationController(AppDbContext dbContext) : ControllerBase
{
    private readonly AppDbContext _dbContext = dbContext;

    [HttpGet("migration/pending")]
    public IResultObject GetPendingMigration()
    {
        var migrations = _dbContext.Database.GetPendingMigrations();
        if (migrations.Any())
        {
            return ResultObject<IEnumerable<string>>.Success(migrations, HttpStatusCode.OK, "Các migration chưa áp dụng.");
        }
        return ResultObject<IEnumerable<string>>.Success(migrations, HttpStatusCode.OK, "Không có migration nào chưa áp dụng.");
    }

    [HttpGet("migration/applied")]
    public IResultObject GetAppliedMigration()
    {
        var migrations = _dbContext.Database.GetAppliedMigrations();
        return ResultObject<IEnumerable<string>>.Success(migrations, HttpStatusCode.OK, "Các migration đã áp dụng.");
    }

    [HttpGet("migration/all")]
    public IResultObject GetAllMigration()
    {
        var migrations = _dbContext.Database.GetMigrations();
        return ResultObject<IEnumerable<string>>.Success(migrations, HttpStatusCode.OK, "Tất cả các migration.");
    }
}