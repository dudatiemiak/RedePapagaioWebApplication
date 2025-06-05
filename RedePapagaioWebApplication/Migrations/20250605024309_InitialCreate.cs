using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedePapagaioWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_PPG_NIVEL_URGENCIA",
                columns: table => new
                {
                    ID_NIVEL_URGENCIA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NM_NIVEL = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_PPG_NIVEL_URGENCIA", x => x.ID_NIVEL_URGENCIA);
                });

            migrationBuilder.CreateTable(
                name: "T_PPG_REGIAO",
                columns: table => new
                {
                    ID_REGIAO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NM_REGIAO = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    NM_CIDADE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    NM_ESTADO = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    NM_PAIS = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_PPG_REGIAO", x => x.ID_REGIAO);
                });

            migrationBuilder.CreateTable(
                name: "T_PPG_STATUS_OCORRENCIA",
                columns: table => new
                {
                    ID_STATUS_OCORRENCIA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NM_STATUS = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_PPG_STATUS_OCORRENCIA", x => x.ID_STATUS_OCORRENCIA);
                });

            migrationBuilder.CreateTable(
                name: "T_PPG_TIPO_AJUDA",
                columns: table => new
                {
                    ID_TIPO_AJUDA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NM_TIPO_AJUDA = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_PPG_TIPO_AJUDA", x => x.ID_TIPO_AJUDA);
                });

            migrationBuilder.CreateTable(
                name: "T_PPG_TIPO_OCORRENCIA",
                columns: table => new
                {
                    ID_TIPO_OCORRENCIA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NM_TIPO_OCORRENCIA = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_PPG_TIPO_OCORRENCIA", x => x.ID_TIPO_OCORRENCIA);
                });

            migrationBuilder.CreateTable(
                name: "T_PPG_USUARIO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NM_USUARIO = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    NM_EMAIL = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    NM_SENHA = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    DT_CADASTRO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_PPG_USUARIO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "T_PPG_OCORRENCIA",
                columns: table => new
                {
                    ID_OCORRENCIA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_OCORRENCIA = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    ID_STATUS_OCORRENCIA = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ID_NIVEL_URGENCIA = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ID_REGIAO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ID_TIPO_OCORRENCIA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_PPG_OCORRENCIA", x => x.ID_OCORRENCIA);
                    table.ForeignKey(
                        name: "FK_T_PPG_OCORRENCIA_T_PPG_NIVEL_URGENCIA_ID_NIVEL_URGENCIA",
                        column: x => x.ID_NIVEL_URGENCIA,
                        principalTable: "T_PPG_NIVEL_URGENCIA",
                        principalColumn: "ID_NIVEL_URGENCIA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_PPG_OCORRENCIA_T_PPG_REGIAO_ID_REGIAO",
                        column: x => x.ID_REGIAO,
                        principalTable: "T_PPG_REGIAO",
                        principalColumn: "ID_REGIAO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_PPG_OCORRENCIA_T_PPG_STATUS_OCORRENCIA_ID_STATUS_OCORRENCIA",
                        column: x => x.ID_STATUS_OCORRENCIA,
                        principalTable: "T_PPG_STATUS_OCORRENCIA",
                        principalColumn: "ID_STATUS_OCORRENCIA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_PPG_OCORRENCIA_T_PPG_TIPO_OCORRENCIA_ID_TIPO_OCORRENCIA",
                        column: x => x.ID_TIPO_OCORRENCIA,
                        principalTable: "T_PPG_TIPO_OCORRENCIA",
                        principalColumn: "ID_TIPO_OCORRENCIA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_PPG_TELEFONE",
                columns: table => new
                {
                    ID_TELEFONE = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NR_TELEFONE = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    NR_DDD = table.Column<string>(type: "NVARCHAR2(5)", maxLength: 5, nullable: false),
                    NR_DDI = table.Column<string>(type: "NVARCHAR2(5)", maxLength: 5, nullable: false),
                    ID_USUARIO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_PPG_TELEFONE", x => x.ID_TELEFONE);
                    table.ForeignKey(
                        name: "FK_T_PPG_TELEFONE_T_PPG_USUARIO_ID_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "T_PPG_USUARIO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_PPG_AJUDA_REALIZADA",
                columns: table => new
                {
                    ID_AJUDA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_AJUDA = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    DT_AJUDA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ID_USUARIO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ID_OCORRENCIA = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ID_TIPO_AJUDA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_PPG_AJUDA_REALIZADA", x => x.ID_AJUDA);
                    table.ForeignKey(
                        name: "FK_T_PPG_AJUDA_REALIZADA_T_PPG_OCORRENCIA_ID_OCORRENCIA",
                        column: x => x.ID_OCORRENCIA,
                        principalTable: "T_PPG_OCORRENCIA",
                        principalColumn: "ID_OCORRENCIA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_PPG_AJUDA_REALIZADA_T_PPG_TIPO_AJUDA_ID_TIPO_AJUDA",
                        column: x => x.ID_TIPO_AJUDA,
                        principalTable: "T_PPG_TIPO_AJUDA",
                        principalColumn: "ID_TIPO_AJUDA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_PPG_AJUDA_REALIZADA_T_PPG_USUARIO_ID_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "T_PPG_USUARIO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_PPG_AJUDA_REALIZADA_ID_OCORRENCIA",
                table: "T_PPG_AJUDA_REALIZADA",
                column: "ID_OCORRENCIA");

            migrationBuilder.CreateIndex(
                name: "IX_T_PPG_AJUDA_REALIZADA_ID_TIPO_AJUDA",
                table: "T_PPG_AJUDA_REALIZADA",
                column: "ID_TIPO_AJUDA");

            migrationBuilder.CreateIndex(
                name: "IX_T_PPG_AJUDA_REALIZADA_ID_USUARIO",
                table: "T_PPG_AJUDA_REALIZADA",
                column: "ID_USUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_T_PPG_OCORRENCIA_ID_NIVEL_URGENCIA",
                table: "T_PPG_OCORRENCIA",
                column: "ID_NIVEL_URGENCIA");

            migrationBuilder.CreateIndex(
                name: "IX_T_PPG_OCORRENCIA_ID_REGIAO",
                table: "T_PPG_OCORRENCIA",
                column: "ID_REGIAO");

            migrationBuilder.CreateIndex(
                name: "IX_T_PPG_OCORRENCIA_ID_STATUS_OCORRENCIA",
                table: "T_PPG_OCORRENCIA",
                column: "ID_STATUS_OCORRENCIA");

            migrationBuilder.CreateIndex(
                name: "IX_T_PPG_OCORRENCIA_ID_TIPO_OCORRENCIA",
                table: "T_PPG_OCORRENCIA",
                column: "ID_TIPO_OCORRENCIA");

            migrationBuilder.CreateIndex(
                name: "IX_T_PPG_TELEFONE_ID_USUARIO",
                table: "T_PPG_TELEFONE",
                column: "ID_USUARIO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_PPG_AJUDA_REALIZADA");

            migrationBuilder.DropTable(
                name: "T_PPG_TELEFONE");

            migrationBuilder.DropTable(
                name: "T_PPG_OCORRENCIA");

            migrationBuilder.DropTable(
                name: "T_PPG_TIPO_AJUDA");

            migrationBuilder.DropTable(
                name: "T_PPG_USUARIO");

            migrationBuilder.DropTable(
                name: "T_PPG_NIVEL_URGENCIA");

            migrationBuilder.DropTable(
                name: "T_PPG_REGIAO");

            migrationBuilder.DropTable(
                name: "T_PPG_STATUS_OCORRENCIA");

            migrationBuilder.DropTable(
                name: "T_PPG_TIPO_OCORRENCIA");
        }
    }
}
