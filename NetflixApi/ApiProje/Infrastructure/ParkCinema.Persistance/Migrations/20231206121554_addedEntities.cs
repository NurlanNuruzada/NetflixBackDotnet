using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkCinema.Persistance.Migrations
{
    public partial class addedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovieDescription_Actor_ActorId",
                table: "ActorMovieDescription");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovieDescription_MovieDescription_movieDescriptionId",
                table: "ActorMovieDescription");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryMovie_Category_CategoryId",
                table: "CategoryMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryMovie_Movies_MovieId",
                table: "CategoryMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieDescription_Movies_MovieId",
                table: "MovieDescription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieDescription",
                table: "MovieDescription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryMovie",
                table: "CategoryMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorMovieDescription",
                table: "ActorMovieDescription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actor",
                table: "Actor");

            migrationBuilder.RenameTable(
                name: "MovieDescription",
                newName: "movieDescriptions");

            migrationBuilder.RenameTable(
                name: "CategoryMovie",
                newName: "CategoryMovies");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "ActorMovieDescription",
                newName: "ActorMovieDescriptions");

            migrationBuilder.RenameTable(
                name: "Actor",
                newName: "Actors");

            migrationBuilder.RenameIndex(
                name: "IX_MovieDescription_MovieId",
                table: "movieDescriptions",
                newName: "IX_movieDescriptions_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryMovie_MovieId",
                table: "CategoryMovies",
                newName: "IX_CategoryMovies_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryMovie_CategoryId",
                table: "CategoryMovies",
                newName: "IX_CategoryMovies_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorMovieDescription_movieDescriptionId",
                table: "ActorMovieDescriptions",
                newName: "IX_ActorMovieDescriptions_movieDescriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorMovieDescription_ActorId",
                table: "ActorMovieDescriptions",
                newName: "IX_ActorMovieDescriptions_ActorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_movieDescriptions",
                table: "movieDescriptions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryMovies",
                table: "CategoryMovies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorMovieDescriptions",
                table: "ActorMovieDescriptions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actors",
                table: "Actors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovieDescriptions_Actors_ActorId",
                table: "ActorMovieDescriptions",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovieDescriptions_movieDescriptions_movieDescriptionId",
                table: "ActorMovieDescriptions",
                column: "movieDescriptionId",
                principalTable: "movieDescriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryMovies_Categories_CategoryId",
                table: "CategoryMovies",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryMovies_Movies_MovieId",
                table: "CategoryMovies",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_movieDescriptions_Movies_MovieId",
                table: "movieDescriptions",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovieDescriptions_Actors_ActorId",
                table: "ActorMovieDescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovieDescriptions_movieDescriptions_movieDescriptionId",
                table: "ActorMovieDescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryMovies_Categories_CategoryId",
                table: "CategoryMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryMovies_Movies_MovieId",
                table: "CategoryMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_movieDescriptions_Movies_MovieId",
                table: "movieDescriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_movieDescriptions",
                table: "movieDescriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryMovies",
                table: "CategoryMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actors",
                table: "Actors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorMovieDescriptions",
                table: "ActorMovieDescriptions");

            migrationBuilder.RenameTable(
                name: "movieDescriptions",
                newName: "MovieDescription");

            migrationBuilder.RenameTable(
                name: "CategoryMovies",
                newName: "CategoryMovie");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameTable(
                name: "Actors",
                newName: "Actor");

            migrationBuilder.RenameTable(
                name: "ActorMovieDescriptions",
                newName: "ActorMovieDescription");

            migrationBuilder.RenameIndex(
                name: "IX_movieDescriptions_MovieId",
                table: "MovieDescription",
                newName: "IX_MovieDescription_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryMovies_MovieId",
                table: "CategoryMovie",
                newName: "IX_CategoryMovie_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryMovies_CategoryId",
                table: "CategoryMovie",
                newName: "IX_CategoryMovie_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorMovieDescriptions_movieDescriptionId",
                table: "ActorMovieDescription",
                newName: "IX_ActorMovieDescription_movieDescriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorMovieDescriptions_ActorId",
                table: "ActorMovieDescription",
                newName: "IX_ActorMovieDescription_ActorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieDescription",
                table: "MovieDescription",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryMovie",
                table: "CategoryMovie",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actor",
                table: "Actor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorMovieDescription",
                table: "ActorMovieDescription",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovieDescription_Actor_ActorId",
                table: "ActorMovieDescription",
                column: "ActorId",
                principalTable: "Actor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovieDescription_MovieDescription_movieDescriptionId",
                table: "ActorMovieDescription",
                column: "movieDescriptionId",
                principalTable: "MovieDescription",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryMovie_Category_CategoryId",
                table: "CategoryMovie",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryMovie_Movies_MovieId",
                table: "CategoryMovie",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieDescription_Movies_MovieId",
                table: "MovieDescription",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
