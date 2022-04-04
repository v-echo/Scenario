using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Implementation2.Db.Migrations
{
    public partial class CreateResultsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                });

            try
            {
                var insertSql = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Scripts", "InsertResults.sql"));
                if (!string.IsNullOrEmpty(insertSql))
                    migrationBuilder.Sql(insertSql);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS dbo.InsertResults");

            migrationBuilder.DropTable(
                name: "Results");
        }
    }
}
