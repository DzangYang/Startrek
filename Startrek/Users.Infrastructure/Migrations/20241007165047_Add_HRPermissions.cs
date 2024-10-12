using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Users.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_HRPermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Users",
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                schema: "Users",
                table: "Permission",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "DeletionMember" },
                    { 4, "TaskMember" },
                    { 5, "UpdateMember" },
                    { 501, "Admin_ReadMember" },
                    { 502, "Admin_TaskMember" },
                    { 503, "Admin_UpdateMember" },
                    { 504, "Admin_DeletionMember" },
                    { 610, "HR_AddCandidates" },
                    { 611, "HR_GetAllCandidates" },
                    { 612, "HR_GetByIdCandidate" },
                    { 613, "HR_GetByFilterCandidate" },
                    { 614, "HR_RemoveCandidate" },
                    { 615, "HR_UpdateCandidate" },
                    { 620, "HR_AddInterview" },
                    { 621, "HR_RelocateInterview" },
                    { 622, "HR_CancellInterview" },
                    { 623, "HR_ConductInterview" },
                    { 624, "HR_GetAllInterviews" },
                    { 625, "HR_GetByIdInterview" },
                    { 630, "HR_AddOffer" },
                    { 631, "HR_IssuanceOffer" },
                    { 632, "HR_RevokeOffer" },
                    { 633, "HR_ApplyOffer" },
                    { 634, "HR_GetAllOffers" },
                    { 635, "HR_GetByIdOffer" },
                    { 640, "HR_AddVacancy" },
                    { 641, "HR_UpdateVacancy" },
                    { 642, "HR_BindVacancy" },
                    { 643, "HR_GetByIdVacancy" },
                    { 644, "HR_GetAllVacancies" },
                    { 645, "HR_RemoveVacancy" }
                });

            migrationBuilder.UpdateData(
                schema: "Users",
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "HR_Officer");

            migrationBuilder.InsertData(
                schema: "Users",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "HR_Manager" });
            
      

            migrationBuilder.InsertData(
                schema: "Users",
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 3, 2 },
                    { 4, 2 },
                    { 5, 2 },
                    { 610, 2 },
                    { 620, 2 },
                    { 630, 2 },
                    { 640, 2 }
                });

    
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RolePermission_RoleId_PermissionId",
                schema: "Users",
                table: "RolePermission");

            migrationBuilder.DropIndex(
                name: "IX_Role_Id",
                schema: "Users",
                table: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Permission_Id",
                schema: "Users",
                table: "Permission");

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 501);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 502);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 503);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 504);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 611);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 612);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 613);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 614);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 615);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 621);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 622);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 623);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 624);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 625);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 631);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 632);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 633);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 634);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 635);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 641);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 642);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 643);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 644);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 645);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Role",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 610, 2 });

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 620, 2 });

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 630, 2 });

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 640, 2 });

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 610);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 620);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 630);

            migrationBuilder.DeleteData(
                schema: "Users",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 640);

            migrationBuilder.UpdateData(
                schema: "Users",
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Registered");

            migrationBuilder.InsertData(
                schema: "Users",
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 1, 3 }
                });
        }
    }
}
