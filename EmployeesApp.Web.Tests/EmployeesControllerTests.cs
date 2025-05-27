using EmployeesApp.Web.Controllers;
using EmployeesApp.Application;
using Moq;
using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
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

                new Employee { Id = 1, Name = "Test company 1", Email = "London@www.se" },

                new Employee { Id = 2, Name = "Test company 2", Email = "London@www.se" },

                new Employee { Id = 3, Name = "Test company 3", Email = "Malmö@www.se" }

                ]);

        var controller = new EmployeesController(Service.Object);

        var result = controller.Index();

        Assert.IsType<ViewResult>(result);

    }

}
 
