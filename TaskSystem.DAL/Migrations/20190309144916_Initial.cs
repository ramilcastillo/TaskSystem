using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskSystem.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskDefaultPocs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActualUser = table.Column<string>(nullable: true),
                    DefaultPoc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskDefaultPocs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskDelegates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActualUser = table.Column<string>(nullable: true),
                    DelegateUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskDelegates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FileTaskId = table.Column<int>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    FileSize = table.Column<int>(nullable: true),
                    FileData = table.Column<byte[]>(nullable: true),
                    ContentType = table.Column<string>(nullable: true),
                    FileAddedBy = table.Column<string>(nullable: true),
                    FileAddedDate = table.Column<DateTime>(nullable: true),
                    FileUploadVersion = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskPocs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PoctaskId = table.Column<int>(nullable: false),
                    Pocusername = table.Column<string>(nullable: true),
                    PocdateClosed = table.Column<DateTime>(nullable: true),
                    PocdateAssigned = table.Column<DateTime>(nullable: false),
                    ParentUsername = table.Column<string>(nullable: true),
                    PocdateDue = table.Column<DateTime>(nullable: true),
                    Pocsort = table.Column<string>(nullable: true),
                    Poclevel = table.Column<int>(nullable: true),
                    PocisFlagged = table.Column<bool>(nullable: true),
                    PocpersonalNote = table.Column<string>(nullable: true),
                    PocpersonalDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskPocs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Subject = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Priority = table.Column<short>(nullable: false),
                    Orgcode = table.Column<string>(nullable: true),
                    FileNumber = table.Column<string>(nullable: true),
                    Requestor = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    RecurringId = table.Column<int>(nullable: true),
                    DeletionFlag = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TasksHome",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TaskOwnerDuedate = table.Column<DateTime>(nullable: false),
                    TaskOwnerDate = table.Column<DateTime>(nullable: false),
                    TaskOwnerComments = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    Requestor = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    ParentUsername = table.Column<string>(nullable: true),
                    TaskOwner = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasksHome", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskUpdates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TaskId = table.Column<int>(nullable: true),
                    DateUpdate = table.Column<DateTime>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Labor = table.Column<float>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskUpdates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserNames",
                columns: table => new
                {
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    OrgCode = table.Column<string>(nullable: true),
                    ActiveEmployee = table.Column<bool>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: false),
                    AllowLogin = table.Column<bool>(nullable: true),
                    AllowEditInfo = table.Column<bool>(nullable: true),
                    PrivLevel = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    AdupdateDate = table.Column<DateTime>(nullable: true),
                    EmailWeekly = table.Column<bool>(nullable: true),
                    PalviewDefault = table.Column<string>(nullable: true),
                    RedesignSuggReport = table.Column<bool>(nullable: true),
                    AdwhenCreated = table.Column<DateTime>(nullable: true),
                    DivLevel = table.Column<bool>(nullable: true),
                    GovEmp = table.Column<bool>(nullable: true),
                    ScriptPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNames", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "V_TaskPocs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PoctaskId = table.Column<int>(nullable: false),
                    Pocusername = table.Column<string>(nullable: true),
                    PocdateClosed = table.Column<DateTime>(nullable: true),
                    PocdateAssigned = table.Column<DateTime>(nullable: false),
                    ParentUsername = table.Column<string>(nullable: true),
                    PocdateDue = table.Column<DateTime>(nullable: true),
                    Pocsort = table.Column<string>(nullable: true),
                    Poclevel = table.Column<int>(nullable: true),
                    PocisFlagged = table.Column<bool>(nullable: true),
                    PocpersonalNote = table.Column<string>(nullable: true),
                    PocpersonalDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_V_TaskPocs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "V_Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Subject = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Priority = table.Column<short>(nullable: false),
                    Orgcode = table.Column<string>(nullable: true),
                    FileNumber = table.Column<string>(nullable: true),
                    Requestor = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    RecurringId = table.Column<int>(nullable: true),
                    DeletionFlag = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_V_Tasks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskDefaultPocs");

            migrationBuilder.DropTable(
                name: "TaskDelegates");

            migrationBuilder.DropTable(
                name: "TaskFiles");

            migrationBuilder.DropTable(
                name: "TaskPocs");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "TasksHome");

            migrationBuilder.DropTable(
                name: "TaskUpdates");

            migrationBuilder.DropTable(
                name: "UserNames");

            migrationBuilder.DropTable(
                name: "V_TaskPocs");

            migrationBuilder.DropTable(
                name: "V_Tasks");
        }
    }
}
