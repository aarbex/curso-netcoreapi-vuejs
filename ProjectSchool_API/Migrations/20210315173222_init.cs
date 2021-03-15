using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectSchool_API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Sobrenome = table.Column<string>(type: "TEXT", nullable: true),
                    Dt_Nasc = table.Column<string>(type: "TEXT", nullable: true),
                    ProfessorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alunos_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1, "Rafael Casado" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 2, "Hélio Duarte" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Dt_Nasc", "Nome", "ProfessorId", "Sobrenome" },
                values: new object[] { 1, "13/09/1981", "André", 1, "Arbex" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Dt_Nasc", "Nome", "ProfessorId", "Sobrenome" },
                values: new object[] { 2, "10/03/1977", "Marcia", 1, "Arbex" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Dt_Nasc", "Nome", "ProfessorId", "Sobrenome" },
                values: new object[] { 3, "12/08/2010", "Victor", 2, "Arbex" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Dt_Nasc", "Nome", "ProfessorId", "Sobrenome" },
                values: new object[] { 4, "01/08/2014", "Arthur", 2, "Arbex" });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_ProfessorId",
                table: "Alunos",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
