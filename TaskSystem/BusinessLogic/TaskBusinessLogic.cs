using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
//using System.Design;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
//using AutoMapper.Mappers;
using TaskSystem.BusinessLogic.DTO;
using TaskSystem.BusinessLogic.Interface;
using TaskSystem.DAL;
using TaskSystem.DAL.Entities;
using TaskSystem.DTO.Email;
using TaskSystem.DTO.Task;


namespace TaskSystem.BusinessLogic
{
    public class TaskBusinessLogic: ITaskBusinessLogic
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;
        private int PocTaskId;

        public TaskBusinessLogic(IRepository repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }

        public async System.Threading.Tasks.Task CreateAsync(BL_TaskCreateRequest request)
        {
            //var taskList = await _repo.GetAllTasks();
            var taskList = await _repo.GetTopTasks();
            int taskId = 1;
            if (taskList.Count() != 0)
            {
                var lastTaskId = taskList.OrderByDescending(s => s.Id).Select(s => s.Id).FirstOrDefault();
                taskId = lastTaskId + 1;
            }
            
            //Insert Task
            var tasks = _mapper.Map<BL_TaskCreateRequest, Tasks>(request);
            //tasks.FileNumber = taskId.ToString();
            tasks.Type = "Suspense";
            tasks.Status = "Open";
            await _repo.InsertTask(tasks);

            var getDate = DateTime.Now;
            //Insert Pocsusername
            var taskPocs = new BlCreateTaskPocs
            {
                PoctaskId = taskId,
                Pocusername = request.UserName,
                PocdateAssigned = getDate,
                PocpersonalDate = getDate,
                //ParentUsername = request.UserName
                ParentUsername = "*",
                POClevel = 0,
                POCsort = "*"
            };

            var taskPocsMapped = _mapper.Map<BlCreateTaskPocs, TaskPocs>(taskPocs);
            await _repo.InsertTaskPocs(taskPocsMapped);

            //Insert TaskUpdate
            var taskUpdate = new BlTaskUpdates
            {
                TaskId = taskId,
                DateUpdate = getDate,
                UserName = request.UserName
            };

            var taskUpdateMapped = _mapper.Map<BlTaskUpdates, TaskUpdates>(taskUpdate);
            await _repo.InsertTaskUpdates(taskUpdateMapped);

            //Email Funtionality
            Email Email = new Email();
            MailContentModel mailSettings = Email.EmailSettings;

            // Send success notification...               
            mailSettings.MailSubject = "Test Test Test";
            string details = "~~ Inbound Acknowledgement File Processed Successfully ~~";
            details += Environment.NewLine;
            details += string.Format("Process Date/Time: {0:MM-dd-yyyy hh:mm:ss tt}, ", DateTime.Now);
            details += Environment.NewLine;
            details += string.Format("Record Count:{0}", 20);

            mailSettings.MailBody = details;
            mailSettings.MailTo = "VijayBhaskar.Reddy@DCAA.mil";
            EmailUtility.SendMailMessage(mailSettings);

        }

