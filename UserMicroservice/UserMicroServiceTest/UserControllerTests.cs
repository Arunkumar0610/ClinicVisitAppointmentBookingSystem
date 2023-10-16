using BusinessLogicLayer.Services.IServices;
using DataAccessLayer.Models;
using DataAccessLayer.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using UserMicroservice.Controllers;

namespace UserMicroServiceTest
{
    public class UserControllerTests
    {

        private Mock<IUserService> mockService;
        private UsersController controller;
        private Mock<ILogger<UsersController>> mocklogger;

        [SetUp]
        public void Setup()
        {
            mocklogger=new Mock<ILogger<UsersController>>();
            mockService= new Mock<IUserService>();
            controller=new UsersController(mockService.Object, mocklogger.Object);
        }
        [Test]
        public async Task Test01_GetAll_ReturnsOKWithUsers()
        {
            //Arrange
            var exceptedUsers = new List<PatientDto> {
            new PatientDto()
            {
                Id="64f72a8eaa14a923fa360fc1",
                FirstName="ArunKumar",
                LastName="Yada1",
                Email="arun@gmail.com",
                UserName="Arun123",
                DateOfBirth=Convert.ToDateTime("2023-09-04T18:30:00.000+00:00"),
                Gender="Male",
                PhoneNumber="0987654321"

            },
            new PatientDto()
            {
                Id="64f9ac1c946cca048063d946",
                FirstName="Virat",
                LastName="Sinha",
                Email="virat@gmail.com",
                UserName="Virat123",
                DateOfBirth=Convert.ToDateTime("1999-08-22T18:30:00.000+00:00"),
                Gender="Male",
                PhoneNumber="9870654321"
            } };
            mockService.Setup(s=>s.GetAll()).ReturnsAsync(exceptedUsers);

            //Act
            var result = await controller.GetAll();

            //Assert
            //Assert.IsInstanceOf<OkObjectResult>(result.Result);
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult?.Value,Is.EqualTo(exceptedUsers));
        }
        [Test]
        public async Task Test02_GetAll_ReturnsNotFoundWithNoUsers()
        {
            //Arrange
            List<PatientDto> expectedUsers= new List<PatientDto>();
            mockService.Setup(s => s.GetAll()).ReturnsAsync(expectedUsers);

            //Act
            var result = await controller.GetAll();

            //Assert
            //Assert.IsInstanceOf<NotFoundObjectResult>(result.Result);
            Assert.That(result.Result, Is.InstanceOf<NotFoundObjectResult>());
            var notfoundResult = result.Result as NotFoundObjectResult; 
            //Assert.AreEqual("No Users Found", notfoundResult.Value.ToString());
            Assert.That(notfoundResult?.Value, Is.EqualTo("No Users Found"));
        }
        [Test]
        public async Task Test03_GetById_ReturnsOkWithUser()
        {
            //Arrange
            var userId = "64f72a8eaa14a923fa360fc1";
            var expectedUser = new PatientDto()
            {
                Id = "64f72a8eaa14a923fa360fc1",
                FirstName = "ArunKumar",
                LastName = "Yada1",
                Email = "arun@gmail.com",
                UserName = "Arun123",
                DateOfBirth = Convert.ToDateTime("2023-09-04T18:30:00.000+00:00"),
                Gender = "Male",
                PhoneNumber = "0987654321"
            };
            mockService.Setup(S=>S.GetByIdAsync(userId)).ReturnsAsync(expectedUser);

            //Act
            var result = await controller.GetById(userId);

            //Assert
            //Assert.IsInstanceOf<OkObjectResult>(result.Result);
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult=result.Result as OkObjectResult;
            //Assert.AreEqual(expectedUser, okResult.Value);
            Assert.That(okResult?.Value, Is.EqualTo(expectedUser));
        }
        [Test]
        public async Task Test04_GetById_ReturnsNotFoundUser()
        {
            //Arrange
            var userId = "64f72a8eaa14a923fa360f";
            var expectedUser = new PatientDto();
            mockService.Setup(S => S.GetByIdAsync(userId)).ReturnsAsync(expectedUser);

            //Act
            var result = await controller.GetById(userId);

            //Assert
            //Assert.IsInstanceOf<NotFoundObjectResult>(result.Result);
            Assert.That(result.Result, Is.InstanceOf<NotFoundObjectResult>());
            var notfoundResult = result.Result as NotFoundObjectResult;
            //Assert.AreEqual("User with Id="+userId+" not found", notfoundResult.Value);
            Assert.That(notfoundResult?.Value, Is.EqualTo("User with Id="+userId+" not found"));
        }
        [Test]
        public void Test05_GetByUserName_ReturnsOkWithUser()
        {
            //Arrange
            var userName = "Aru";
            var expectedUser = new List<PatientDto>{ new PatientDto()
                {
                    Id = "64f72a8eaa14a923fa360fc1",
                    FirstName = "ArunKumar",
                    LastName = "Yada1",
                    Email = "arun@gmail.com",
                    UserName = "Arun123",
                    DateOfBirth = Convert.ToDateTime("2023-09-04T18:30:00.000+00:00"),
                    Gender = "Male",
                    PhoneNumber = "0987654321"
                }
            };
            mockService.Setup(S => S.GetByUsername(userName)).Returns(expectedUser);

            //Act
            var result =  controller.GetByUsername(userName);

            //Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            //Assert.AreEqual(expectedUser, okResult.Value);
            Assert.That(okResult?.Value, Is.EqualTo(expectedUser));
        }
        [Test]
        public void Test06_GetByUserName_ReturnsNotFoundUser()
        {
            //Arrange
            string userName = "A";
            var expectedUser = new List<PatientDto>();
            mockService.Setup(S => S.GetByUsername(userName)).Returns(expectedUser);

            //Act
            var result = controller.GetByUsername(userName);

            //Assert
            //Assert.IsInstanceOf<NotFoundObjectResult>(result.Result);
            Assert.That(result.Result, Is.InstanceOf<NotFoundObjectResult>());
            var notfoundResult = result.Result as NotFoundObjectResult;
            //Assert.AreEqual("User with Id="+userId+" not found", notfoundResult.Value);
            Assert.That(notfoundResult?.Value, Is.EqualTo("No Users Found"));
        }
        [Test]
        public async Task Test07_Register_ReturnsCreatedAtActionWithUser()
        {
            //Arrange
            PatientRegisterDto patients = new PatientRegisterDto()
            {
                FirstName = "ArunKumar",
                LastName = "Yada1",
                Email = "arun@gmail.com",
                UserName = "Arun123",
                Password = "Arun123@",
                Confirm_Password = "Arun123@",
                DateOfBirth = Convert.ToDateTime("2023-09-04T18:30:00.000+00:00"),
                Gender = "Male",
                PhoneNumber = "0987654321"

            };
            PatientDto patient = new PatientDto()
            {
                Id= "64f72a8eaa14a923fa360fc1",
                FirstName = "ArunKumar",
                LastName = "Yada1",
                Email = "arun@gmail.com",
                UserName = "Arun123",
                DateOfBirth = Convert.ToDateTime("2023-09-04T18:30:00.000+00:00"),
                Gender = "Male",
                PhoneNumber = "0987654321"

            };
            mockService.Setup(x => x.Register(patients)).ReturnsAsync(patient);

            //Act
            var result =await controller.Register(patients);

            //Assert
            //Assert.IsInstanceOf<CreatedAtActionResult>(result.Result);
                Assert.That(result.Result, Is.InstanceOf<CreatedAtActionResult>());

                var createdAtActionResult = result.Result as CreatedAtActionResult;
                Assert.That(createdAtActionResult?.Value, Is.EqualTo(patient));

        }
        [Test]
        public async Task Test08_Register_ReturnsBadRequestWithPasswordInvalid()
        {
            //Arrange
            PatientRegisterDto patients = new PatientRegisterDto()
            {
                FirstName = "ArunKumar",
                LastName = "Yada1",
                Email = "arun@gmail.com",
                UserName = "Arun123",
                Password = "Arun123@",
                Confirm_Password = "Arun123@",
                DateOfBirth = Convert.ToDateTime("2023-09-04T18:30:00.000+00:00"),
                Gender = "Male",
                PhoneNumber = "0987654321"

            };
            PatientDto patient = new PatientDto()
            {
                Id = "",
                FirstName = "ArunKumar",
                LastName = "Yada1",
                Email = "arun@gmail.com",
                UserName = "Arun123",
                DateOfBirth = Convert.ToDateTime("2023-09-04T18:30:00.000+00:00"),
                Gender = "Male",
                PhoneNumber = "0987654321"

            };
            mockService.Setup(x => x.Register(patients)).ReturnsAsync(new PatientDto());

            //Act
            var result = await controller.Register(patients);

            //Assert
           // Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
            Assert.That(result.Result,Is.InstanceOf<BadRequestObjectResult>());
            var badRequestResult = result.Result as BadRequestObjectResult;
            string expected = "Password must be between 8 and 15 characters and contain atleast one uppercase,lowercase,number and special character.";
           // Assert.AreEqual(expected, badRequestResult.Value.ToString());
            Assert.That(badRequestResult?.Value, Is.EqualTo(expected));

        }
        [Test]
        public async Task Test09_login_ReturnsOkWithLoginResponse()
        {
            //Arrange
            LoginRequestDto credentials = new LoginRequestDto()
            {
                userName = "Arun123",
                password = "Arun123@"
            };
            LoginResponseDto response = new LoginResponseDto()
            {
                id = "64f72a8eaa14a923fa360fc1",
                email = "arun@gmail.com",
                token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJVc2VyIiwiVXNlck5hbWUiOiJBcnVuMTIzIiwiZXhwIjoxNjk0NDMwNTMzfQ.hARn-eFCgDD-m0_mPGhQLMDAyyoOonwYOdtkBgWnwAw",
                userName = "Arun123"
                
            };
            mockService.Setup(s=>s.Login(credentials)).ReturnsAsync(response);

            //Act
            var result =await controller.Login(credentials);

            //Assert
            //Assert.IsInstanceOf<OkObjectResult>(result);
            Assert.That(result,Is.InstanceOf<OkObjectResult>());
            var okResult = result as OkObjectResult;
           // Assert.AreEqual(response, okResult.Value);
            Assert.That(okResult?.Value,Is.EqualTo(response));
        }
        [Test]
        public async Task Test10_login_ReturnsUnauthorizedWithLoginResponse()
        {
            //Arrange
            LoginRequestDto credentials = new LoginRequestDto()
            {
                userName = "Arun123",
                password = "Arun123"
            };
            LoginResponseDto response = new LoginResponseDto();
            mockService.Setup(s => s.Login(credentials)).ReturnsAsync(response);

            //Act
            var result = await controller.Login(credentials);

            //Assert
            //Assert.IsInstanceOf<UnauthorizedObjectResult>(result);
            Assert.That(result,Is.InstanceOf<UnauthorizedObjectResult>());
            var unauthorizedObjectResult = result as UnauthorizedObjectResult;
           // Assert.AreEqual("Login_Id or password are incorrect", unauthorizedObjectResult.Value);
           Assert.That(unauthorizedObjectResult?.Value, Is.EqualTo("Username or password are incorrect"));
        }
        [Test]
        public async Task Test11_Register_ReturnsBadRequestWithUserAlreadyExists()
        {
            //Arrange
            PatientRegisterDto patients = new PatientRegisterDto()
            {
                FirstName = "ArunKumar",
                LastName = "Yada1",
                Email = "arun@gmail.com",
                UserName = "Arun123",
                Password = "Arun123@",
                Confirm_Password = "Arun123@",
                DateOfBirth = Convert.ToDateTime("2023-09-04T18:30:00.000+00:00"),
                Gender = "Male",
                PhoneNumber = "0987654321"

            };
            PatientDto patient = new PatientDto()
            {
                Id = "",
                FirstName = "ArunKumar",
                LastName = "Yada1",
                Email = "arun@gmail.com",
                UserName = "Arun123",
                DateOfBirth = Convert.ToDateTime("2023-09-04T18:30:00.000+00:00"),
                Gender = "Male",
                PhoneNumber = "0987654321"

            };
            PatientDto? patient1 = null;
            mockService.Setup(x => x.Register(patients)).ReturnsAsync(patient1);

            //Act
            var result = await controller.Register(patients);

            //Assert
            // Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
            Assert.That(result.Result, Is.InstanceOf<BadRequestObjectResult>());
            var badRequestResult = result.Result as BadRequestObjectResult;
            string expected = "UserName or Email already exists";
            // Assert.AreEqual(expected, badRequestResult.Value.ToString());
            Assert.That(badRequestResult?.Value, Is.EqualTo(expected));

        }
    }
}