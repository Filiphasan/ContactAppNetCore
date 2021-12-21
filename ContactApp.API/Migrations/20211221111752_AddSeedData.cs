using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactApp.API.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "CreatedAt", "Firm", "FirstName", "LastName", "UpdatedAt" },
                values: new object[] { "e96bb9b2-0d70-4c8f-8344-20872e24010c", new DateTime(2021, 12, 21, 11, 17, 51, 919, DateTimeKind.Utc).AddTicks(5263), "Rise Consulting", "Hasan", "Erdal", new DateTime(2021, 12, 21, 11, 17, 51, 919, DateTimeKind.Utc).AddTicks(5552) });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "CreatedAt", "Firm", "FirstName", "LastName", "UpdatedAt" },
                values: new object[] { "06aa8dd6-12b2-45f0-9087-222889639d1c", new DateTime(2021, 12, 21, 11, 17, 51, 919, DateTimeKind.Utc).AddTicks(6037), "No Firm", "Mehmet", "Erdal", new DateTime(2021, 12, 21, 11, 17, 51, 919, DateTimeKind.Utc).AddTicks(6039) });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "CreatedAt", "Firm", "FirstName", "LastName", "UpdatedAt" },
                values: new object[] { "13539989-0439-4698-b694-ad6a8e65d5ab", new DateTime(2021, 12, 21, 11, 17, 51, 919, DateTimeKind.Utc).AddTicks(6041), "No Firm", "Mustafa", "Erdal", new DateTime(2021, 12, 21, 11, 17, 51, 919, DateTimeKind.Utc).AddTicks(6042) });

            migrationBuilder.InsertData(
                table: "ContactInfos",
                columns: new[] { "Id", "ContactId", "CreatedAt", "Key", "UpdatedAt", "Value" },
                values: new object[,]
                {
                    { 1, "e96bb9b2-0d70-4c8f-8344-20872e24010c", new DateTime(2021, 12, 21, 11, 17, 51, 921, DateTimeKind.Utc).AddTicks(260), "Telefon Numarası", new DateTime(2021, 12, 21, 11, 17, 51, 921, DateTimeKind.Utc).AddTicks(269), "+90 537 035 2059" },
                    { 2, "e96bb9b2-0d70-4c8f-8344-20872e24010c", new DateTime(2021, 12, 21, 11, 17, 51, 921, DateTimeKind.Utc).AddTicks(273), "E-Mail Adresi", new DateTime(2021, 12, 21, 11, 17, 51, 921, DateTimeKind.Utc).AddTicks(273), "hasaerda@hotmail.com" },
                    { 3, "e96bb9b2-0d70-4c8f-8344-20872e24010c", new DateTime(2021, 12, 21, 11, 17, 51, 921, DateTimeKind.Utc).AddTicks(275), "Konum", new DateTime(2021, 12, 21, 11, 17, 51, 921, DateTimeKind.Utc).AddTicks(276), "Şahinbey/Gaziantep" },
                    { 4, "06aa8dd6-12b2-45f0-9087-222889639d1c", new DateTime(2021, 12, 21, 11, 17, 51, 921, DateTimeKind.Utc).AddTicks(277), "Telefon Numarası", new DateTime(2021, 12, 21, 11, 17, 51, 921, DateTimeKind.Utc).AddTicks(278), "+90 537 035 2059" },
                    { 5, "06aa8dd6-12b2-45f0-9087-222889639d1c", new DateTime(2021, 12, 21, 11, 17, 51, 921, DateTimeKind.Utc).AddTicks(279), "E-Mail Adresi", new DateTime(2021, 12, 21, 11, 17, 51, 921, DateTimeKind.Utc).AddTicks(280), "hasaerda@hotmail.com" },
                    { 6, "06aa8dd6-12b2-45f0-9087-222889639d1c", new DateTime(2021, 12, 21, 11, 17, 51, 921, DateTimeKind.Utc).AddTicks(281), "Konum", new DateTime(2021, 12, 21, 11, 17, 51, 921, DateTimeKind.Utc).AddTicks(282), "Şahinbey/Gaziantep" },
                    { 7, "13539989-0439-4698-b694-ad6a8e65d5ab", new DateTime(2021, 12, 21, 11, 17, 51, 921, DateTimeKind.Utc).AddTicks(283), "Telefon Numarası", new DateTime(2021, 12, 21, 11, 17, 51, 921, DateTimeKind.Utc).AddTicks(284), "+90 537 035 2059" },
                    { 8, "13539989-0439-4698-b694-ad6a8e65d5ab", new DateTime(2021, 12, 21, 11, 17, 51, 921, DateTimeKind.Utc).AddTicks(285), "E-Mail Adresi", new DateTime(2021, 12, 21, 11, 17, 51, 921, DateTimeKind.Utc).AddTicks(286), "hasaerda@hotmail.com" },
                    { 9, "13539989-0439-4698-b694-ad6a8e65d5ab", new DateTime(2021, 12, 21, 11, 17, 51, 921, DateTimeKind.Utc).AddTicks(287), "Konum", new DateTime(2021, 12, 21, 11, 17, 51, 921, DateTimeKind.Utc).AddTicks(287), "Şehitkamil/Gaziantep" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactInfos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ContactInfos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ContactInfos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ContactInfos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ContactInfos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ContactInfos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ContactInfos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ContactInfos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ContactInfos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: "06aa8dd6-12b2-45f0-9087-222889639d1c");

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: "13539989-0439-4698-b694-ad6a8e65d5ab");

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: "e96bb9b2-0d70-4c8f-8344-20872e24010c");
        }
    }
}
