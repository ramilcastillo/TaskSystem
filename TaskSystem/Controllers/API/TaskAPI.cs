using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using TaskSystem.DTO.Task;

namespace TaskSystem.Controllers.API
{
    public class TaskAPI
    {
        public static RestClient _client;

        public static IEnumerable<TaskListResponseDetail> GetTaskList(string baseUrl)
        {
            try
            {
                _client = new RestClient(baseUrl);
                var apiRequest = new RestRequest(Method.GET);
                apiRequest.Resource = "/api/TaskApi";
                apiRequest.RequestFormat = DataFormat.Json;
                //apiRequest.AddBody(resource);
                var response = _client.Execute(apiRequest);
                var data = JsonConvert.DeserializeObject<IEnumerable<TaskListResponseDetail>>(response.Content);

                return data;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static IEnumerable<TaskListResponseDetail> GetTasksByUsername(string baseUrl, string userName, string taskSatus)
        {
            try
            {
                _client = new RestClient(baseUrl);
                var apiRequest = new RestRequest(Method.GET);
                apiRequest.Resource = "/api/TaskApi/GetTasksHome/" + userName + "/" + taskSatus;
                var response = _client.Execute(apiRequest);
                var data = JsonConvert.DeserializeObject<IEnumerable<TaskListResponseDetail> >(response.Content);


                return data;
            }
            catch (Exception e)
            {
                throw  new Exception(e.Message);
            }
        }
       
        public static TaskDetailResponse GetTaskById(string baseUrl, int id,string Pocusername)
        {
            try
            {
                _client = new RestClient(baseUrl);
                var apiRequest = new RestRequest(Method.GET);              
                apiRequest.Resource = "/api/TaskApi/GetTaskById/" + id + "/" + Pocusername;
                var response = _client.Execute(apiRequest);
                //var data = JsonConvert.DeserializeObject<TaskDetailResponse>(response.Content);

                if (response.StatusCode != 0)
                {
                    var data = JsonConvert.DeserializeObject<TaskDetailResponse>(response.Content);
                    return data;
                }
                else
                {
                    return null;
                }

                //return data;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void CreateTask(string baseUrl, CreateTaskRequest request)
        {
            try
            {

                _client = new RestClient(baseUrl);
                var apiRequest = new RestRequest(Method.POST)
                {
                    Resource = "/api/TaskApi/CreateTask",
                    RequestFormat = DataFormat.Json
                };
                apiRequest.AddBody(request);

                var response = _client.Execute(apiRequest);
                //var data = JsonConvert.DeserializeObject<TaskListResponseDetail>(response.Content);

                //return data;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void CreateComment(string baseUrl, TaskCommentDetailRequest request)
        {
            try
            {

                _client = new RestClient(baseUrl);
                var apiRequest = new RestRequest(Method.POST)
                {
                    Resource = "/api/TaskApi/CreateCommentAsync",
                    RequestFormat = DataFormat.Json
                };
                apiRequest.AddBody(request);

                var response = _client.Execute(apiRequest);
                //var data = JsonConvert.DeserializeObject<TaskListResponseDetail>(response.Content);

                //return data;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void CreatePOC(string baseUrl, IEnumerable<TaskPOCDetailRequest> request)
        {
            try
            {

                _client = new RestClient(baseUrl);
                var apiRequest = new RestRequest(Method.POST)
                {
                    Resource = "/api/TaskApi/CreatePOCAsync",
                    RequestFormat = DataFormat.Json
                };
                apiRequest.AddBody(request);

                var response = _client.Execute(apiRequest);
                //var data = JsonConvert.DeserializeObject<TaskListResponseDetail>(response.Content);

                //return data;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeletePOC(string baseUrl, TaskDeletePocRequest request)
        {
            try
            {

                _client = new RestClient(baseUrl);
                var apiRequest = new RestRequest(Method.POST)
                {
                    Resource = "/api/TaskApi/DeletePoc",
                    RequestFormat = DataFormat.Json
                };
                apiRequest.AddBody(request);

                var response = _client.Execute(apiRequest);
                //var data = JsonConvert.DeserializeObject<TaskListResponseDetail>(response.Content);

                //return data;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void UploadFile(string baseUrl, UploadRequest request)
        {
            try
            {

                _client = new RestClient(baseUrl);
                var apiRequest = new RestRequest(Method.POST)
                {
                    Resource = "/api/TaskApi/UploadFile",
                    RequestFormat = DataFormat.Json
                };
                apiRequest.AddBody(request);

                var response = _client.Execute(apiRequest);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void UpdateTaskDetail(string baseUrl, UpdateTaskDetailRequest request)
        {
            try
            {

                _client = new RestClient(baseUrl);
                var apiRequest = new RestRequest(Method.PUT)
                {
                    Resource = "/api/TaskApi/UpdateTaskDetail",
                    RequestFormat = DataFormat.Json
                };
                apiRequest.AddBody(request);

                var response = _client.Execute(apiRequest);
                //var data = JsonConvert.DeserializeObject<TaskListResponseDetail>(response.Content);

                //return data;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
