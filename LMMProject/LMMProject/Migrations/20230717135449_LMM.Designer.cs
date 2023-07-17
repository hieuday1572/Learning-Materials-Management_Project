﻿// <auto-generated />
using System;
using LMMProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LMMProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230717135449_LMM")]
    partial class LMM
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LMMProject.Models.Account", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<short?>("Active")
                        .HasColumnType("smallint");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Gmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("Phone")
                        .HasColumnType("bigint");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserName");

                    b.HasIndex("RoleId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("LMMProject.Models.Assessment", b =>
                {
                    b.Property<int>("AssessmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssessmentId"), 1L, 1);

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Clo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompletionCriteria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GradingGuide")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KnowledgeSkill")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NoQuestion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Part")
                        .HasColumnType("int");

                    b.Property<string>("QuestionType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SyllabusId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Weight")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AssessmentId");

                    b.HasIndex("SyllabusId");

                    b.ToTable("Assessment");
                });

            modelBuilder.Entity("LMMProject.Models.Combo", b =>
                {
                    b.Property<int>("ComboId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComboId"), 1L, 1);

                    b.Property<string>("ComboNameEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ComboNameVn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CurriculumId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tag")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ComboId");

                    b.HasIndex("CurriculumId");

                    b.ToTable("Combo");
                });

            modelBuilder.Entity("LMMProject.Models.ComboSubject", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("ComboId")
                        .HasColumnType("int");

                    b.Property<string>("SubjectCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("ComboId");

                    b.HasIndex("SubjectCode");

                    b.ToTable("Combo_Subject");
                });

            modelBuilder.Entity("LMMProject.Models.Curriculum", b =>
                {
                    b.Property<int>("CurriculumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CurriculumId"), 1L, 1);

                    b.Property<string>("CurriculumCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DecisionNo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Decription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameVn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CurriculumId");

                    b.HasIndex("DecisionNo");

                    b.ToTable("Curriculum");
                });

            modelBuilder.Entity("LMMProject.Models.CurriculumSubject", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("CurriculumId")
                        .HasColumnType("int");

                    b.Property<int?>("Semester")
                        .HasColumnType("int");

                    b.Property<string>("SubjectCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("CurriculumId");

                    b.HasIndex("SubjectCode");

                    b.ToTable("Curriculum_Subject");
                });

            modelBuilder.Entity("LMMProject.Models.Decision", b =>
                {
                    b.Property<string>("DecisionNo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DecisionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DecisionNo");

                    b.ToTable("Decision");
                });

            modelBuilder.Entity("LMMProject.Models.Feedback", b =>
                {
                    b.Property<int>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeedbackId"), 1L, 1);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserNameFrom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserNameTo")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("FeedbackId");

                    b.HasIndex("UserNameTo");

                    b.ToTable("feedback");
                });

            modelBuilder.Entity("LMMProject.Models.Material", b =>
                {
                    b.Property<int>("MaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaterialId"), 1L, 1);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaterialDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublishedDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubjectCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaterialId");

                    b.HasIndex("SubjectCode");

                    b.ToTable("Material");
                });

            modelBuilder.Entity("LMMProject.Models.MaterialOfTeacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubjectCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TeacherUsername")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SubjectCode");

                    b.HasIndex("TeacherUsername");

                    b.ToTable("MaterialOfTeacher");
                });

            modelBuilder.Entity("LMMProject.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"), 1L, 1);

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("LMMProject.Models.Session", b =>
                {
                    b.Property<int>("SessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SessionId"), 1L, 1);

                    b.Property<string>("Constructivequestion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LearningTeachingType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentMaterials")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubjectCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SessionId");

                    b.HasIndex("SubjectCode");

                    b.ToTable("Session");
                });

            modelBuilder.Entity("LMMProject.Models.Status", b =>
                {
                    b.Property<short>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("StatusId"), 1L, 1);

                    b.Property<string>("StatusName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("LMMProject.Models.Subject", b =>
                {
                    b.Property<string>("SubjectCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PreRequisite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("StatusId")
                        .HasColumnType("smallint");

                    b.Property<string>("SubjectNameEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubjectNameVn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubjectCode");

                    b.HasIndex("StatusId");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("LMMProject.Models.Syllabus", b =>
                {
                    b.Property<int>("SyllabusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SyllabusId"), 1L, 1);

                    b.Property<string>("DecisionNo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DegreeLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("IsActive")
                        .HasColumnType("smallint");

                    b.Property<short?>("IsApproved")
                        .HasColumnType("smallint");

                    b.Property<int?>("MinAvgMarkToPass")
                        .HasColumnType("int");

                    b.Property<int?>("NoCredit")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PreRequisite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ScoringScale")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentTask")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubjectCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SyllabusNameEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SyllabusNameVn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TimeAllocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tool")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SyllabusId");

                    b.HasIndex("DecisionNo");

                    b.HasIndex("SubjectCode");

                    b.ToTable("Syllabus");
                });

            modelBuilder.Entity("LMMProject.Models.Account", b =>
                {
                    b.HasOne("LMMProject.Models.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("LMMProject.Models.Assessment", b =>
                {
                    b.HasOne("LMMProject.Models.Syllabus", "Syllabus")
                        .WithMany("Assessments")
                        .HasForeignKey("SyllabusId");

                    b.Navigation("Syllabus");
                });

            modelBuilder.Entity("LMMProject.Models.Combo", b =>
                {
                    b.HasOne("LMMProject.Models.Curriculum", "Curriculum")
                        .WithMany()
                        .HasForeignKey("CurriculumId");

                    b.Navigation("Curriculum");
                });

            modelBuilder.Entity("LMMProject.Models.ComboSubject", b =>
                {
                    b.HasOne("LMMProject.Models.Combo", "Combo")
                        .WithMany()
                        .HasForeignKey("ComboId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LMMProject.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Combo");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("LMMProject.Models.Curriculum", b =>
                {
                    b.HasOne("LMMProject.Models.Decision", "Decision")
                        .WithMany()
                        .HasForeignKey("DecisionNo");

                    b.Navigation("Decision");
                });

            modelBuilder.Entity("LMMProject.Models.CurriculumSubject", b =>
                {
                    b.HasOne("LMMProject.Models.Curriculum", "Curriculum")
                        .WithMany()
                        .HasForeignKey("CurriculumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LMMProject.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curriculum");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("LMMProject.Models.Feedback", b =>
                {
                    b.HasOne("LMMProject.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("UserNameTo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("LMMProject.Models.Material", b =>
                {
                    b.HasOne("LMMProject.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("LMMProject.Models.MaterialOfTeacher", b =>
                {
                    b.HasOne("LMMProject.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LMMProject.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("TeacherUsername")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("LMMProject.Models.Session", b =>
                {
                    b.HasOne("LMMProject.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectCode");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("LMMProject.Models.Subject", b =>
                {
                    b.HasOne("LMMProject.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("LMMProject.Models.Syllabus", b =>
                {
                    b.HasOne("LMMProject.Models.Decision", "Decision")
                        .WithMany()
                        .HasForeignKey("DecisionNo");

                    b.HasOne("LMMProject.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectCode");

                    b.Navigation("Decision");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("LMMProject.Models.Role", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("LMMProject.Models.Syllabus", b =>
                {
                    b.Navigation("Assessments");
                });
#pragma warning restore 612, 618
        }
    }
}
