using FluentAssertions;
using LMMProject.Data;
using LMMProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject
{
    public class CurriculumTests
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
               new Curriculum {
                   CurriculumId = 1,


                   CurriculumCode = "AL",

                   NameVn = "hhhhh",

                   NameEn = "eeeeeee",

                   Decription = "ghghghghghgh",


                   DecisionNo = "1095/QÐ-ÐHFPT",

               },
               new Curriculum
               {
                   CurriculumId = 2,


                   CurriculumCode = "AI",

                   NameVn = "hhghui",

                   NameEn = "uuuuu",

                   Decription = "ggggggggggg",


                   DecisionNo = "1095/QÐ-ÐHFPT",

               });
            _context.SaveChanges();
        }

        [Test]
        public void Curriculum_001_Create()
        {
            Curriculum curriculum = new Curriculum()
            {
                CurriculumId = 3,


                CurriculumCode = "SE",

                NameVn = "hhhhh",

                NameEn = "eeeeeee",

                Decription = "ghghghghghgh",


                DecisionNo = "1095/QÐ-ÐHFPT",

            };
            _context.Add(curriculum);
            var result = _context.SaveChanges();
            result.Should().BeGreaterThan(0);
        }

        [Test]
        public async Task Curriculum_010_GetAsync()
        {

            var curriculum = await _context.Curriculum
                .Include(c => c.Decision)
                .FirstOrDefaultAsync(m => m.CurriculumId == 1);
            curriculum.Should().NotBeNull();
        }

        [Test]
        public async Task Curriculum_100_UpdateAsync()
        {

            var curriculum = await _context.Curriculum
                .Include(c => c.Decision)
                .FirstOrDefaultAsync(m => m.CurriculumId == 1);
            curriculum.CurriculumCode = "SES";
            _context.Update(curriculum);
            var result = _context.SaveChanges();
            result.Should().BeGreaterThan(0);
        }

        [Test]
        public async Task Curriculum_101_DeleteAsync()
        {
            //DA SUA THEM DELETE 
            var curriculum = await _context.Curriculum
                .Include(c => c.Decision)
                .FirstOrDefaultAsync(m => m.CurriculumId == 1);
            var check = await _context.Curriculum_Subject.Where(p => p.CurriculumId == 1).ToListAsync();
            var combo = await _context.Combo.Where(p => p.CurriculumId == 1).ToListAsync();
            foreach (var item in combo)
            {
                var com_sub = await _context.Combo_Subject.Where(p => p.ComboId == item.ComboId).ToListAsync();
                _context.Combo_Subject.RemoveRange(com_sub);
            }
            _context.Combo.RemoveRange(combo);
            _context.Curriculum_Subject.RemoveRange(check);
            _context.Curriculum.Remove(curriculum);
            var result= _context.SaveChanges();
            result.Should().BeGreaterThan(0);

        }
    }
}