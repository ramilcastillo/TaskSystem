using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using TaskSystem.DTO.Admin;

namespace TaskSystem.Controllers.API
{
    public static class AdminAPI
    {
        public static RestClient _client;

        public static IEnumerable<TaskPOCsResponse> GetTaskOwnerByUsername(string baseUrl, string userName)
        {
            try
            {
                _client = new RestClient(baseUrl);
                var apiRequest = new RestRequest(Method.GET);
                apiRequest.Resource = "/api/AdminApi/TaskOwnerByUserName/"+userName;
                apiRequest.RequestFormat = DataFormat.Json;
                var response = _client.Execute(apiRequest);

                //var data = JsonConvert.DeserializeObject<IEnumerable<TaskDefaultPOCsResponse>>(response.Content);
                IEnumerable<TaskPOCsResponse> data = null;

                if (response.Content != "")
                {
                    data = JsonConvert.DeserializeObject<IEnumerable<TaskPOCsResponse>>(response.Content);
                }            
                return data;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static IEnumerable<TaskOwnerResponse> AddTaskOwner(string baseUrl, AddUserAdminRequest request)
        {
            try
            {
                _client = new RestClient(baseUrl);

                var apiRequest = new RestRequest(Method.POST)
                {
                    Resource = "/api/AdminApi/AddTaskOwner",
                    RequestFormat = DataFormat.Json
                };
                apiRequest.AddBody(request);
                var response = _client.Execute(apiRequest);
                var data = JsonConvert.DeserializeObject<IEnumerable<TaskOwnerResponse>>(response.Content);

                return data;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