        public async Task<IEnumerable<BL_TaskListResponseDetail>> GetTasksForUser(string userName, string taskSatus)
        {
            //var allTaskPocs = await _repo.GetAllTasksPocs();
            //var allTaskPocs = await _repo.GetTopTasksPocs();
            //var allTaskPocs = await _repo.GetAllTasksPocs(userName);
            //if (userName == "ClosedTasks")
                var allTaskPocs = await _repo.GetAllTasksPocs(userName, taskSatus);
            //var allTasks = await _repo.GetAllTasks();
            //var allTasks = await _repo.GetTopTasks();

            //var result = from t in allTasks
            //             join tp in allTaskPocs on t.Id equals tp.PoctaskId
            //                 into combined
            //             from c in combined.DefaultIfEmpty()
            //             where c.Pocusername == userName
            //             select new BL_TaskListResponseDetail
            //             {
            //                 Id = t.Id,
            //                 PocpersonalDate = c.PocpersonalDate == null? string.Empty: Convert.ToDateTime(c.PocpersonalDate).ToShortDateString(),
            //                 Subject = t.Subject,
            //                 Status = t.Status,
            //                 PocpersonalNote = c.PocpersonalNote,
            //                 Pocusername = c.Pocusername,
            //                 PocdateDue = c.PocdateDue == null ? string.Empty : Convert.ToDateTime(c.PocdateDue).ToShortDateString(),
            //                 Requestor = t.Requestor,
            //                 FileNumber = t.FileNumber.ToString()
            //             };

            var allTaskPocsPerCurrentUser = allTaskPocs.Where(s => s.Pocusername == userName).ToList();
            var allTaskPocsPerCurrentUserInt = allTaskPocs.Where(s => s.Pocusername == userName).Select(s => s.PoctaskId).ToList();

            var allTasks =  _repo.GetAllTasks(allTaskPocsPerCurrentUserInt);

            var tasksForCurrentUser =
                allTasks.Where(s => allTaskPocsPerCurrentUserInt.Contains(s.Id)).ToList();

            var result = from taskTable in tasksForCurrentUser
                         join taskPocsTable in allTaskPocsPerCurrentUser
                             on taskTable.Id equals taskPocsTable.PoctaskId
                         select new BL_TaskListResponseDetail
                         {
                             Id = taskTable.Id,
                             PocpersonalDate = taskPocsTable.PocpersonalDate == null ? string.Empty : Convert.ToDateTime(taskPocsTable.PocpersonalDate).ToShortDateString(),
                             Subject = taskTable.Subject,
                             //Status = Enum.Parse<BlTaskStatusEnum>(taskTable.Status),
                             Status = taskTable.Status,
                             PocpersonalNote = taskPocsTable.PocpersonalNote,
                             Pocusername = taskPocsTable.Pocusername,
                             PocdateDue = taskPocsTable.PocdateDue == null ? string.Empty : Convert.ToDateTime(taskPocsTable.PocdateDue).ToShortDateString(),
                             Requestor = taskTable.Requestor,
                             FileNumber = taskTable.FileNumber
                         };

            return result;
        }
        
