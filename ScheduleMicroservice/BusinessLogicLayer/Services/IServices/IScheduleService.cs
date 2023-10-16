using DataAccessLayer.Models.DTO;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.IServices
{
    public interface IScheduleService
    {
        public Task<List<ClinicServicesDto>> GetAll();
        public Task<List<ClinicServicesDto>> GetAllClinicsByService( string service);
        public Task<ClinicServicesDto> GetClinicById(string ClinicId);
        public Task<ClinicServicesDto> AddServices(ClinicServicesCreateDto clinicservices);

        public Task<List<ScheduleAppointmentDto>> GetAllScheduleAppointments();
        public Task<ScheduleAppointmentDto> AddScheduleAppointment(ScheduleAppointmentCreateDto scheduleAppointment);
        public Task<ScheduleAppointmentDto> GetScheduleAppointment(string Id);

    }
}
