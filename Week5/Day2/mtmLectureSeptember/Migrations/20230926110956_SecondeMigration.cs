using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mtmLectureSeptember.Migrations
{
    public partial class SecondeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Associations_Actors_ActorId1",
                table: "Associations");

            migrationBuilder.DropForeignKey(
                name: "FK_Associations_Movies_MovieId1",
                table: "Associations");

            migrationBuilder.DropIndex(
                name: "IX_Associations_ActorId1",
                table: "Associations");

            migrationBuilder.DropIndex(
                name: "IX_Associations_MovieId1",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "ActorId1",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "MovieId1",
                table: "Associations");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "Associations",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "ActorId",
                table: "Associations",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Associations_ActorId",
                table: "Associations",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Associations_MovieId",
                table: "Associations",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Associations_Actors_ActorId",
                table: "Associations",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "ActorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Associations_Movies_MovieId",
                table: "Associations",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Associations_Actors_ActorId",
                table: "Associations");

            migrationBuilder.DropForeignKey(
                name: "FK_Associations_Movies_MovieId",
                table: "Associations");

            migrationBuilder.DropIndex(
                name: "IX_Associations_ActorId",
                table: "Associations");

            migrationBuilder.DropIndex(
                name: "IX_Associations_MovieId",
                table: "Associations");

            migrationBuilder.AlterColumn<string>(
                name: "MovieId",
                table: "Associations",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ActorId",
                table: "Associations",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "ActorId1",
                table: "Associations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieId1",
                table: "Associations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Associations_ActorId1",
                table: "Associations",
                column: "ActorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Associations_MovieId1",
                table: "Associations",
                column: "MovieId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Associations_Actors_ActorId1",
                table: "Associations",
                column: "ActorId1",
                principalTable: "Actors",
                principalColumn: "ActorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Associations_Movies_MovieId1",
                table: "Associations",
                column: "MovieId1",
                principalTable: "Movies",
                principalColumn: "MovieId");
        }
    }
}
