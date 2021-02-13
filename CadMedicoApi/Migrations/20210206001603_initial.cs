using Microsoft.EntityFrameworkCore.Migrations;

namespace CadMedicoApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Estado = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Crm = table.Column<string>(type: "TEXT", nullable: true),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Privilegios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Privilegios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Login = table.Column<string>(type: "TEXT", nullable: true),
                    Senha = table.Column<string>(type: "TEXT", nullable: true),
                    PrivilegioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicoCidade",
                columns: table => new
                {
                    MedicoId = table.Column<int>(type: "INTEGER", nullable: false),
                    CidadeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicoCidade", x => new { x.MedicoId, x.CidadeId });
                    table.ForeignKey(
                        name: "FK_MedicoCidade_Cidades_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicoCidade_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicoEspecialidade",
                columns: table => new
                {
                    MedicoId = table.Column<int>(type: "INTEGER", nullable: false),
                    EspecialidadeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicoEspecialidade", x => new { x.MedicoId, x.EspecialidadeId });
                    table.ForeignKey(
                        name: "FK_MedicoEspecialidade_Especialidades_EspecialidadeId",
                        column: x => x.EspecialidadeId,
                        principalTable: "Especialidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicoEspecialidade_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cidades",
                columns: new[] { "Id", "Estado", "Nome" },
                values: new object[] { 1, "Parana", "Apucarana" });

            migrationBuilder.InsertData(
                table: "Cidades",
                columns: new[] { "Id", "Estado", "Nome" },
                values: new object[] { 2, "Paraná", "Londrina" });

            migrationBuilder.InsertData(
                table: "Cidades",
                columns: new[] { "Id", "Estado", "Nome" },
                values: new object[] { 3, "Paraná", "Curitiba" });

            migrationBuilder.InsertData(
                table: "Cidades",
                columns: new[] { "Id", "Estado", "Nome" },
                values: new object[] { 4, "Paraná", "Maringá" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1, "Obstetra" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 2, "Podólogo" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 3, "Cardiologista" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 4, "Geriatra" });

            migrationBuilder.InsertData(
                table: "Medicos",
                columns: new[] { "Id", "Crm", "Nome", "Telefone" },
                values: new object[] { 5, "37", "Chico", "3344-0099" });

            migrationBuilder.InsertData(
                table: "Medicos",
                columns: new[] { "Id", "Crm", "Nome", "Telefone" },
                values: new object[] { 4, "36", "Antonio", "3344-0099" });

            migrationBuilder.InsertData(
                table: "Medicos",
                columns: new[] { "Id", "Crm", "Nome", "Telefone" },
                values: new object[] { 3, "35", "Manoel", "3344-0099" });

            migrationBuilder.InsertData(
                table: "Medicos",
                columns: new[] { "Id", "Crm", "Nome", "Telefone" },
                values: new object[] { 2, "33", "Eduardo", "3344-0099" });

            migrationBuilder.InsertData(
                table: "Medicos",
                columns: new[] { "Id", "Crm", "Nome", "Telefone" },
                values: new object[] { 1, "33", "Eduardo", "3344-0099" });

            migrationBuilder.InsertData(
                table: "Privilegios",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1, "Master" });

            migrationBuilder.InsertData(
                table: "Privilegios",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 2, "Adm" });

            migrationBuilder.InsertData(
                table: "Privilegios",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 3, "User" });

            migrationBuilder.InsertData(
                table: "Privilegios",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 4, "UserMed" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Login", "Nome", "PrivilegioId", "Senha" },
                values: new object[] { 1, "Eduardo", "Eduardo", 1, "1234" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Login", "Nome", "PrivilegioId", "Senha" },
                values: new object[] { 2, "Chicao", "Chico", 2, "4321" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Login", "Nome", "PrivilegioId", "Senha" },
                values: new object[] { 3, "Cleitin", "Cleitin", 3, "0987" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Login", "Nome", "PrivilegioId", "Senha" },
                values: new object[] { 4, "Joao", "João", 5, "9087" });

            migrationBuilder.InsertData(
                table: "MedicoCidade",
                columns: new[] { "CidadeId", "MedicoId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "MedicoCidade",
                columns: new[] { "CidadeId", "MedicoId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "MedicoCidade",
                columns: new[] { "CidadeId", "MedicoId" },
                values: new object[] { 3, 3 });

            migrationBuilder.InsertData(
                table: "MedicoCidade",
                columns: new[] { "CidadeId", "MedicoId" },
                values: new object[] { 4, 4 });

            migrationBuilder.InsertData(
                table: "MedicoEspecialidade",
                columns: new[] { "EspecialidadeId", "MedicoId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "MedicoEspecialidade",
                columns: new[] { "EspecialidadeId", "MedicoId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "MedicoEspecialidade",
                columns: new[] { "EspecialidadeId", "MedicoId" },
                values: new object[] { 3, 3 });

            migrationBuilder.InsertData(
                table: "MedicoEspecialidade",
                columns: new[] { "EspecialidadeId", "MedicoId" },
                values: new object[] { 4, 4 });

            migrationBuilder.CreateIndex(
                name: "IX_MedicoCidade_CidadeId",
                table: "MedicoCidade",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicoEspecialidade_EspecialidadeId",
                table: "MedicoEspecialidade",
                column: "EspecialidadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicoCidade");

            migrationBuilder.DropTable(
                name: "MedicoEspecialidade");

            migrationBuilder.DropTable(
                name: "Privilegios");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Cidades");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "Medicos");
        }
    }
}
