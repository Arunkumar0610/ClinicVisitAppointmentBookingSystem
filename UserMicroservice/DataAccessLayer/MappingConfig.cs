using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Models.DTO;

namespace DataAccessLayer
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
            CreateMap<Patient, PatientDto>().ReverseMap();
            CreateMap<Patient, PatientRegisterDto>().ReverseMap();
            CreateMap<PatientDto, PatientRegisterDto>().ReverseMap();
        }
    }
}

