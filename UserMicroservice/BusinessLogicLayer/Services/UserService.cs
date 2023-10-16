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
using Newtonsoft.Json;
using System.Reflection.Emit;
using System.Text.RegularExpressions;

namespace BusinessLogicLayer.Services
{
    public class UserService:IUserService
    {
        private readonly IMongoCollection<Patient> _users;
        private readonly ILogger<UserService> logger;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public UserService(IDataBaseSettings settings, ILogger<UserService> _logger,IMapper mapper, IConfiguration config)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _users = database.GetCollection<Patient>(settings.ClinicCollectionName);
            logger = _logger;
            _configuration = config;
            _mapper = mapper;
        }
        //Logic for get all users
        public async Task<List<PatientDto>> GetAll()
        {
            try
            {
                logger.LogInformation("Retreiving.....");
                var user = await _users.Find(s => true).ToListAsync();
                return _mapper.Map<List<PatientDto>>(user);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error occured while retrieving all registered users");
                throw;
            }
        }
        //Logic for get user by id
        public async Task<PatientDto> GetByIdAsync(string id)
        {
            try
            {
                var user = await _users.Find(s => s.Id == id).FirstOrDefaultAsync();
                if (user != null)
                {
                    logger.LogInformation("Retreiving....");
                    return _mapper.Map<PatientDto>(user);
                }
                return new PatientDto();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error occured while retrieving user by userid");
                throw;
            }
        }
        //Logic for search user by username
        public List<PatientDto> GetByUsername(string username)
        {
            try
            {
                var users =  _users.AsQueryable().Where(user => string.IsNullOrEmpty(username) ||
                 user.UserName.Contains(username));
                logger.LogInformation("Searching.....");
                return _mapper.Map<List<PatientDto>>(users.ToList());
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error occured while Searchimg for list of users by username");
                throw;
            }
        }
        //Logic for registering a user
        public async Task<PatientDto?> Register(PatientRegisterDto user)
        {
            
            try
            {

                Regex rg = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[!@#$%^&*()_+=;:<>|./?,-]).{8,15}$");
                logger.LogInformation("Registering.....");
                var emailcount =await  _users.CountDocumentsAsync(c => c.Email == user.Email);
                var loginidcount =await _users.CountDocumentsAsync(c => c.UserName == user.UserName);
                if (emailcount >= 1 || loginidcount >= 1)
                {

                    return null;
                }
                if (rg.IsMatch(user.Password)) {

                    Patient patient = new Patient()
                    {
                        Id = "",
                        Email = user.Email,
                        UserName = user.UserName,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Password = EncodePasswordToBase64(user.Password),
                        Confirm_Password = EncodePasswordToBase64(user.Confirm_Password),
                        DateOfBirth = user.DateOfBirth,
                        Gender = user.Gender,
                        PhoneNumber = user.PhoneNumber

                    };
                    await _users.InsertOneAsync(patient);
                    return _mapper.Map<PatientDto>(patient);
                }
                else
                {
                    logger.LogInformation("Password must be between 8 and 15 characters and contain atleast one uppercase,lowercase,number and special character.");

                    return new PatientDto();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error occured while registering a user");
                throw;
            }
        }
        //Logic for generating jwt token
        public string BulidToken(Patient user)
        {
            try
            {
                logger.LogInformation("Started generting the token......");
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:key").Value));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, "User"),
                new Claim("UserName",user.UserName.ToString())
            };
                var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                    _configuration["Jwt:Issuer"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);
                logger.LogInformation("Token generted Successfully");
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error occured while generating token");
                throw;
            }
        }
        //Logic for user login
        public async Task<LoginResponseDto> Login(LoginRequestDto loginReq)
        {
            try
            {

                var user = await _users.Find(c => c.UserName == loginReq.userName ).SingleOrDefaultAsync();
                logger.LogInformation("Login is in progress");
                if (user != null && DecodeFrom64(user.Password)==loginReq.password)
                {
                    var tokenString = BulidToken(user);
                    LoginResponseDto response = new LoginResponseDto()
                    {
                        id = user.Id,
                        userName = user.UserName,
                        email = user.Email,
                        token = tokenString
                    };
                    logger.LogInformation($" {user.UserName} Logged In Successfully");
                    return response; 
                }
                return new LoginResponseDto();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error occured while login");
                throw;
            }
        }
        //this function Convert to Encord your Password
        public static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
        //this function Convert to Decord your Password
        public string DecodeFrom64(string encodedData)
        {

            logger.LogInformation("Decoding the password in base64Encode");
            UTF8Encoding encoder = new UTF8Encoding();
            Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }
    }
}
