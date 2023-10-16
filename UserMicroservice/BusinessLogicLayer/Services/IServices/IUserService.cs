using DataAccessLayer.Models.DTO;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.IServices
{
    public interface IUserService
    {
        public Task<List<PatientDto>> GetAll();
        public Task<PatientDto> GetByIdAsync(string id);
        public List<PatientDto> GetByUsername(string username);
        public Task<PatientDto?> Register(PatientRegisterDto user);
        public Task<LoginResponseDto> Login(LoginRequestDto loginReq);
        public string BulidToken(Patient user);
    }
}
