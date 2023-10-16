using BusinessLogicLayer.Services.IServices;
using DataAccessLayer.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SchedulesMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;
        private readonly ILogger<SchedulesController> logger;
        public SchedulesController(IScheduleService Repo, ILogger<SchedulesController> logger)
        {
            _scheduleService = Repo;
            this.logger = logger;
        }

        [HttpGet("clinics/all")]
        public async Task<ActionResult<IEnumerable<ClinicServicesDto>>> GetAll()
        {
            logger.LogInformation("Reteriving all  clinics");
            var clinics = await _scheduleService.GetAll();
            if (clinics.Count == 0)
            {
                logger.LogError("No Clincs Found");
                return NotFound("No Clinics Found");
            }
            logger.LogInformation("Reterived all clinics Successfully");
            return Ok(clinics);
        }
        [HttpGet("GetClincById", Name = "GetClinicById")]
        public async Task<ActionResult<ClinicServicesDto>> GetClinicById(string Id)
        {

            logger.LogInformation($"Reteriving a clinic with Id - { Id}");
            var clinics = await _scheduleService.GetClinicById(Id);
            if (clinics.ClinicName == null)
            {
                logger.LogError("No clinic Found");
                return NotFound("No clinic Found");
            }
            logger.LogInformation($"Reterived  clinic With Id - { Id } Successfully");
            return Ok(clinics);
        }
        [HttpGet("clinics/GetClinicsByService")]
        public async Task<ActionResult<IEnumerable<ClinicServicesDto>>> GetClinicsByService(string service)
        {
            logger.LogInformation("Reteriving all clinics with service - " + service);
            var clinics = await _scheduleService.GetAllClinicsByService(service);
            if (clinics.Count == 0)
            {
                logger.LogError("No Clincs Found");
                return NotFound("No Clinics Found");
            }
            logger.LogInformation($"Reterived all clinics With service - { service } Successfully");
            return Ok(clinics);
        }
        [HttpPost("AddClinics")]
        public async Task<ActionResult<ClinicServicesDto>> AddClinicAndServices(ClinicServicesCreateDto clinicServices)
        {
            logger.LogInformation("Add a ClinicService");
            var item = await _scheduleService.AddServices(clinicServices);
            if (item.ClinicName==null)
            {
                logger.LogError("ClinicService Already exists");
                return BadRequest("ClinicService already exists");
            }
            logger.LogInformation("ClinicService Added Successfully");
            return CreatedAtAction(nameof(GetClinicById), new { id = item.Id }, item);
        }
        [HttpPost("ScheduleAppointment")]
        public async Task<ActionResult<ScheduleAppointmentDto>> AddScheduleAppointment(ScheduleAppointmentCreateDto appointment)
        {
            logger.LogInformation("Add a appointment");
            var item = await _scheduleService.AddScheduleAppointment(appointment);
            if (item.ClinicName==null)
            {
                logger.LogError("Selected Date & Time should be more than Current Date & Time");
                return BadRequest("Selected Date & Time should be more than Current Date & Time");
            }
            logger.LogInformation("Scheduled Appointment Successfully");
            return CreatedAtAction(nameof(GetAppointmentById), new { id = item.Id }, item);
        }
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ScheduleAppointmentDto>>> GetAllAppointments()
        {
            logger.LogInformation("Reteriving all  appointments");
            var appointments = await _scheduleService.GetAllScheduleAppointments();
            if (appointments.Count == 0)
            {
                logger.LogError("No appointments Found");
                return NotFound("No appointments Found");
            }
            logger.LogInformation("Reterived all appointments Successfully");
            return Ok(appointments);
        }
        [HttpGet("GetById",Name ="GetById")]
        public async Task<ActionResult<ScheduleAppointmentDto>> GetAppointmentById(string Id)
        {
            logger.LogInformation($"Reteriving a appointment with Id - { Id}");
            var clinics = await _scheduleService.GetScheduleAppointment(Id);
            if (clinics.ClinicName==null)
            {
                logger.LogError("No appointment Found");
                return NotFound("No appointment Found");
            }
            logger.LogInformation($"Reterived  appointment With Id - {Id}  Successfully");
            return Ok(clinics);
        }
    }
}