        public async Task UpdateAsync(BlUpdateTaskDetail request)
        {
            //var recordTaskPocs = await _repo.GetTaskPocsByTaskId(int.Parse(request.Id));
            var recordTaskPocs = await _repo.GetTaskPocByTaskIdUserName(int.Parse(request.Id), request.Pocsusername);
            var recordTasks = await _repo.GetTaskById(int.Parse(request.Id));
            if (recordTaskPocs == null)
            {
                throw new Exception("Record does not Exists!");
            }

            foreach (var recordTaskPoc in recordTaskPocs)
            {
                recordTaskPoc.PoctaskId = int.Parse(request.Id);

                if (request.PocdateDue != null && request.PocdateDue != "")
                    if (Convert.ToDateTime(request.PocdateDue).ToShortDateString() != null)
                        recordTaskPoc.PocdateDue = Convert.ToDateTime(request.PocdateDue);
                //recordTaskPocs.PocdateDue = DateTime.ParseExact(request.PocdateDue,"MM/DD/YYYY",CultureInfo.InvariantCulture);
                if (request.PocpersonalDate != null && request.PocpersonalDate != "")
                    if (Convert.ToDateTime(request.PocpersonalDate).ToShortDateString() != null)
                        recordTaskPoc.PocpersonalDate = Convert.ToDateTime(request.PocpersonalDate);
                recordTaskPoc.Pocusername = request.Pocsusername;
                if (request.PocdateAssigned != null && request.PocdateAssigned != "")
                    if (Convert.ToDateTime(request.PocdateAssigned).ToShortDateString() != null)
                        recordTaskPoc.PocdateAssigned = Convert.ToDateTime(request.PocdateAssigned);

                //recordTaskPoc.ParentUsername = request.Pocsusername;

                if (request.PocdateClosed != null && request.PocdateClosed != "")
                    if (Convert.ToDateTime(request.PocdateClosed).ToShortDateString() != null)
                        recordTaskPoc.PocdateClosed = Convert.ToDateTime(request.PocdateClosed);
                recordTaskPoc.Poclevel = 1;
                recordTaskPoc.PocpersonalNote = request.PocpersonalNote;

                //need to pass the actual userid
                //recordTaskPoc.ParentUsername = request.Pocsusername;
                recordTasks.Requestor = request.Requestor;
                recordTasks.Status = request.Status;
                recordTasks.Type = request.Type;

                await _repo.UpdateTaskPocAsync(recordTaskPoc);
                await _repo.UpdateTask(recordTasks);


                //Email Funtionality
                Email Email = new Email();

                //MailContentModel mailSettings = Email.EmailSettings;
                MailContentModel mailSettings = new MailContentModel();

                // Send success notification...               
                mailSettings.MailSubject = "Test Test Test";
                string details = "~~ Inbound Acknowledgement File Processed Successfully ~~";
                details += Environment.NewLine;
                details += string.Format("Process Date/Time: {0:MM-dd-yyyy hh:mm:ss tt}, ", DateTime.Now);
                details += Environment.NewLine;
                details += string.Format("Record Count:{0}", 20);

                mailSettings.MailBody = details;
                mailSettings.MailTo = "VijayBhaskar.Reddy@DCAA.mil";
                mailSettings.MailCC = "VijayBhaskar.Reddy@DCAA.mil";
                mailSettings.MailFrom = "noreply@dcaa.mil";

                mailSettings.MailServer = "DCAASMTP.dcaa.mil";

                // Erroring with "Access denied"
                //EmailUtility.SendMailMessage(mailSettings);
            }
        }

