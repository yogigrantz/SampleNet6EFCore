/*
 * --Code first:
 * add-migration 'init1' -context TestContext
 * update-database -context TestContext
 * 
 * --Data first:
 * Scaffold-DbContext "server=(localdb)\MSSQLLocalDB;database=testDB;integrated security=SSPI;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir TestDataFirst -Force
 * 
 */
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TestEFCore.TestDataFirst;

Console.WriteLine("test");

Note n = new Note()
{
    DateCreated = DateTime.Now,
    Title = $"Test direct insert {DateTime.Now.ToString("MM/dd/yyyy")}",
    Description = "This is a test to insert record directly to the table"
};

using (testDBContext t = new testDBContext())
{
    t.Add(n);
    t.SaveChanges();

    string sql = "EXEC uspNotesInsert @Title, @Description, @DateCreated, @DateUpdated";
    List<SqlParameter> parms = new List<SqlParameter>
    {
        new SqlParameter { ParameterName = "@Title", Value = "Test number two using SP", Direction = System.Data.ParameterDirection.Input },
        new SqlParameter { ParameterName = "@Description", Value = $"Test {DateTime.Now} this record is inserted with SP uspNotesInsert", Direction = System.Data.ParameterDirection.Input },
        new SqlParameter { ParameterName = "@DateCreated", Value = DateTime.Now.AddHours(-1), Direction = System.Data.ParameterDirection.Input},
        new SqlParameter { ParameterName = "@DateUpdated", Value = DateTime.Now, Direction = System.Data.ParameterDirection.Input}
    };
    t.Database.ExecuteSqlRaw(sql, parms);

    var notes = t.Notes.FromSqlRaw("exec uspNotesGet");

    foreach (Note n1 in notes)
    {
        Console.WriteLine($"{n1.Title} {n1.Description}");
    }

    var notes1 = t.Notes1.FromSqlRaw("exec uspNotesGet1");

    foreach (NoteDTO note in notes1)
    {
        Console.WriteLine($"{note.Id} - {note.Title}");
    }

}