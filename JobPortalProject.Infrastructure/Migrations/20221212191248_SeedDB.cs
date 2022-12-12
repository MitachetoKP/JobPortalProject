using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortalProject.Infrastructure.Migrations
{
    public partial class SeedDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CV", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "24503cd9-443e-44c9-9264-564feeaae46a", 0, "I have no years of expirence in JS. Currently looking for an internship.", "89c36f7d-d575-4e92-ab80-6578fd99fd5b", "Mike@gmail.com", false, false, null, "MIKE@GMAIL.COM", "MIKE", "AQAAAAEAACcQAAAAEIKcBveYK9FODdOSjpnfDEMt+zr21sEKG2sGMpzZaPD17D8F0tEvKFPZll3+t+7p4g==", null, false, "c5e73a3f-1e65-41bb-ae94-f12836a58863", false, "Mike" },
                    { "5425a9af-d8cc-4bef-ab04-dde36a0ea47e", 0, null, "f2256c04-9005-41d1-9bcb-c54ce9ab3faf", "Admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEDTRBS2sdyxf+1azE108IQIF+EdWRaWO6PkI00tCyudRNBaZavaf79uOLkbiOQbecg==", 0123456789, false, "8fa52137-09b5-449b-9ae6-ca396630671e", false, "Admin" },
                    { "93df1c24-aabb-46fd-8809-ccd70959c7f0", 0, null, "f9687da7-4c07-4f1c-a99a-8ade2a94f236", "Microsoft@gmail.com", false, false, null, "MICROSOFT@GMAIL.COM", "MICROSOFT", "AQAAAAEAACcQAAAAEE/Ou6j/TGSacs85L/lNE7V7LG7T4BwfF0rVycF80q9Oc1CeXf35ojPcgNgAi/vxxg==", 04738945673, false, "670e2cb7-aa36-4386-888f-f5a7307690a1", false, "Microsoft" },
                    { "ea151599-df73-482a-8332-658ac822f086", 0, "I have 3 years of expirence in .NET.", "509e2e2b-be77-4f2f-8576-36af1dd53eae", "John@gmail.com", false, false, null, "JOHN@GMAIL.COM", "JOHN", "AQAAAAEAACcQAAAAEGz8SmdIPKttgxqg2npvgfVDATmeHGoBWWFGwT+2rKz1QrE1nU44spTUr/3+pZ0sYQ==", null, false, "082672a8-f8ba-4f5c-a0ac-c0ed7aa3e4cf", false, "John" },
                    { "fc204c28-2af1-4235-a4b8-a3db0576c94b", 0, "I have 6 years of expirence in Python.", "9f96e61f-5c9b-40a6-ab2a-5855ae7b7574", "Ivan@gmail.com", false, false, null, "IVAN@GMAIL.COM", "IVAN", "AQAAAAEAACcQAAAAELY7DhglPjoS37Wypw6JrYyFlmlWk3jnCaauL8ohaF5aVcsAMsq/xCkfjzy6gNluXA==", null, false, "4de01b14-bb7c-4fbb-9e86-37cceb219a5c", false, "Ivan" },
                    { "fe503507-9126-4d35-a7cc-d4a3c1ee931c", 0, null, "9bd7b2ad-8168-4bf6-b8b1-6d76be54659b", "Apple@gmail.com", false, false, null, "APPLE@GMAIL.COM", "APPLE", "AQAAAAEAACcQAAAAEAUiciGMVr+JMdVx3kjOJ8SYyKZsIm+sCoZ6oRZnTPo1EnDEV4M389uojHTdXDMqYA==", 0347648933, false, "bcadc472-69eb-48ac-a682-d01b085a0ff3", false, "Apple" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Java" },
                    { 2, ".NET" },
                    { 3, "Javascript" },
                    { 4, "Python" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sofia" },
                    { 2, "Plovdiv" },
                    { 3, "Remote" }
                });

            migrationBuilder.InsertData(
                table: "Seniorities",
                columns: new[] { "Id", "Level" },
                values: new object[,]
                {
                    { 1, "Senior" },
                    { 2, "Mid" },
                    { 3, "Junior" }
                });

            migrationBuilder.InsertData(
                table: "Employers",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 1, "0123456789", "5425a9af-d8cc-4bef-ab04-dde36a0ea47e" });

            migrationBuilder.InsertData(
                table: "Employers",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 2, "0347648933", "fe503507-9126-4d35-a7cc-d4a3c1ee931c" });

            migrationBuilder.InsertData(
                table: "Employers",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 3, "04738945673", "93df1c24-aabb-46fd-8809-ccd70959c7f0" });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "EmployerId", "LocationId", "Salary", "SeniorityId", "Title" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2022, 12, 12, 21, 12, 48, 302, DateTimeKind.Local).AddTicks(7829), "Junior C# developer. No experience required.", 2, 1, 2000m, 3, "Junior C#" },
                    { 2, 1, new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Senior Java developer. Must have 5+ years of experience in Java.", 2, 2, 5000m, 1, "Java Senior" },
                    { 3, 2, new DateTime(2022, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Senior Java developer. Must have 6+ years of experience in C# and JS.", 3, 3, 6000m, 1, "C# Full-Stack Senior" },
                    { 4, 4, new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Back-End Python Developer with 2+ years of expirence.", 3, 2, 3500m, 2, "Mid Level Python Developer" },
                    { 5, 3, new DateTime(2022, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Full-Stack Senior JS Developer. Must be expirienced in Node.Js and Angular/React.Js.", 1, 1, 5400m, 1, "Senior JS Developer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "24503cd9-443e-44c9-9264-564feeaae46a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ea151599-df73-482a-8332-658ac822f086");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc204c28-2af1-4235-a4b8-a3db0576c94b");

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Seniorities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Seniorities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Seniorities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5425a9af-d8cc-4bef-ab04-dde36a0ea47e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93df1c24-aabb-46fd-8809-ccd70959c7f0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fe503507-9126-4d35-a7cc-d4a3c1ee931c");
        }
    }
}
