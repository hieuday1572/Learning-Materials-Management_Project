//using FakeItEasy;
using FluentAssertions;
using LMMProject.Controllers;
using LMMProject.Data;
using LMMProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Controller
{
    public class ADMINCurriculaControllerTests
    {
        private readonly AppDbContext _context;
        private readonly ADMINCurriculaController _controller;
        public ADMINCurriculaControllerTests(AppDbContext context)
        {
            _context=context;
            _controller = new ADMINCurriculaController(context);
        }

        //[Fact]
        public async void ADMINCurriculaController_Index_ReturnSuccess()
        {
            var result =_controller.Index();
            result.Should().BeOfType<Task<IActionResult>>();
            List<Curriculum> c_result = _context.Curriculum.Include(c => c.Decision).ToList();
            Assert.True(c_result.Any());

        }
    }
}
