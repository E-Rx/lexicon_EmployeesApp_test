using EmployeesApp.Web.Controllers;
using EmployeesApp.Application;
using Moq;
using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using EmployeesApp.Web.Views.Employees;
using System.ComponentModel.DataAnnotations;
namespace EmployeesApp.Web.Tests;

public class EmployeesControllerTests
{


    [Fact]

    public void Index_NoParams_ReturnsViewResult()
    {
        var Service = new Mock<IEmployeeService>();
        Service
            .Setup(o => o.GetAll())
            .Returns([

                new Employee { Id = 1, Name = "Employee1", Email = "employee1@www.se" },

                new Employee { Id = 2, Name = "Employee2", Email = "employee2@www.se" },

                new Employee { Id = 3, Name = "Employee3", Email = "employee3@www.se" }


                ]);

        var controller = new EmployeesController(Service.Object);

        var result = controller.Index();

        Assert.IsType<ViewResult>(result);

    }

    [Fact]
    public void Create_HttpGet_ReturnsViewResult()
    {
        var service = new Mock<IEmployeeService>();
        var controller = new EmployeesController(service.Object);
        var result = controller.Create();
        Assert.IsType<ViewResult>(result);
    }

    [Fact]
    public void Create_HttpPost_ReturnsViewResult()
    {
        //var service = new Mock<IEmployeeService>();
        //service
        //    .Setup(o => o.GetAll())
        //    .Returns([
        //        new Employee { Id = 1, Name="Testname", Email="test@email.com"}
        //        ]);
        //var controller = new EmployeesController (service.Object);
        //var result = controller.Create();
        var model = new CreateVM
        {
            Name = "Test",
            Email = "test@email.com",
            BotCheck = 4
        };

        var context = new ValidationContext(model);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(model, context, results, validateAllProperties: true);
        Assert.True(isValid);
    }


    [Fact]
    public void Details_ReturnsViewResult()
    {
        var service = new Mock<IEmployeeService>();
        service
            .Setup(o => o.GetById(1))
            .Returns( new Employee { Id = 1, Name="Testname", Email="test@email.com"});

        var controller = new EmployeesController(service.Object);
        var result = controller.Details(1);
        Assert.IsType<ViewResult>(result);
        
        
    }
}
 
