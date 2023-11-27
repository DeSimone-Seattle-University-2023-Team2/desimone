using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDatabaseEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Jobs",
                type: "nvarchar(33)",
                maxLength: 33,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CostEstimateUsd",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CostUsd",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CpuTypeId",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "Jobs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DurationSeconds",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InputFile",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobSpeedId",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MemoryTypeId",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OutputFileDirectory",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RuntimeConfigFile",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupplementalFilesDirectory",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TerminatorId",
                table: "Jobs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CpuTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CpuTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobSubscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriberId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    JobId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSubscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobSubscriptions_AspNetUsers_SubscriberId",
                        column: x => x.SubscriberId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobSubscriptions_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemoryTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemoryTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobSpeeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkuId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemoryTypeId = table.Column<int>(type: "int", nullable: true),
                    CpuTypeId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSpeeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobSpeeds_CpuTypes_CpuTypeId",
                        column: x => x.CpuTypeId,
                        principalTable: "CpuTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobSpeeds_MemoryTypes_MemoryTypeId",
                        column: x => x.MemoryTypeId,
                        principalTable: "MemoryTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CpuTypeId",
                table: "Jobs",
                column: "CpuTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CreatorId",
                table: "Jobs",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_JobSpeedId",
                table: "Jobs",
                column: "JobSpeedId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_MemoryTypeId",
                table: "Jobs",
                column: "MemoryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ProjectId",
                table: "Jobs",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_StatusId",
                table: "Jobs",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_TerminatorId",
                table: "Jobs",
                column: "TerminatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_TypeId",
                table: "Jobs",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSpeeds_CpuTypeId",
                table: "JobSpeeds",
                column: "CpuTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSpeeds_MemoryTypeId",
                table: "JobSpeeds",
                column: "MemoryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSubscriptions_JobId",
                table: "JobSubscriptions",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSubscriptions_SubscriberId",
                table: "JobSubscriptions",
                column: "SubscriberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_AspNetUsers_CreatorId",
                table: "Jobs",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_AspNetUsers_TerminatorId",
                table: "Jobs",
                column: "TerminatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_CpuTypes_CpuTypeId",
                table: "Jobs",
                column: "CpuTypeId",
                principalTable: "CpuTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobSpeeds_JobSpeedId",
                table: "Jobs",
                column: "JobSpeedId",
                principalTable: "JobSpeeds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobStatuses_StatusId",
                table: "Jobs",
                column: "StatusId",
                principalTable: "JobStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobTypes_TypeId",
                table: "Jobs",
                column: "TypeId",
                principalTable: "JobTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_MemoryTypes_MemoryTypeId",
                table: "Jobs",
                column: "MemoryTypeId",
                principalTable: "MemoryTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Projects_ProjectId",
                table: "Jobs",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_AspNetUsers_CreatorId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_AspNetUsers_TerminatorId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_CpuTypes_CpuTypeId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobSpeeds_JobSpeedId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobStatuses_StatusId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobTypes_TypeId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_MemoryTypes_MemoryTypeId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Projects_ProjectId",
                table: "Jobs");

            migrationBuilder.DropTable(
                name: "JobSpeeds");

            migrationBuilder.DropTable(
                name: "JobStatuses");

            migrationBuilder.DropTable(
                name: "JobSubscriptions");

            migrationBuilder.DropTable(
                name: "JobTypes");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "CpuTypes");

            migrationBuilder.DropTable(
                name: "MemoryTypes");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_CpuTypeId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_CreatorId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_JobSpeedId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_MemoryTypeId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_ProjectId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_StatusId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_TerminatorId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_TypeId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CostEstimateUsd",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CostUsd",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CpuTypeId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "DurationSeconds",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "InputFile",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "JobSpeedId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "MemoryTypeId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "OutputFileDirectory",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "RuntimeConfigFile",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "SupplementalFilesDirectory",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "TerminatorId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Jobs");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(33)",
                oldMaxLength: 33);
        }
    }
}
