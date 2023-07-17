using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMMProject.Migrations
{
    public partial class LMM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Decision",
                columns: table => new
                {
                    DecisionNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DecisionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decision", x => x.DecisionNo);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "Curriculum",
                columns: table => new
                {
                    CurriculumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurriculumCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameVn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Decription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DecisionNo = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curriculum", x => x.CurriculumId);
                    table.ForeignKey(
                        name: "FK_Curriculum_Decision_DecisionNo",
                        column: x => x.DecisionNo,
                        principalTable: "Decision",
                        principalColumn: "DecisionNo");
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<long>(type: "bigint", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    Gmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.UserName);
                    table.ForeignKey(
                        name: "FK_Account_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    SubjectCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubjectNameVn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreRequisite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusId = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.SubjectCode);
                    table.ForeignKey(
                        name: "FK_Subject_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Combo",
                columns: table => new
                {
                    ComboId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComboNameVn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComboNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurriculumId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combo", x => x.ComboId);
                    table.ForeignKey(
                        name: "FK_Combo_Curriculum_CurriculumId",
                        column: x => x.CurriculumId,
                        principalTable: "Curriculum",
                        principalColumn: "CurriculumId");
                });

            migrationBuilder.CreateTable(
                name: "feedback",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserNameTo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserNameFrom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedback", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FK_feedback_Account_UserNameTo",
                        column: x => x.UserNameTo,
                        principalTable: "Account",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Curriculum_Subject",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurriculumId = table.Column<int>(type: "int", nullable: false),
                    SubjectCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curriculum_Subject", x => x.id);
                    table.ForeignKey(
                        name: "FK_Curriculum_Subject_Curriculum_CurriculumId",
                        column: x => x.CurriculumId,
                        principalTable: "Curriculum",
                        principalColumn: "CurriculumId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Curriculum_Subject_Subject_SubjectCode",
                        column: x => x.SubjectCode,
                        principalTable: "Subject",
                        principalColumn: "SubjectCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectCode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.MaterialId);
                    table.ForeignKey(
                        name: "FK_Material_Subject_SubjectCode",
                        column: x => x.SubjectCode,
                        principalTable: "Subject",
                        principalColumn: "SubjectCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialOfTeacher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherUsername = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubjectCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialOfTeacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialOfTeacher_Account_TeacherUsername",
                        column: x => x.TeacherUsername,
                        principalTable: "Account",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialOfTeacher_Subject_SubjectCode",
                        column: x => x.SubjectCode,
                        principalTable: "Subject",
                        principalColumn: "SubjectCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    SessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LearningTeachingType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentMaterials = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Constructivequestion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectCode = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.SessionId);
                    table.ForeignKey(
                        name: "FK_Session_Subject_SubjectCode",
                        column: x => x.SubjectCode,
                        principalTable: "Subject",
                        principalColumn: "SubjectCode");
                });

            migrationBuilder.CreateTable(
                name: "Syllabus",
                columns: table => new
                {
                    SyllabusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SyllabusNameVn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SyllabusNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NoCredit = table.Column<int>(type: "int", nullable: true),
                    DegreeLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeAllocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreRequisite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentTask = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tool = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScoringScale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DecisionNo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsApproved = table.Column<short>(type: "smallint", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinAvgMarkToPass = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Syllabus", x => x.SyllabusId);
                    table.ForeignKey(
                        name: "FK_Syllabus_Decision_DecisionNo",
                        column: x => x.DecisionNo,
                        principalTable: "Decision",
                        principalColumn: "DecisionNo");
                    table.ForeignKey(
                        name: "FK_Syllabus_Subject_SubjectCode",
                        column: x => x.SubjectCode,
                        principalTable: "Subject",
                        principalColumn: "SubjectCode");
                });

            migrationBuilder.CreateTable(
                name: "Combo_Subject",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComboId = table.Column<int>(type: "int", nullable: false),
                    SubjectCode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combo_Subject", x => x.id);
                    table.ForeignKey(
                        name: "FK_Combo_Subject_Combo_ComboId",
                        column: x => x.ComboId,
                        principalTable: "Combo",
                        principalColumn: "ComboId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Combo_Subject_Subject_SubjectCode",
                        column: x => x.SubjectCode,
                        principalTable: "Subject",
                        principalColumn: "SubjectCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assessment",
                columns: table => new
                {
                    AssessmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Part = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompletionCriteria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Clo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoQuestion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KnowledgeSkill = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GradingGuide = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SyllabusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assessment", x => x.AssessmentId);
                    table.ForeignKey(
                        name: "FK_Assessment_Syllabus_SyllabusId",
                        column: x => x.SyllabusId,
                        principalTable: "Syllabus",
                        principalColumn: "SyllabusId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_RoleId",
                table: "Account",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Assessment_SyllabusId",
                table: "Assessment",
                column: "SyllabusId");

            migrationBuilder.CreateIndex(
                name: "IX_Combo_CurriculumId",
                table: "Combo",
                column: "CurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_Combo_Subject_ComboId",
                table: "Combo_Subject",
                column: "ComboId");

            migrationBuilder.CreateIndex(
                name: "IX_Combo_Subject_SubjectCode",
                table: "Combo_Subject",
                column: "SubjectCode");

            migrationBuilder.CreateIndex(
                name: "IX_Curriculum_DecisionNo",
                table: "Curriculum",
                column: "DecisionNo");

            migrationBuilder.CreateIndex(
                name: "IX_Curriculum_Subject_CurriculumId",
                table: "Curriculum_Subject",
                column: "CurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_Curriculum_Subject_SubjectCode",
                table: "Curriculum_Subject",
                column: "SubjectCode");

            migrationBuilder.CreateIndex(
                name: "IX_feedback_UserNameTo",
                table: "feedback",
                column: "UserNameTo");

            migrationBuilder.CreateIndex(
                name: "IX_Material_SubjectCode",
                table: "Material",
                column: "SubjectCode");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialOfTeacher_SubjectCode",
                table: "MaterialOfTeacher",
                column: "SubjectCode");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialOfTeacher_TeacherUsername",
                table: "MaterialOfTeacher",
                column: "TeacherUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Session_SubjectCode",
                table: "Session",
                column: "SubjectCode");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_StatusId",
                table: "Subject",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Syllabus_DecisionNo",
                table: "Syllabus",
                column: "DecisionNo");

            migrationBuilder.CreateIndex(
                name: "IX_Syllabus_SubjectCode",
                table: "Syllabus",
                column: "SubjectCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assessment");

            migrationBuilder.DropTable(
                name: "Combo_Subject");

            migrationBuilder.DropTable(
                name: "Curriculum_Subject");

            migrationBuilder.DropTable(
                name: "feedback");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "MaterialOfTeacher");

            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.DropTable(
                name: "Syllabus");

            migrationBuilder.DropTable(
                name: "Combo");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Curriculum");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Decision");
        }
    }
}
