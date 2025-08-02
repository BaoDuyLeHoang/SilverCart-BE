using System.Net;
using Infrastructures;
using Infrastructures.Commons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class MigrationController(AppDbContext dbContext) : ControllerBase
{
    private readonly AppDbContext _dbContext = dbContext;

    [HttpGet("migrations")]
    public IActionResult GetMigrationDetails()
    {
        var migrations = _dbContext.Database.GetMigrations();
        var appliedMigrations = _dbContext.Database.GetAppliedMigrations();
        var pendingMigrations = migrations.Except(appliedMigrations);
        var migrationDetails = new
        {
            MissingMigrations = pendingMigrations.Where(m => !appliedMigrations.Contains(m)),
            AllMigrations = migrations
        };

        return Ok(migrationDetails);
    }

}