        public async Task<BlTaskDetailResponse> GetTaskById(int id, string Pocusername)
        {
            var task = await _repo.GetTaskById(id);

            // To Get single Record 
            //var taskPocs = await _repo.GetTaskPocByTaskIdUserName(task.Id, Pocusername);
            // To Get multiplle Records
            var taskPocs = await _repo.GetTaskPocByTaskId(id);
            var taskPocs1 = taskPocs.Where(s => s.ParentUsername != "*");
            var taskPocsMapped = _mapper.Map<IEnumerable<TaskPocs>, IEnumerable<TaskPOCDetailRequest>>(taskPocs1);

            //var taskUpdates = (await _repo.GetTaskUpdatesById(task.Id)).Where(s => s.Comment != string.Empty || s.Comment != null).ToList();
            var taskUpdates = (await _repo.GetTaskUpdatesById(task.Id)).Where(s => string.IsNullOrEmpty(s.Comment) == false).ToList();
            var taskCommentsMapped = _mapper.Map<IEnumerable<TaskUpdates>, IEnumerable<TaskCommentDetailResponse>>(taskUpdates);
            //var uploadedFile = (await _repo.GetUploadFileById(id))?.FileName;
            //var taskPoc = taskPocs.First(s => s.Pocusername == s.ParentUsername);

            //var taskPoc = taskPocs.First(s => s.Pocusername == Pocusername && s.ParentUsername == "*");
            var taskPoc = taskPocs.First(s => s.Pocusername == Pocusername);
            var taskFiles = await _repo.GetUploadedFilesById(task.Id.ToString());
            var taskFilesMapped = _mapper.Map<IEnumerable<TaskFiles>, IEnumerable<TaskFileResponse>>(taskFiles);

            var blResponse = new BlTaskDetailResponse
                {
                    ID = task.Id,
                    Pocsusername = taskPoc.Pocusername,
                    PocpersonalNote = taskPoc.PocpersonalNote,
                    //PocpersonalDate = taskPocs.PocpersonalDate,
                    PocpersonalDate = taskPoc.PocpersonalDate == null ? string.Empty : Convert.ToDateTime(taskPoc.PocpersonalDate).ToShortDateString(),
                    Subject = task.Subject,
                    Description = task.Description,
                    //Status = Enum.Parse<BlTaskStatusEnum>(task.Status),
                    Status = task.Status,
                    Requestor = task.Requestor,
                    //PocdateAssigned = taskPocs.PocdateAssigned,
                    PocdateAssigned = taskPoc.PocdateAssigned == null ? string.Empty : Convert.ToDateTime(taskPoc.PocdateAssigned).ToShortDateString(),
                    FileNumber = task.FileNumber,
                    //PocdateClosed = taskPocs.PocdateClosed,
                    PocdateClosed = taskPoc.PocdateClosed == null ? string.Empty : Convert.ToDateTime(taskPoc.PocdateClosed).ToShortDateString(),
                    //PocdateDue = taskPocs.PocdateDue,
                    PocdateDue = taskPoc.PocdateDue == null ? string.Empty : Convert.ToDateTime(taskPoc.PocdateDue).ToShortDateString(),
                    Type = task.Type,
                    ParentUsername = taskPoc.ParentUsername,
                    TaskComments = taskCommentsMapped,
                    TaskPocs = taskPocsMapped,
                    Files = taskFilesMapped
            };

            taskFilesMapped = taskFilesMapped.ToArray();
            foreach (var i in taskFilesMapped)
            {


            }
                //DownLoadFiletoLocalFolder(taskFiles., string id, string taskOwner);
                return blResponse;      
        }
        public void DownLoadFiletoLocalFolder(List<IFormFile> files, string id, string taskOwner)
        {

            var fileByteSize = files[0].Length;
            var kb = fileByteSize / 1024;
            var fileSize = kb / 1024;

            if (fileSize > 5)
            {
                //return Content("File exceeds file size limit.");
            }
            if (fileSize == 0)
                fileSize = kb;

            var path = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot/uploadedfiles",
                files[0].FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                files[0].CopyTo(stream);
            }
        }


        public async Task UploadFile(BlFileDocumentRequest request)
        {
            try
            {
                byte[] buffer = File.ReadAllBytes(request.FileName);
                //SqlCommand command = new SqlCommand();
                //command.Text = "INSERT INTO YOUR_TABLE_NAME (image) values (@image)";
                //command.Parameters.AddWithValue("@image", buffer);
                //command.ExecuteNonQuery();
                request.FileData = buffer;
                var requestMapped = _mapper.Map<BlFileDocumentRequest, TaskFiles>(request);
                await _repo.UploadFile(requestMapped);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task CreateCommentAsync(BlTaskCommentDetailRequest request)
        {
            await _repo.DeleteExistingCommentUpdate(int.Parse(request.TaskId));
            var requestMapped = _mapper.Map<BlTaskCommentDetailRequest, TaskUpdates>(request);
            await _repo.InsertCommentAsync(requestMapped);
        }

        public string[] RemoveDuplicates(string[] inputArray)
        {
            List<string> distinctArray = new List<string>();
            foreach (string element in inputArray)
            {
                if (!distinctArray.Contains(element))
                    distinctArray.Add(element);
            }
            return distinctArray.ToArray<string>();
        }

        public async Task CreatePOCAsync(IEnumerable<BlTaskPOCDetailRequest> request)
        {
            var requestArray = request.ToArray();
            List<string> PocusernameList = new List<string>();
            var getDate = DateTime.Now;
            foreach (var i in request)
            {
                if (i.Id == 0)
                {
                    PocusernameList.Add(i.Pocusername.Trim());
                }
                PocTaskId = i.PoctaskId;
            }
            string[] OutPutArray = RemoveDuplicates(PocusernameList.ToArray());

            //Check & delete if the User is already assigned as POC
            //await _repo.DeletePocByTaskId(requestArray[0].PoctaskId);
            //await _repo.DeletePocByTaskId(requestArray[0].PoctaskId, requestArray[0].Pocusername);
            //await _repo.DeletePocByTaskId(requestArray[0].Id, requestArray[0].Pocusername);
            int id = 0;
            foreach (var i in OutPutArray)
            {
                //int id = 0;
                var taskPocs = new BlCreateTaskPocs
                {
                    PoctaskId = PocTaskId,
                    Pocusername = OutPutArray[id],
                    ParentUsername = Models.GlobalLogin._userName,
                    PocpersonalDate = getDate,
                    PocdateAssigned = getDate,
                    //POClevel = 0,
                    //POCsort = "*"
                };
                id = id + 1;
                var taskPocsMapped = _mapper.Map<BlCreateTaskPocs, TaskPocs>(taskPocs);
                await _repo.InsertTaskPocs(taskPocsMapped);
            }
            foreach (var i in request)
            {
                if (i.Id != 0)
                {
                    var recordTaskPocs = await _repo.GetTaskPocsByTaskId(i.Id);
                    if (recordTaskPocs == null)
                    {
                        throw new Exception("Record does not Exists!");
                    }
                    foreach (var recordTaskPoc in recordTaskPocs)
                    {
                        //recordTaskPoc.Id = i.Id;
                        //recordTaskPoc.PoctaskId = recordTaskPoc.PoctaskId;
                        //recordTaskPoc.Pocusername = recordTaskPoc.Pocusername;

                        if (i.PocdateClosed != null && i.PocdateClosed != "")
                            if (Convert.ToDateTime(i.PocdateClosed).ToShortDateString() != null)
                                recordTaskPoc.PocdateClosed = Convert.ToDateTime(i.PocdateClosed);
                            else
                                recordTaskPoc.PocdateClosed = null;
                        else
                            recordTaskPoc.PocdateClosed = null;

                        //recordTaskPoc.ParentUsername = recordTaskPoc.ParentUsername;

                        if (i.PocdateDue != null && i.PocdateDue != "")
                        {
                            if (Convert.ToDateTime(i.PocdateDue).ToShortDateString() != null)
                                recordTaskPoc.PocdateDue = Convert.ToDateTime(i.PocdateDue);
                            else
                                recordTaskPoc.PocdateDue = null;
                        }
                        else
                            recordTaskPoc.PocdateDue = null;

                        //if (i.PocdateAssigned != null && i.PocdateAssigned != "")
                        //{
                        //    if (Convert.ToDateTime(i.PocdateAssigned).ToShortDateString() != null)
                        //        recordTaskPoc.PocdateAssigned = Convert.ToDateTime(i.PocdateAssigned);
                        //    //else
                        //    //    recordTaskPoc.PocdateAssigned = DateTime.Today();
                        //}
                        //recordTaskPoc.Pocsort = recordTaskPoc.Pocsort;
                        //recordTaskPoc.Poclevel = recordTaskPoc.Poclevel;
                        //recordTaskPoc.PocisFlagged = recordTaskPoc.PocisFlagged;
                        //recordTaskPoc.PocpersonalNote = recordTaskPoc.PocpersonalNote;
                        //recordTaskPoc.PocpersonalDate = recordTaskPoc.PocpersonalDate;

                        await _repo.UpdateTaskPocAsync(recordTaskPoc);
                    }                   
                }
            }
        }
        public async Task UploadFile(BlUploadFileRequest request)
        {
            var requestMapped = _mapper.Map<BlUploadFileRequest, TaskFiles>(request);
            //await _repo.DeleteUploadedById(request.FileTaskId);
            await _repo.UploadFile(requestMapped);
        }

        public async Task DeletePocById(int id)
        {
            await _repo.DeletePocByTaskId(id);
        }
    }
}
