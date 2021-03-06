﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskSystem.DAL;

namespace TaskSystem.DAL.Migrations
{
    [DbContext(typeof(TaskSystemContext))]
    [Migration("20190309144916_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TaskSystem.DAL.Entities.TaskDefaultPocs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActualUser");

                    b.Property<string>("DefaultPoc");

                    b.HasKey("Id");

                    b.ToTable("TaskDefaultPocs");
                });

            modelBuilder.Entity("TaskSystem.DAL.Entities.TaskDelegates", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActualUser");

                    b.Property<string>("DelegateUser");

                    b.HasKey("Id");

                    b.ToTable("TaskDelegates");
                });

            modelBuilder.Entity("TaskSystem.DAL.Entities.TaskFiles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContentType");

                    b.Property<string>("FileAddedBy");

                    b.Property<DateTime?>("FileAddedDate");

                    b.Property<byte[]>("FileData");

                    b.Property<string>("FileName");

                    b.Property<int?>("FileSize");

                    b.Property<int?>("FileTaskId");

                    b.Property<int?>("FileUploadVersion");

                    b.HasKey("Id");

                    b.ToTable("TaskFiles");
                });

            modelBuilder.Entity("TaskSystem.DAL.Entities.TaskPocs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ParentUsername");

                    b.Property<DateTime>("PocdateAssigned");

                    b.Property<DateTime?>("PocdateClosed");

                    b.Property<DateTime?>("PocdateDue");

                    b.Property<bool?>("PocisFlagged");

                    b.Property<int?>("Poclevel");

                    b.Property<DateTime?>("PocpersonalDate");

                    b.Property<string>("PocpersonalNote");

                    b.Property<string>("Pocsort");

                    b.Property<int>("PoctaskId");

                    b.Property<string>("Pocusername");

                    b.HasKey("Id");

                    b.ToTable("TaskPocs");
                });

            modelBuilder.Entity("TaskSystem.DAL.Entities.Tasks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DeletionFlag");

                    b.Property<string>("Description");

                    b.Property<string>("FileNumber");

                    b.Property<string>("Orgcode");

                    b.Property<short>("Priority");

                    b.Property<int?>("RecurringId");

                    b.Property<string>("Requestor");

                    b.Property<string>("Status");

                    b.Property<string>("Subject");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("TaskSystem.DAL.Entities.TaskUpdates", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment");

                    b.Property<DateTime?>("DateUpdate");

                    b.Property<bool?>("Deleted");

                    b.Property<float?>("Labor");

                    b.Property<int?>("TaskId");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("TaskUpdates");
                });

            modelBuilder.Entity("TaskSystem.DAL.Entities.UserNames", b =>
                {
                    b.Property<string>("UserName")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("ActiveEmployee");

                    b.Property<DateTime?>("AdupdateDate");

                    b.Property<DateTime?>("AdwhenCreated");

                    b.Property<bool?>("AllowEditInfo");

                    b.Property<bool?>("AllowLogin");

                    b.Property<bool?>("DivLevel");

                    b.Property<string>("Email");

                    b.Property<bool?>("EmailWeekly");

                    b.Property<string>("FirstName");

                    b.Property<bool?>("GovEmp");

                    b.Property<string>("LastName");

                    b.Property<string>("OrgCode");

                    b.Property<string>("PalviewDefault");

                    b.Property<string>("Password");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("PrivLevel");

                    b.Property<bool?>("RedesignSuggReport");

                    b.Property<string>("ScriptPath");

                    b.HasKey("UserName");

                    b.ToTable("UserNames");
                });

            modelBuilder.Entity("TaskSystem.DAL.Entities.V_Tasks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DeletionFlag");

                    b.Property<string>("Description");

                    b.Property<string>("FileNumber");

                    b.Property<string>("Orgcode");

                    b.Property<short>("Priority");

                    b.Property<int?>("RecurringId");

                    b.Property<string>("Requestor");

                    b.Property<string>("Status");

                    b.Property<string>("Subject");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("V_Tasks");
                });

            modelBuilder.Entity("TaskSystem.DAL.SP_DTO.SP_GetTasksResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ParentUsername");

                    b.Property<string>("Requestor");

                    b.Property<string>("Status");

                    b.Property<string>("Subject");

                    b.Property<string>("TaskOwner");

                    b.Property<string>("TaskOwnerComments");

                    b.Property<DateTime>("TaskOwnerDate");

                    b.Property<DateTime>("TaskOwnerDuedate");

                    b.HasKey("Id");

                    b.ToTable("TasksHome");
                });

            modelBuilder.Entity("TaskSystem.DAL.V_TaskPocs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ParentUsername");

                    b.Property<DateTime>("PocdateAssigned");

                    b.Property<DateTime?>("PocdateClosed");

                    b.Property<DateTime?>("PocdateDue");

                    b.Property<bool?>("PocisFlagged");

                    b.Property<int?>("Poclevel");

                    b.Property<DateTime?>("PocpersonalDate");

                    b.Property<string>("PocpersonalNote");

                    b.Property<string>("Pocsort");

                    b.Property<int>("PoctaskId");

                    b.Property<string>("Pocusername");

                    b.HasKey("Id");

                    b.ToTable("V_TaskPocs");
                });
#pragma warning restore 612, 618
        }
    }
}
