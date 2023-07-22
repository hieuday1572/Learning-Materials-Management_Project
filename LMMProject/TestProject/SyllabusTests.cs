using FluentAssertions;
using LMMProject.Data;
using LMMProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject
{
    public class SyllabusTests
    {
        private AppDbContext _context;
        private int id;
        private readonly object _controller;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                               .UseInMemoryDatabase("flm")
                               .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                               .Options;
            _context = new AppDbContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _context.AddRange(
               new Syllabus
               {
                   SyllabusId = 1,

                   SyllabusNameVn = "PRN211",

                   SyllabusNameEn = "Basic Cross-Platform Application Programming With .NET",

                   SubjectCode = "PRN211",

                   NoCredit = 341,

                   DegreeLevel = "1",
                   TimeAllocation = "06-06-2023",
                   PreRequisite = "1",
                   Description = "1",
                   StudentTask = "1",
                   Tool = "1",
                   ScoringScale = 1,
                   DecisionNo = "1189/QÐ-ÐHFPT",                
                   Note = "1",
                   MinAvgMarkToPass = 1,
                   
               },
               new Syllabus
               {
                   SyllabusId = 2,

                   SyllabusNameVn = "MCO201m",

                   SyllabusNameEn = "Transmedia Storytelling",

                   SubjectCode = "MCO201m",

                   NoCredit = 341,

                   DegreeLevel = "2",
                   TimeAllocation = "06-06-2023",
                   PreRequisite = "2",
                   Description = "2",
                   StudentTask = "2",
                   Tool = "2",
                   ScoringScale = 1,
                   DecisionNo = "1189/QÐ-ÐHFPT",                   
                   Note = "1",
                   MinAvgMarkToPass = 1,
                   
               });
            _context.SaveChanges();
        }

        [Test]
        public void Syllabus_001_Create()
        {
            Syllabus syllabus = new Syllabus()
            {
                SyllabusId = 3,

                SyllabusNameVn = "DBI202",

                SyllabusNameEn = "DBI",

                SubjectCode = "DBI202",

                NoCredit = 341,

                DegreeLevel = "3",
                TimeAllocation = "06-06-2023",
                PreRequisite = "3",
                Description = "3",
                StudentTask = "3",
                Tool = "3",
                ScoringScale = 3,
                DecisionNo = "1189/QÐ-ÐHFPT",         
                Note = "3",
                MinAvgMarkToPass = 3,
               
            };
            _context.Add(syllabus);
            var result = _context.SaveChanges();
            result.Should().BeGreaterThan(0);
        }

        [Test]
        public async Task Syllabus_011_GetAsync()
        {

            var syllabus = await _context.Syllabus
                .Include(s => s.Decision)
                .Include(s => s.Assessments)
                .FirstOrDefaultAsync(m => m.SyllabusId == id);
        }

        [Test]
        public async Task Syllabus_101_UpdateAsync()
        {

            var syl = await _context.Syllabus.SingleOrDefaultAsync(s => s.SyllabusId == id);
            
            await _context.SaveChangesAsync();
        }

        [Test]
        public async Task Syllabus_101_DeleteAsync()
        {
            int id = 1; 

            var syllabus = await _context.Syllabus.Include(s => s.Assessments).FirstOrDefaultAsync(s => s.SyllabusId == id);

            if (syllabus != null && syllabus.Assessments != null)
            {
                _context.Assessment.RemoveRange(syllabus.Assessments);
            }

            _context.Syllabus.Remove(syllabus);
            await _context.SaveChangesAsync();


        }
    }
}
