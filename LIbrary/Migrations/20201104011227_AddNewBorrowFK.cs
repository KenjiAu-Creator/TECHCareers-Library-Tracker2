using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LIbrary.Migrations
{
    public partial class AddNewBorrowFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_borrow_book_BookID",
                table: "borrow");

            migrationBuilder.RenameIndex(
                name: "IX_borrow_BookID",
                table: "borrow",
                newName: "FK_Borrow_Book");

            migrationBuilder.InsertData(
                table: "borrow",
                columns: new[] { "ID", "BookID", "CheckedOutDate", "DueDate", "ReturnedDate" },
                values: new object[] { -1, -1, new DateTime(2019, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "borrow",
                columns: new[] { "ID", "BookID", "CheckedOutDate", "DueDate", "ReturnedDate" },
                values: new object[] { -2, -2, new DateTime(2019, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "borrow",
                columns: new[] { "ID", "BookID", "CheckedOutDate", "DueDate", "ReturnedDate" },
                values: new object[] { -3, -3, new DateTime(2019, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.AddForeignKey(
                name: "FK_Borrow_Book",
                table: "borrow",
                column: "BookID",
                principalTable: "book",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrow_Book",
                table: "borrow");

            migrationBuilder.DeleteData(
                table: "borrow",
                keyColumn: "ID",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "borrow",
                keyColumn: "ID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "borrow",
                keyColumn: "ID",
                keyValue: -1);

            migrationBuilder.RenameIndex(
                name: "FK_Borrow_Book",
                table: "borrow",
                newName: "IX_borrow_BookID");

            migrationBuilder.AddForeignKey(
                name: "FK_borrow_book_BookID",
                table: "borrow",
                column: "BookID",
                principalTable: "book",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
