using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSystem.Controllers.API;
using TaskSystem.DTO.Accounts;
using TaskSystem.DTO.Task;
using TaskSystem.DTO.User;
using TaskSystem.Models;

namespace TaskSystem.Controllers
{
    public class HomeController : Controller
    {
        private string taskOwnerConst { get; set; }
        private readonly IHostingEnvironment _hostingEnvironment;

        public HomeController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginValidation(LoginRequest loginRequest)
        {
            return null;
        }
        
        [AllowAnonymous]
        public IActionResult TaskIndex(string taskOwner,string taskSatus)
        {

            if (taskOwner == null)
              taskOwner = "vreddy";
            if (taskSatus == null)
                taskSatus = "All";
            ViewBag.taskOwner = taskOwner;
            taskOwnerConst = taskOwner;
            var response = GetTaskList(taskOwner, taskSatus).OrderByDescending(s => s.Id).ToList();

            return View(response);
        }

        public IActionResult Index()
        {
            return View();
        }
       
        public IEnumerable<TaskListResponseDetail> GetTaskList(string taskOwner, string taskSatus)
        {
            var response = TaskAPI.GetTasksByUsername($"http://{Request.Host}", taskOwner, taskSatus);
            return response;
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody] CreateTaskRequest request)
        {
            request.UserName = "vreddy";
            try
            {
                TaskAPI.CreateTask($"http://{Request.Host}", request);
                return Ok(request);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult CreateUser([FromBody] CreateUserRequest request)
        {
            try
            {
                UserAPI.CreateUser($"http://{Request.Host}", request);
                return RedirectToAction("TaskIndex");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public ActionResult UpdateTask([FromBody] UpdateTaskDetailRequest request)
        {
            try
            {
                TaskAPI.UpdateTaskDetail($"http://{Request.Host}", request);
                return Ok(request);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [AllowAnonymous]
        public IActionResult TaskDetail(int id, string taskOwner)
        {
            ViewBag.ID = id;
            ViewBag.AddedBy = taskOwner;
            var response = TaskAPI.GetTaskById($"http://{Request.Host}", id, taskOwner);
            return View(response);
        }

        [HttpPost]
        public IActionResult CreateComment([FromBody] TaskCommentDetailRequest requestComment)
        {
            TaskAPI.CreateComment($"http://{Request.Host}", requestComment);
            return Ok(requestComment);
        }

        [HttpPost]
        public IActionResult CreatePOC([FromBody] IEnumerable<TaskPOCDetailRequest> requestPOC)
        {
            TaskAPI.CreatePOC($"http://{Request.Host}", requestPOC);
            return Ok(requestPOC);
        }

        [HttpDelete]
        public IActionResult DeletePoc([FromBody] TaskDeletePocRequest requestDeletePoc)
        {
            TaskAPI.DeletePOC($"http://{Request.Host}", requestDeletePoc);
            return Ok(requestDeletePoc);
        }

        [HttpPost]
        public IActionResult UploadFile(List<IFormFile> files, string id, string taskOwner)
        {
            #region CopyTheFileToSolutionFiles

            if (files == null || files.Count == 0)
            {
               return RedirectToAction("TaskDetail", "Home", new { id = id, taskOwner = taskOwner });
            }
            else
            {
                var fileByteSize = files[0].Length;
                var kb = fileByteSize / 1024;
                var fileSize = kb / 1024;

                if (fileSize > 5)
                {
                    return Content("File exceeds file size limit.");
                }

                var folderPath = _hostingEnvironment.WebRootPath + "/uploadedfiles/" + id.ToString();
                if (!Directory.Exists(folderPath))
                {
                    System.IO.Directory.CreateDirectory(folderPath);
                }

                var path = Path.Combine(folderPath, files[0].FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    files[0].CopyTo(stream);
                }

                #endregion

                IFormFile file = files.FirstOrDefault();

                MemoryStream ms = new MemoryStream();
                file.OpenReadStream().CopyTo(ms);

                var request = new UploadRequest
                {
                    FileTaskId = int.Parse(id),
                    //FileTaskId = ViewBag.ID,
                    ContentType = file.ContentType,
                    FileName = file.FileName,
                    FileData = ms.ToArray(),
                    FileSize = int.Parse(fileSize.ToString()),
                    FileAddedBy = taskOwner,
                    FileAddedDate = DateTime.Now,
                    FileUploadVersion = 1
                };

                TaskAPI.UploadFile($"http://{Request.Host}", request);

                return RedirectToAction("TaskDetail", "Home", new { id = id, taskOwner = taskOwner });
            }
        }
        //[HttpPost]
        //public IActionResult DownloadFile(string fileName, string taskId)
        //{
        //    if (fileName == null)
        //        return Content("filename not present");

        //    var path = Path.Combine(
        //        Directory.GetCurrentDirectory(),
        //        "wwwroot/uploadedfiles", fileName);

        //    if (!System.IO.File.Exists(path))
        //    {
        //        return null;
        //    }
        //    else { 
        //    var memory = new MemoryStream();
        //    using (var stream = new FileStream(path, FileMode.Open))
        //    {
        //        stream.CopyToAsync(memory);
        //    }
        //    memory.Position = 0;
        //    return File(memory, GetContentType(path), Path.GetFileName(path));
        //    }
            
        //}

        [Route("/Home/DownloadActualFile")]
        public async Task<IActionResult> DownloadActualFile(string fName)
        {
            var memory = new MemoryStream();
            //if (ms == null)
            //    return new EmptyResult();
            // Session[fName] = null;
            //return File(ms, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fName);



            using (var stream = new FileStream(fName, FileMode.Open))
            {
                stream.CopyToAsync(memory);
            }

            memory.Position = 0;
            return File(memory, GetContentType(fName), Path.GetFileName(fName));
        }

        [HttpPost]
        [Route("/Home/DownloadFile")]
        public async Task<IActionResult> DownloadFile(string fileName, string taskId)
        {
            if (fileName == null)
            {
                return Content("filename not present");
            }

            var path = Path.Combine(_hostingEnvironment.WebRootPath + "/uploadedfiles/" + taskId, fileName);

            var memory = new MemoryStream();

            using (var stream = new FileStream(path, FileMode.Open))
            {
                stream.CopyToAsync(memory);
            }

            memory.Position = 0;
            //return File(memory,GetContentType(path),Path.GetFileName(path));
            return Json(new { success = true, path });
        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".ppt", "application/vnd.ms-powerpoint"},
                {".pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation"},
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}

            };
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
