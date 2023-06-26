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
            var combo = await _context.Combo
                .Include(c => c.Curriculum)
                .FirstOrDefaultAsync(m => m.ComboId == 24);
            var comboS = _context.Combo_Subject.Where(p => p.ComboId == 24).ToList();
            foreach (var item in comboS)
            {
                _context.Combo_Subject.RemoveRange(comboS);
            }
            if (combo != null)
            {
                _context.Combo.Remove(combo);
            }
            var result = _context.SaveChanges();
            result.Should().BeGreaterThan(0);

        }

    }
}
