using BusinessLogicLayer.Services.IServices;
using DataAccessLayer.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SchedulesMicroservice.Controllers;

namespace ScheduleMicroServiceTest
{
    public class UserControllerTests
    {

        private Mock<IScheduleService> mockService;
        private SchedulesController controller;
        private Mock<ILogger<SchedulesController>> mocklogger;

        [SetUp]
        public void Setup()
        {
            mocklogger = new Mock<ILogger<SchedulesController>>();
            mockService = new Mock<IScheduleService>();
            controller = new SchedulesController(mockService.Object, mocklogger.Object);
        }
        [Test]
        public async Task Test01_GetAllClinicServices_ReturnsOKWithClinics()
        {
            //Arrange
            var expectedUsers = new List<ClinicServicesDto> {
            new ClinicServicesDto()
            {
                Id="64fae89db566e510d93a41cf",
                ClinicName="Clinic 1",
                ClinicAddress="1234 NW Bobcat Lane, St. Robert, MO 65584-56781",
                Services=new List<string>()
                {
                    "Vaccination","Pedeatric Vaccine","Lab test","Fever and illness","Wound Care","General Visit","Diet","Injury","Trauma"
                }

            },
            new ClinicServicesDto()
            {
                Id="64fae8ccb566e510d93a41d0",
                ClinicName="Clinic 2",
                ClinicAddress="323 NW Bobcat Lane, St. Robert, MO 232325678",
                Services=new List<string>()
                {
                    "Vaccination","Pedeatric Vaccine","Lab test","Fever and illness","Wound Care","General Visit","Diet","Injury","Trauma"
                }
            } };
            mockService.Setup(s => s.GetAll()).ReturnsAsync(expectedUsers);

            //Act
            var result = await controller.GetAll();

            //Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult?.Value, Is.EqualTo(expectedUsers));
            //Assert.AreEqual(expectedUsers, okResult.Value);
        }
        [Test]
        public async Task Test02_GetAll_ReturnsNotFoundWithNoClinics()
        {
            //Arrange
            List<ClinicServicesDto> exceptedUsers = new List<ClinicServicesDto>();
            mockService.Setup(s => s.GetAll()).ReturnsAsync(exceptedUsers);

            //Act
            var result = await controller.GetAll();

            //Assert
            Assert.That(result.Result, Is.InstanceOf<NotFoundObjectResult>());
            var notfoundResult = result.Result as NotFoundObjectResult;
            Assert.That(notfoundResult?.Value, Is.EqualTo("No Clinics Found"));
            //Assert.AreEqual("No Clinics Found", notfoundResult.Value.ToString());
        }

