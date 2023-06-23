using FluentAssertions;
using LMMProject.Data;
using LMMProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class ComboTest
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
               new Combo
               {
                   ComboId = 24,


                   ComboNameVn = "abcdef",

                   ComboNameEn = "ghiklmn",

                   Note = "hbasgyasbb",

                   Tag = "iqiuieuuw",


                   CurriculumId=2
               },
               new Combo
               {
                   ComboId = 25,


                   ComboNameVn = "tangusada",

                   ComboNameEn = "aaaaaaa",

                   Note = "aaaa",

                   Tag = "ffffff",


                   CurriculumId=1
               });
            _context.SaveChanges();
        }
        [Test]
        public void Combo_Create()
        {
            Combo combo = new Combo()
            {
                ComboId = 99,


                ComboNameVn = "abcdeff",

                ComboNameEn = "ghiklmnn",

                Note = "hbasgyasbgb",

                Tag = "iqiuieuuwr",

                CurriculumId = 2
            };
            _context.Add(combo);
            var result = _context.SaveChanges();
            result.Should().BeGreaterThan(0);
        }
        [Test]
        public async Task Combo_GetAsync()
        {

            var combo = await _context.Combo
                .Include(c => c.Curriculum)
                .FirstOrDefaultAsync(m => m.ComboId == 24);
            combo.Should().NotBeNull();
        }
        [Test]
        public async Task Combo_UpdateAsync()
        {

            var combo = await _context.Combo
                .Include(c => c.Curriculum)
                .FirstOrDefaultAsync(m => m.ComboId == 24);
            combo.ComboNameVn = "abcdefghiklm";
            _context.Update(combo);
            var result = _context.SaveChanges();
            result.Should().BeGreaterThan(0);
        }
        [Test]
        public async Task Combo_DeleteAsync()
        {
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
            var result = _context.SaveChanges();
            result.Should().BeGreaterThan(0);

        }

    }
}
