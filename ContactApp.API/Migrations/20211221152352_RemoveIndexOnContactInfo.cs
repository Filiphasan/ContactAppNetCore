using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactApp.API.Migrations
{
    public partial class RemoveIndexOnContactInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ContactInfos_ContactId_Key",
                table: "ContactInfos");

            migrationBuilder.UpdateData(
                table: "ContactInfos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 21, 15, 23, 51, 587, DateTimeKind.Utc).AddTicks(2639), new DateTime(2021, 12, 21, 15, 23, 51, 587, DateTimeKind.Utc).AddTicks(2646) });

            migrationBuilder.UpdateData(
                table: "ContactInfos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 21, 15, 23, 51, 587, DateTimeKind.Utc).AddTicks(2649), new DateTime(2021, 12, 21, 15, 23, 51, 587, DateTimeKind.Utc).AddTicks(2650) });

            migrationBuilder.UpdateData(
                table: "ContactInfos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 21, 15, 23, 51, 587, DateTimeKind.Utc).AddTicks(2651), new DateTime(2021, 12, 21, 15, 23, 51, 587, DateTimeKind.Utc).AddTicks(2652) });

            migrationBuilder.UpdateData(
                table: "ContactInfos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 21, 15, 23, 51, 587, DateTimeKind.Utc).AddTicks(2653), new DateTime(2021, 12, 21, 15, 23, 51, 587, DateTimeKind.Utc).AddTicks(2654) });

            migrationBuilder.UpdateData(
                table: "ContactInfos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 21, 15, 23, 51, 587, DateTimeKind.Utc).AddTicks(2655), new DateTime(2021, 12, 21, 15, 23, 51, 587, DateTimeKind.Utc).AddTicks(2656) });

            migrationBuilder.UpdateData(
                table: "ContactInfos",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 21, 15, 23, 51, 587, DateTimeKind.Utc).AddTicks(2657), new DateTime(2021, 12, 21, 15, 23, 51, 587, DateTimeKind.Utc).AddTicks(2658) });

            migrationBuilder.UpdateData(
                table: "ContactInfos",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 21, 15, 23, 51, 587, DateTimeKind.Utc).AddTicks(2729), new DateTime(2021, 12, 21, 15, 23, 51, 587, DateTimeKind.Utc).AddTicks(2730) });

            migrationBuilder.UpdateData(
                table: "ContactInfos",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 21, 15, 23, 51, 587, DateTimeKind.Utc).AddTicks(2733), new DateTime(2021, 12, 21, 15, 23, 51, 587, DateTimeKind.Utc).AddTicks(2734) });

            migrationBuilder.UpdateData(
                table: "ContactInfos",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 21, 15, 23, 51, 587, DateTimeKind.Utc).AddTicks(2735), new DateTime(2021, 12, 21, 15, 23, 51, 587, DateTimeKind.Utc).AddTicks(2736) });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: "06aa8dd6-12b2-45f0-9087-222889639d1c",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 21, 15, 23, 51, 585, DateTimeKind.Utc).AddTicks(6796), new DateTime(2021, 12, 21, 15, 23, 51, 585, DateTimeKind.Utc).AddTicks(6798) });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: "13539989-0439-4698-b694-ad6a8e65d5ab",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 21, 15, 23, 51, 585, DateTimeKind.Utc).AddTicks(6800), new DateTime(2021, 12, 21, 15, 23, 51, 585, DateTimeKind.Utc).AddTicks(6801) });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: "e96bb9b2-0d70-4c8f-8344-20872e24010c",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 21, 15, 23, 51, 585, DateTimeKind.Utc).AddTicks(6017), new DateTime(2021, 12, 21, 15, 23, 51, 585, DateTimeKind.Utc).AddTicks(6307) });

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfos_ContactId",
                table: "ContactInfos",
                column: "ContactId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ContactInfos_ContactId",
                table: "ContactInfos");

            migrationBuilder.UpdateData(
                table: "ContactInfos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 21, 11, 17, 51, 921, DateTimeKind.Utc).AddTicks(260), new DateTime(2021, 12, 21, 11, 17, 51, 921, DateTimeKind.Utc).AddTicks(269) });

            migrationBuilder.UpdateData(
                table: "ContactInfos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 21, 11, 17, 51, 921, DateTimeKind.Utc).AddTicks(273), new DateTime(2021, 12, 21, 11, 17, 51, 921, DateTimeKind.Utc).AddTicks(273) });

            migrationBuilder.UpdateData(
                table: "ContactInfos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 21, 11, 17, 51, 921, DateTimeKind.Utc).AddTicks(275), new DateTime(2021, 12, 21, 11, 17, 51, 921, DateTimeKind.Utc).AddTicks(276) });

            migrationBuilder.UpdateData(
                table: "ContactInfos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 21, 11, 17, 51, 921, DateTimeKind.Utc).AddTicks(277), new DateTime(2021, 12, 21, 11, 17, 51, 921, DateTimeKind.Utc).AddTicks(278) });

            migrationBuilder.UpdateData(
                table: "ContactInfos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 21, 11, 17, 51, 921, DateTimeKind.Utc).AddTicks(279), new DateTime(2021, 12, 21, 11, 17, 51, 921, DateTimeKind.Utc).AddTicks(280) });

            migrationBuilder.UpdateData(
                table: "ContactInfos",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 21, 11, 17, 51, 921, DateTimeKind.Utc).AddTicks(281), new DateTime(2021, 12, 21, 11, 17, 51, 921, DateTimeKind.Utc).AddTicks(282) });

            migrationBuilder.UpdateData(
                table: "ContactInfos",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 21, 11, 17, 51, 921, DateTimeKind.Utc).AddTicks(283), new DateTime(2021, 12, 21, 11, 17, 51, 921, DateTimeKind.Utc).AddTicks(284) });

            migrationBuilder.UpdateData(
                table: "ContactInfos",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 21, 11, 17, 51, 921, DateTimeKind.Utc).AddTicks(285), new DateTime(2021, 12, 21, 11, 17, 51, 921, DateTimeKind.Utc).AddTicks(286) });

            migrationBuilder.UpdateData(
                table: "ContactInfos",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 21, 11, 17, 51, 921, DateTimeKind.Utc).AddTicks(287), new DateTime(2021, 12, 21, 11, 17, 51, 921, DateTimeKind.Utc).AddTicks(287) });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: "06aa8dd6-12b2-45f0-9087-222889639d1c",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 21, 11, 17, 51, 919, DateTimeKind.Utc).AddTicks(6037), new DateTime(2021, 12, 21, 11, 17, 51, 919, DateTimeKind.Utc).AddTicks(6039) });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: "13539989-0439-4698-b694-ad6a8e65d5ab",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 21, 11, 17, 51, 919, DateTimeKind.Utc).AddTicks(6041), new DateTime(2021, 12, 21, 11, 17, 51, 919, DateTimeKind.Utc).AddTicks(6042) });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: "e96bb9b2-0d70-4c8f-8344-20872e24010c",
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 12, 21, 11, 17, 51, 919, DateTimeKind.Utc).AddTicks(5263), new DateTime(2021, 12, 21, 11, 17, 51, 919, DateTimeKind.Utc).AddTicks(5552) });

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfos_ContactId_Key",
                table: "ContactInfos",
                columns: new[] { "ContactId", "Key" },
                unique: true,
                filter: "[ContactId] IS NOT NULL");
        }
    }
}
