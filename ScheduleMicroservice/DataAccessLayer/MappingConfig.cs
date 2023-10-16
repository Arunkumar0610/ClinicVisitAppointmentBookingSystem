using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Models.DTO;

namespace DataAccessLayer
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
            CreateMap<ClinicServices, ClinicServicesDto>().ReverseMap();
            CreateMap<ClinicServices, ClinicServicesCreateDto>().ReverseMap();
            CreateMap<ClinicServicesDto, ClinicServicesCreateDto>().ReverseMap();
            CreateMap<ScheduleAppointment, ScheduleAppointmentDto>().ReverseMap();
            CreateMap<ScheduleAppointment, ScheduleAppointmentCreateDto>().ReverseMap();
            CreateMap<ScheduleAppointmentDto, ScheduleAppointmentCreateDto>().ReverseMap();

        }
    }
}

