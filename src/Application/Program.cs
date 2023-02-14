using Application.DataAccess;
using Microsoft.EntityFrameworkCore;

using (var session = new LeanTrainingDbContext())
{
    var all = session.Database.GetAppliedMigrations();

    System.Console.WriteLine("Applied Migrations: " + string.Join(",", all));
}
