using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskSystem.BusinessLogic.DTO;
using TaskSystem.BusinessLogic.Interface;
using TaskSystem.DTO.Admin;
using TaskSystem.DTO.User;

namespace TaskSystem.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private readonly IUserBusinessLogic _businessLogic;
        private readonly IMapper _mapper;

        public UserApiController(IUserBusinessLogic businessLogic, IMapper mapper)
        {
            _businessLogic = businessLogic;
            _mapper = mapper;
        }

        [HttpGet("{userName}")]
        public async Task<IActionResult> GetAdminUserByUserName(string userName)
        {
            try
            {
                var response = await _businessLogic.GetAllAdministratorByUserName(userName);
                var responseMapped = _mapper.Map<IEnumerable<BlAdministratorListResponse>, IEnumerable<AdministratorListResponse>>(response);

                return Ok(responseMapped);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getusers/{searchName}")]
        public async Task<IActionResult> GetUsers(string searchName)
        {
            try
            {
                var response = await _businessLogic.GetAllUsers(searchName);
                var responseMapped = _mapper.Map<IEnumerable<BlUsersResponse>, IEnumerable<UsersResponse>>(response);

                return Ok(responseMapped);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAdminUser([FromBody] AddUserAdminRequest request)
        {
            var requestMapped = _mapper.Map<AddUserAdminRequest, BlAddUserAdminRequest>(request);
            await _businessLogic.SaveUserAdmin(requestMapped);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAdminUser([FromBody] RemoveUserAdminRequest request)
        {
            var requestMapped = _mapper.Map<RemoveUserAdminRequest, BlRemoveUserAdminRequest>(request);
            await _businessLogic.RemoveUserAdmin(requestMapped);
            return Ok();
        }
    }
}