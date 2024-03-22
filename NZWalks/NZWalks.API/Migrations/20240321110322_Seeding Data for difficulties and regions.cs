using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDatafordifficultiesandregions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("80d61684-f006-4a19-ae1a-dbbdbfe96637"), "Easy" },
                    { new Guid("dcc4eabc-94d2-454d-a591-61d036de7e8a"), "Hard" },
                    { new Guid("dcf84ff4-4012-4557-93b9-dfed9f145f60"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("1fd75ee7-b268-404e-9f2a-1d73e51de12a"), "NSN", "Nelson", "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("525e1721-94a6-4946-bf90-61ddff846c3e"), "WLG", "Wellington", "https://images.pexels.com/photos/8379417/pexels-photo-8379417.jpeg" },
                    { new Guid("567d99df-cbba-404e-a7f4-420219a0cdf5"), "AKL", "Auckland", "https://images.pexels.com/photos/19575682/pexels-photo-19575682/free-photo-of-view-of-auckland-city-from-mission-bay-in-new-zealand.jpeg" },
                    { new Guid("5ad46428-8a7f-4122-8ba9-83f720f0fc15"), "NTL", "Northland", "https://images.unsplash.com/photo-1706284723423-b307c6bf57c4" },
                    { new Guid("5c20f56b-42e7-4003-9a8f-8cd0d24a07db"), "STL", "Southland", null },
                    { new Guid("99c3ebfd-421a-4cbd-8fda-45d1f870698c"), "BOP", "Bay Of Plenty", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("80d61684-f006-4a19-ae1a-dbbdbfe96637"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("dcc4eabc-94d2-454d-a591-61d036de7e8a"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("dcf84ff4-4012-4557-93b9-dfed9f145f60"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1fd75ee7-b268-404e-9f2a-1d73e51de12a"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("525e1721-94a6-4946-bf90-61ddff846c3e"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("567d99df-cbba-404e-a7f4-420219a0cdf5"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("5ad46428-8a7f-4122-8ba9-83f720f0fc15"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("5c20f56b-42e7-4003-9a8f-8cd0d24a07db"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("99c3ebfd-421a-4cbd-8fda-45d1f870698c"));
        }
    }
}
