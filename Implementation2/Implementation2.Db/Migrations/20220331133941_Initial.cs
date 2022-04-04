using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Implementation2.Db.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            try
            {
                var divideSql = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Scripts", "Divide.sql"));
                if (!string.IsNullOrEmpty(divideSql))
                    migrationBuilder.Sql(divideSql);

                var generateSql = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Scripts", "GenerateIntegers.sql"));
                if (!string.IsNullOrEmpty(generateSql))
                    migrationBuilder.Sql(generateSql);

                var iterateSql = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Scripts", "Iterate.sql"));
                if (!string.IsNullOrEmpty(iterateSql))
                    migrationBuilder.Sql(iterateSql);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS dbo.Iterate");
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS dbo.GenerateIntegers");
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS dbo.Divide");
        }
    }
}
