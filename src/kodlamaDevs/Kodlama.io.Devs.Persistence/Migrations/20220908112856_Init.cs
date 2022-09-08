using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kodlama.io.Devs.Persistence.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgrammingLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammingLanguages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PLTechnologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgrammingLanguageId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLTechnologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PLTechnologies_ProgrammingLanguages_ProgrammingLanguageId",
                        column: x => x.ProgrammingLanguageId,
                        principalTable: "ProgrammingLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguages",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "C#" });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguages",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "JAVA" });

            migrationBuilder.InsertData(
                table: "ProgrammingLanguages",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "JavaScript" });

            migrationBuilder.InsertData(
                table: "PLTechnologies",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "ProgrammingLanguageId" },
                values: new object[,]
                {
                    { 1, "Greate technology for Java", "", "Spring", 2 },
                    { 2, "From META to Javascript", "", "React", 3 },
                    { 3, "Google's answer for React", "", "Angular", 3 },
                    { 4, "Amazing C# Tecnlogy", "", ".NET", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PLTechnologies_ProgrammingLanguageId",
                table: "PLTechnologies",
                column: "ProgrammingLanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PLTechnologies");

            migrationBuilder.DropTable(
                name: "ProgrammingLanguages");
        }
    }
}
