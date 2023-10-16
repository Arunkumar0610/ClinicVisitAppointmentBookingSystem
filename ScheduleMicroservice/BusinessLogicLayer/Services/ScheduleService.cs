using AutoMapper;
using BusinessLogicLayer.Services.IServices;
using DataAccessLayer.DataBase;
using DataAccessLayer.Models;
using DataAccessLayer.Models.DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ZstdSharp.Unsafe;

namespace BusinessLogicLayer.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IMongoCollection<ClinicServices> _clinicServices;
        private readonly IMongoCollection<ScheduleAppointment> _scheduleAppointment;
        private readonly ILogger<ScheduleService> logger;
        private readonly IMapper _mapper;
        public ScheduleService(IDataBaseSettings settings, ILogger<ScheduleService> _logger, IMapper mapper)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _clinicServices = database.GetCollection<ClinicServices>(settings.ClinicCollectionName1);
            _scheduleAppointment = database.GetCollection<ScheduleAppointment>(settings.ClinicCollectionName2);
            logger = _logger;
            _mapper = mapper;
        }
        public async Task<List<ClinicServicesDto>> GetAll()
        {
            try
            {
                logger.LogInformation("Retreiving...");
                var cliniclist = await _clinicServices.Find(s => true).ToListAsync();
                return _mapper.Map<List<ClinicServicesDto>>(cliniclist);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error occured while retreiving all ClinicServices");
                throw;
            }
        }
        public async Task<ClinicServicesDto> GetClinicById(string ClinicId)
        {
            try
            {
                logger.LogInformation("Retreiving...");
                var appointment = await _clinicServices.Find(s => s.Id == ClinicId).FirstOrDefaultAsync();
                if (appointment == null)
                {
                    return new ClinicServicesDto();
                }
                return _mapper.Map<ClinicServicesDto>(appointment);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error occured while retreiving ClinicServices by Id");
                throw;
            }
        }
        public async Task<List<ClinicServicesDto>> GetAllClinicsByService(string service)
        {
            try
            {
                logger.LogInformation("Retreiving...");
                var cliniclist = await _clinicServices.Find(s => s.Services.Contains(service)).ToListAsync();
                if (cliniclist.Count > 0)
                {
                    return _mapper.Map<List<ClinicServicesDto>>(cliniclist);
                }
                return new List<ClinicServicesDto>();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error occured while searching ClinicServices by Services");
                throw;
            }
        }
        public async Task<ClinicServicesDto> AddServices(ClinicServicesCreateDto clinicservices)
        {
            try
            {
                logger.LogInformation("Adding...");
                var count = await _clinicServices.Find(s => s.ClinicName == clinicservices.ClinicName).CountDocumentsAsync();
                if (count == 0)
                {
                    ClinicServices item = new ClinicServices()
                    {
                        Id = "",
                        ClinicName = clinicservices.ClinicName,
                        ClinicAddress = clinicservices.ClinicAddress,
                        Services = clinicservices.Services
                    };
                    await _clinicServices.InsertOneAsync(item);
                    return _mapper.Map<ClinicServicesDto>(item);
                }
                return new ClinicServicesDto();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error occured while Adding ClinicServices");
                throw;
            }

        }
        public async Task<List<ScheduleAppointmentDto>> GetAllScheduleAppointments()
        {
            try
            {
                logger.LogInformation("Retreiving...");
                var appointmentslist = await _scheduleAppointment.Find(s => true).ToListAsync();
                return _mapper.Map<List<ScheduleAppointmentDto>>(appointmentslist);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error occured while retreiving all Scheduled Appointments");
                throw;
            }
        }
        public async Task<ScheduleAppointmentDto> AddScheduleAppointment(ScheduleAppointmentCreateDto scheduleAppointment)
        {
            try
            {
                logger.LogInformation("Scheduling...");
                ScheduleAppointment schedule = new ScheduleAppointment()
                {
                    Id = "",
                    PatientuserName = scheduleAppointment.PatientuserName,
                    ClinicName = scheduleAppointment.ClinicName,
                    ClinicAddress = scheduleAppointment.ClinicAddress,
                    Service = scheduleAppointment.Service,
                    DateTimeOfVisit = scheduleAppointment.DateTimeOfVisit
                };
                if (scheduleAppointment.DateTimeOfVisit >= DateTime.Now)
                {
                    await _scheduleAppointment.InsertOneAsync(schedule);
                    return _mapper.Map<ScheduleAppointmentDto>(schedule);
                }
                return new ScheduleAppointmentDto();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error occured while scheduling a appointment");
                throw;
            }
        }
        public async Task<ScheduleAppointmentDto> GetScheduleAppointment(string Id)
        {
            try
            {
                logger.LogInformation("Retreiving...");
                var appointment = await _scheduleAppointment.Find(s => s.Id == Id).FirstOrDefaultAsync();
                if (appointment == null)
                {
                    return new ScheduleAppointmentDto();
                }
                return _mapper.Map<ScheduleAppointmentDto>(appointment);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error occured while retreiving ScheduledAppointment by Id");
                throw;
            }

        }
    }
}
