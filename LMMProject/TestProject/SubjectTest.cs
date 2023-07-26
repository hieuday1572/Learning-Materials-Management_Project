using FluentAssertions;
using LMMProject.Data;
using LMMProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NUnit.Framework;
using System.Threading.Tasks;

namespace TestProject
{
    public class SubjectTests
    {
        private AppDbContext _context;

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
               new Subject
               {
                   SubjectCode = "MATH001",
                   SubjectNameVn = "Toán học 1",
                   SubjectNameEn = "Mathematics 1",
                   PreRequisite = "None",
                   StatusId = 1 // Assuming status ID exists in the Status table
               },
               new Subject
               {
                   SubjectCode = "PHYS001",
                   SubjectNameVn = "Vật lý 1",
                   SubjectNameEn = "Physics 1",
                   PreRequisite = "None",
                   StatusId = 1 // Assuming status ID exists in the Status table
               });
            _context.SaveChanges();
        }

        [Test]
        public void Subject_001_Create()
        {
            Subject subject = new Subject()
            {
                SubjectCode = "CHEM001",
                SubjectNameVn = "Hóa học 1",
                SubjectNameEn = "Chemistry 1",
                PreRequisite = "None",
                StatusId = 1 // Assuming status ID exists in the Status table
            };
            _context.Add(subject);
            var result = _context.SaveChanges();
            result.Should().BeGreaterThan(0);
        }

        [Test]
        public async Task Subject_010_GetAsync()
        {

            var subject = await _context.Subject
                .FirstOrDefaultAsync(m => m.SubjectCode == "MATH001");
            subject.Should().NotBeNull();
        }

        [Test]
        public async Task Subject_100_UpdateAsync()
        {

            var subject = await _context.Subject
                .FirstOrDefaultAsync(m => m.SubjectCode == "MATH001");
            subject.SubjectNameVn = "Toán học cơ bản";
            _context.Update(subject);
            var result = _context.SaveChanges();
            result.Should().BeGreaterThan(0);
        }

        [Test]
        public async Task Subject_101_DeleteAsync()
        {
            var subject = await _context.Subject
                .FirstOrDefaultAsync(m => m.SubjectCode == "MATH001");

            _context.Subject.Remove(subject);
            var result = _context.SaveChanges();
            result.Should().BeGreaterThan(0);
        }
    }
}
