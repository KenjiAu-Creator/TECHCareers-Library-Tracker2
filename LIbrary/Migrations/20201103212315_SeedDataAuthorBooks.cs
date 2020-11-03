using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LIbrary.Migrations
{
    public partial class SeedDataAuthorBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DeathDate",
                table: "author",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.InsertData(
                table: "author",
                columns: new[] { "ID", "BirthDate", "DeathDate", "Name" },
                values: new object[,]
                {
                    { -1, new DateTime(1958, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mitch Albom" },
                    { -2, new DateTime(1970, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Daniel Handler" },
                    { -3, new DateTime(1892, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1973, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "J.R.R. Tolkien" },
                    { -4, new DateTime(1948, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "George R. R. Martin" },
                    { -5, new DateTime(1904, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1991, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dr. Seuss" }
                });

            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "ID", "AuthorID", "PublicationDate", "Title" },
                values: new object[] { -1, -5, new DateTime(1957, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Cat in the Hat" });

            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "ID", "AuthorID", "PublicationDate", "Title" },
                values: new object[] { -2, -5, new DateTime(1960, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Green Eggs and Ham" });

            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "ID", "AuthorID", "PublicationDate", "Title" },
                values: new object[] { -3, -5, new DateTime(1990, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oh, the Places You'll Go!" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "ID",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "ID",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "ID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "ID",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "ID",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "ID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "ID",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "ID",
                keyValue: -5);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeathDate",
                table: "author",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);
        }
    }
}