        [Test]
        public async Task Test03_GetClinicById_ReturnsOkWithClinic()
        {
            //Arrange
            var userId = "64fae89db566e510d93a41cf";
            var expectedUser = new ClinicServicesDto()
            {
                Id = "64fae89db566e510d93a41cf",
                ClinicName = "Clinic 1",
                ClinicAddress = "1234 NW Bobcat Lane, St. Robert, MO 65584-56781",
                Services = new List<string>()
                {
                    "Vaccination","Pedeatric Vaccine","Lab test","Fever and illness","Wound Care","General Visit","Diet","Injury","Trauma"
                }
            };
            mockService.Setup(S => S.GetClinicById(userId)).ReturnsAsync(expectedUser);

            //Act
            var result = await controller.GetClinicById(userId);

            //Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult?.Value, Is.EqualTo(expectedUser));
           // Assert.AreEqual(expectedUser, okResult.Value);
        }
        [Test]
        public async Task Test04_GetClinicById_ReturnsNotFoundClinic()
        {
            //Arrange
            var userId = "64fae89db566e510d93a41cf";
            var expectedUser = new ClinicServicesDto();
            mockService.Setup(S => S.GetClinicById(userId)).ReturnsAsync(expectedUser);

            //Act
            var result = await controller.GetClinicById(userId);

            //Assert
            Assert.That(result.Result, Is.InstanceOf<NotFoundObjectResult>());
            var notFoundResult = result.Result as NotFoundObjectResult;
            Assert.That(notFoundResult?.Value,Is.EqualTo("No clinic Found"));
           // Assert.AreEqual("No clinic Found", notFoundResult.Value);
        }
        [Test]
        public async Task Test05_GetClinicsByService_ReturnsOkWithClinics()
        {
            //Arrange
            var userName = "Aru";
            var expectedUser = new List<ClinicServicesDto>{ new ClinicServicesDto()
                {
                    Id = "64fae89db566e510d93a41cf",
                    ClinicName = "Clinic 1",
                    ClinicAddress = "1234 NW Bobcat Lane, St. Robert, MO 65584-56781",
                    Services = new List<string>()
                    {
                        "Vaccination","Pedeatric Vaccine","Lab test","Fever and illness","Wound Care","General Visit","Diet","Injury","Trauma"
                    }
                }
            };
            mockService.Setup(S => S.GetAllClinicsByService(userName)).ReturnsAsync(expectedUser);

            //Act
            var result = await controller.GetClinicsByService(userName);

            //Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult?.Value,Is.EqualTo(expectedUser));
            //Assert.AreEqual(expectedUser, okResult.Value);
        }
        [Test]
        public async Task Test06_GetByUserName_ReturnsNotFoundUser()
        {
            //Arrange
            string userName = "A";
            var expectedUser = new List<ClinicServicesDto>();
            mockService.Setup(S => S.GetAllClinicsByService(userName)).ReturnsAsync(expectedUser);

            //Act
            var result = await controller.GetClinicsByService(userName);

            //Assert
            Assert.That(result.Result, Is.InstanceOf<NotFoundObjectResult>());
            var notFoundResult = result.Result as NotFoundObjectResult;
            Assert.That(notFoundResult?.Value, Is.EqualTo("No Clinics Found"));
            //Assert.AreEqual("No Clinics Found", notFoundResult.Value);
        }
        [Test]
        public async Task Test07_AddClinicAndServices_ReturnsCreatedAtActionWithClinic()
        {
            //Arrange
            ClinicServicesCreateDto patients = new ClinicServicesCreateDto()
            {
                ClinicName = "Clinic 1",
                ClinicAddress = "1234 NW Bobcat Lane, St. Robert, MO 65584-56781",
                Services = new List<string>()
                    {
                        "Vaccination","Pedeatric Vaccine","Lab test","Fever and illness","Wound Care","General Visit","Diet","Injury","Trauma"
                    }

            };
            ClinicServicesDto patient = new ClinicServicesDto()
            {
                Id = "64fae89db566e510d93a41cf",
                ClinicName = "Clinic 1",
                ClinicAddress = "1234 NW Bobcat Lane, St. Robert, MO 65584-56781",
                Services = new List<string>()
                {
                    "Vaccination","Pedeatric Vaccine","Lab test","Fever and illness","Wound Care","General Visit","Diet","Injury","Trauma"
                }

            };
            mockService.Setup(x => x.AddServices(patients)).ReturnsAsync(patient);

            //Act
            var result = await controller.AddClinicAndServices(patients);

            //Assert
            Assert.That(result.Result, Is.InstanceOf<CreatedAtActionResult>());
            var createdAtActionResult = result.Result as CreatedAtActionResult;
            Assert.That(createdAtActionResult?.Value, Is.EqualTo(patient));
        }
        [Test]
        public async Task Test08_AddClinicAndServices_ReturnsBadRequest()
        {
            //Arrange
            ClinicServicesCreateDto patients = new ClinicServicesCreateDto()
            {
                ClinicName = "Clinic 1",
                ClinicAddress = "1234 NW Bobcat Lane, St. Robert, MO 65584-56781",
                Services = new List<string>()
                    {
                        "Vaccination","Pedeatric Vaccine","Lab test","Fever and illness","Wound Care","General Visit","Diet","Injury","Trauma"
                    }

            };
            ClinicServicesDto patient = new ClinicServicesDto();
            mockService.Setup(x => x.AddServices(patients)).ReturnsAsync(patient);

            //Act
            var result = await controller.AddClinicAndServices(patients);

            //Assert
            Assert.That(result.Result, Is.InstanceOf<BadRequestObjectResult>());
            var badRequestResult = result.Result as BadRequestObjectResult;
            Assert.That(badRequestResult?.Value,Is.EqualTo("ClinicService already exists"));
        }

        [Test]
        public async Task Test09_GetAllScheduleAppointments_ReturnsOKWithAppointments()
        {
            //Arrange
            var expectedUsers = new List<ScheduleAppointmentDto> {
            new ScheduleAppointmentDto()
            {
                Id="64fae89db566e510d93a41cf",
                PatientuserName="Arun123",
                ClinicName="Clinic 1",
                ClinicAddress="1234 NW Bobcat Lane, St. Robert, MO 65584-56781",
                Service="Vaccination",
                DateTimeOfVisit=DateTime.Now,

            },
            new ScheduleAppointmentDto()
            {
                Id="64fae8ccb566e510d93a41d0",
                ClinicName="Clinic 2",
                ClinicAddress="323 NW Bobcat Lane, St. Robert, MO 232325678",
                Service="Vaccination",
                DateTimeOfVisit=DateTime.Now,
            } };
            mockService.Setup(s => s.GetAllScheduleAppointments()).ReturnsAsync(expectedUsers);

            //Act
            var result = await controller.GetAllAppointments();

            //Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult?.Value, Is.EqualTo(expectedUsers));
            //Assert.AreEqual(expectedUsers, okResult.Value);
        }
        [Test]
        public async Task Test10_GetAllScheduleAppointments_ReturnsNotFoundWithNoAppointments()
        {
            //Arrange
            List<ScheduleAppointmentDto> exceptedUsers = new List<ScheduleAppointmentDto>();
            mockService.Setup(s => s.GetAllScheduleAppointments()).ReturnsAsync(exceptedUsers);

            //Act
            var result = await controller.GetAllAppointments();

            //Assert
            Assert.That(result.Result, Is.InstanceOf<NotFoundObjectResult>());
            var notfoundResult = result.Result as NotFoundObjectResult;
            Assert.That(notfoundResult?.Value, Is.EqualTo("No appointments Found"));
        }

