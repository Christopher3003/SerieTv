using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITLATv.Database.Migrations
{
    /// <inheritdoc />
    public partial class changePropertiesOfSerieEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productora",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productora", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Serie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProducterId = table.Column<int>(type: "int", nullable: false),
                    PrimaryGenderId = table.Column<int>(type: "int", nullable: false),
                    SecondaryGenderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Serie_Genero_PrimaryGenderId",
                        column: x => x.PrimaryGenderId,
                        principalTable: "Genero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Serie_Genero_SecondaryGenderId",
                        column: x => x.SecondaryGenderId,
                        principalTable: "Genero",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Serie_Productora_ProducterId",
                        column: x => x.ProducterId,
                        principalTable: "Productora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Serie_PrimaryGenderId",
                table: "Serie",
                column: "PrimaryGenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Serie_ProducterId",
                table: "Serie",
                column: "ProducterId");

            migrationBuilder.CreateIndex(
                name: "IX_Serie_SecondaryGenderId",
                table: "Serie",
                column: "SecondaryGenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Serie");

            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.DropTable(
                name: "Productora");
        }
    }
}
