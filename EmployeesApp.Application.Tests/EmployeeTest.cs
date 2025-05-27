using EmployeesApp.Application.Employees.Interfaces;
using Moq;
using EmployeesApp.Domain;
using EmployeesApp.Application.Employees.Services;
using EmployeesApp.Domain.Entities;


namespace EmployeesApp.Application.Tests
{
    public class EmployeeTest()

    {

        [Fact]
        public void Add_the_employee_AndInitialCapital()
        {

            var mockRepo = new Mock<IEmployeeRepository>();
            EmployeeService employeeService = new EmployeeService(mockRepo.Object);

            //arrange 

            var employee = new Employee
            {
                Id = 1,
                Name = "toto",
                Email = "TOTO@mail.com",
            };

            //act
            employeeService.Add(employee);

            //assert
            mockRepo.Verify(o => o.Add(It.Is<Employee>(e =>
                 e.Id == 1 &&
                 e.Name == "Toto" &&
                 e.Email == "toto@mail.com"
                 )), Times.Exactly(1));

        }

        [Fact]
        public void GetById_ValidId_ReturnsEmployee()
        {
            //arrange
            var employeeRepository = new Mock<IEmployeeRepository>();
            employeeRepository
                    .Setup(o => o.GetById(2))
                    .Returns(new Employee { Id = 2, Name = "Bibi", Email = "bibi@mail.com"});


            var employeeService = new EmployeeService(employeeRepository.Object);

            //act
            var result = employeeService.GetById(2);    

            //assert 
            Assert.NotNull(result);
            Assert.IsType<Employee>(result);
            Assert.Equal(2, result.Id);
            employeeRepository.Verify(o => o.GetById(2), Times.Exactly(1));
        }



    }
}
