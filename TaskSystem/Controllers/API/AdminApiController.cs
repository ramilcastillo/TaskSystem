using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskSystem.BusinessLogic.DTO;
using TaskSystem.BusinessLogic.Interface;
using TaskSystem.DTO.Admin;

namespace TaskSystem.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminApiController : ControllerBase
    {
        private readonly IAdminBusinessLogic _businessLogic;
        private readonly IMapper _mapper;
        public AdminApiController(IAdminBusinessLogic businessLogic, IMapper mapper)
        {
            _businessLogic = businessLogic;
            _mapper = mapper;
        }

        [HttpGet("{userName}")]
        public async Task<IActionResult> TaskOwnerByUserName(string userName)
        {
            try
            {
                var result = await _businessLogic.GetTaskOwnerListByUsername(userName);
                var resultMapped = _mapper.Map<IEnumerable<BlAdminTaskOwnerResponse>, IEnumerable<TaskPOCsResponse>>(result);

                return Ok(resultMapped);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }       
        }

        [HttpPost]
        public async Task<IActionResult> AddTaskOwner([FromBody] AddUserAdminRequest request)
        {
            try
            {
                var requestMapped = _mapper.Map<AddUserAdminRequest, BlAddUserAdminRequest>(request);
                await _businessLogic.AddTaskOwner(requestMapped);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}