        [Test]
        public async Task Test11_GetAppointmentById_ReturnsOkWithAppointment()
        {
            //Arrange
            var userId = "64fae89db566e510d93a41cf";
            var expectedUser = new ScheduleAppointmentDto()
            {
                Id = "64fae89db566e510d93a41cf",
                ClinicName = "Clinic 1",
                ClinicAddress = "1234 NW Bobcat Lane, St. Robert, MO 65584-56781",
                Service = "Vaccination",
                DateTimeOfVisit=DateTime.Now,
            };
            mockService.Setup(S => S.GetScheduleAppointment(userId)).ReturnsAsync(expectedUser);

            //Act
            var result = await controller.GetAppointmentById(userId);

            //Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult?.Value, Is.EqualTo(expectedUser));
        }
        [Test]
        public async Task Test12_GetAppointmentById_ReturnsNotFoundAppointment()
        {
            //Arrange
            var userId = "64fae89db566e510d93a41cf";
            var expectedUser = new ScheduleAppointmentDto();
            mockService.Setup(S => S.GetScheduleAppointment(userId)).ReturnsAsync(expectedUser);

            //Act
            var result = await controller.GetAppointmentById(userId);

            //Assert
            Assert.That(result.Result, Is.InstanceOf<NotFoundObjectResult>());
            var notFoundResult = result.Result as NotFoundObjectResult;
            Assert.That(notFoundResult?.Value, Is.EqualTo("No appointment Found"));
        }

        [Test]
        public async Task Test13_AddScheduleAppointment_ReturnsCreatedAtActionWithClinic()
        {
            //Arrange
            ScheduleAppointmentCreateDto patients = new ScheduleAppointmentCreateDto()
            {
                PatientuserName = "Arun123",
                ClinicName = "Clinic 1",
                ClinicAddress = "1234 NW Bobcat Lane, St. Robert, MO 65584-56781",
                Service = "Vaccination",
                DateTimeOfVisit = DateTime.Now,

            };
            ScheduleAppointmentDto patient = new ScheduleAppointmentDto()
            {
                Id = "64fae89db566e510d93a41cf",
                PatientuserName = "Arun123",
                ClinicName = "Clinic 1",
                ClinicAddress = "1234 NW Bobcat Lane, St. Robert, MO 65584-56781",
                Service = "Vaccination",
                DateTimeOfVisit = DateTime.Now,

            };
            mockService.Setup(x => x.AddScheduleAppointment(patients)).ReturnsAsync(patient);

            //Act
            var result = await controller.AddScheduleAppointment(patients);

            //Assert
            Assert.That(result.Result, Is.InstanceOf<CreatedAtActionResult>());
            var createdAtActionResult = result.Result as CreatedAtActionResult;
            Assert.That(createdAtActionResult?.Value, Is.EqualTo(patient));
        }
        [Test]
        public async Task Test14_AddScheduleAppointment_Returns_Select_DateTimeOfVisit_GreaterThan_CurrentDateTime()
        {
            //Arrange
            ScheduleAppointmentCreateDto patients = new ScheduleAppointmentCreateDto()
            {
                PatientuserName = "Arun123",
                ClinicName = "Clinic 1",
                ClinicAddress = "1234 NW Bobcat Lane, St. Robert, MO 65584-56781",
                Service = "Vaccination",
                DateTimeOfVisit =new  DateTime(2023,09,12,00,00,00)

            };
            mockService.Setup(x => x.AddScheduleAppointment(patients)).ReturnsAsync(new ScheduleAppointmentDto());

            //Act
            var result = await controller.AddScheduleAppointment(patients);

            //Assert
            Assert.That(result.Result, Is.InstanceOf<BadRequestObjectResult>());
            var badRequestResult = result.Result as BadRequestObjectResult;
            Assert.That(badRequestResult?.Value, Is.EqualTo("Selected Date & Time should be more than Current Date & Time"));
        }
    }
}