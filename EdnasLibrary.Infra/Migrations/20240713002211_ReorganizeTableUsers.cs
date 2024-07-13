using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EdnasLibrary.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ReorganizeTableUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_BooksLoans_BooksLoanId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Books_BookId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_BooksLoans_BooksLoanId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_BooksLoanId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BookId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BooksLoanId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BooksLoanId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BooksLoanId",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BooksLoanId",
                table: "Books",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BookId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BooksLoanId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_BooksLoanId",
                table: "Books",
                column: "BooksLoanId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BookId",
                table: "AspNetUsers",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BooksLoanId",
                table: "AspNetUsers",
                column: "BooksLoanId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_BooksLoans_BooksLoanId",
                table: "AspNetUsers",
                column: "BooksLoanId",
                principalTable: "BooksLoans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Books_BookId",
                table: "AspNetUsers",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BooksLoans_BooksLoanId",
                table: "Books",
                column: "BooksLoanId",
                principalTable: "BooksLoans",
                principalColumn: "Id");
        }
    }
}
