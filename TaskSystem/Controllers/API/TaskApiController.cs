using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TaskSystem.BusinessLogic.DTO;
using TaskSystem.BusinessLogic.Interface;
using TaskSystem.DTO.Task;

namespace TaskSystem.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaskApiController : ControllerBase
    {
        private readonly ITaskBusinessLogic _businessLogic;
        private readonly IMapper _mapper;
        public TaskApiController(ITaskBusinessLogic businessLogic, IMapper mapper)
        {
            _businessLogic = businessLogic;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile([FromBody] UploadRequest request)
        {
            try
            {
                var blRequest = _mapper.Map<UploadRequest, BlUploadFileRequest>(request);
                await _businessLogic.UploadFile(blRequest);

                return Ok(request);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskRequest request)
        {
            try
            {
                var blRequest = _mapper.Map<CreateTaskRequest, BL_TaskCreateRequest>(request);
                await _businessLogic.CreateAsync(blRequest);
                return Ok();
            }
            catch (Exception x)
            {
                return BadRequest(x.Message);
            }
        }

        [HttpGet("{userName}/{taskSatus}")]
        public async Task<IActionResult> GetTasksHome(string userName, string taskSatus, int DaysNumber)
        {
            try
            {
                var blResponse = await _businessLogic.GetTasksForUser(userName, taskSatus);
                var blRequest = _mapper.Map<IEnumerable<BL_TaskListResponseDetail>, IEnumerable<TaskListResponseDetail>>(blResponse);

                return Ok(blRequest);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/{Pocusername}")]
        public async Task<IActionResult> GetTaskById(int id, string Pocusername)
        {
            try
            {
                var blResponse = await _businessLogic.GetTaskById(id, Pocusername);
                var blRequest = _mapper.Map<BlTaskDetailResponse, TaskDetailResponse>(blResponse);

                return Ok(blRequest);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCommentAsync([FromBody] TaskCommentDetailRequest request)
        {
            try
            {
                var blRequestMapped = _mapper.Map<TaskCommentDetailRequest, BlTaskCommentDetailRequest>(request);
                await _businessLogic.CreateCommentAsync(blRequestMapped);
                return Ok(request);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePOCAsync([FromBody] IEnumerable<TaskPOCDetailRequest> request)
        {
            try
            {
                var blRequestMapped = _mapper.Map<IEnumerable<TaskPOCDetailRequest> , IEnumerable<BlTaskPOCDetailRequest>>(request);
                await _businessLogic.CreatePOCAsync(blRequestMapped);
                return Ok(request);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> DeletePoc([FromBody] TaskDeletePocRequest request)
        //{
        //    try
        //    {
        //        await _businessLogic.DeletePocById(request.Id);
        //        return Ok(request);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}

        [HttpPut]
        public async Task<IActionResult> UpdateTaskDetail([FromBody] UpdateTaskDetailRequest request)
        {
            try
            {
                //var blResponse = await _businessLogic.GetTaskById(id);
                var blRequest = _mapper.Map<UpdateTaskDetailRequest, BlUpdateTaskDetail>(request);
                await _businessLogic.UpdateAsync(blRequest);
                return Ok(request);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}