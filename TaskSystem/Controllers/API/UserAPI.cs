using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using RestSharp;
using TaskSystem.DTO.Admin;
using TaskSystem.DTO.Task;
using TaskSystem.DTO.User;

namespace TaskSystem.Controllers.API
{
    public static class UserAPI
    {
        public static RestClient _client;

        public static void CreateUser(string baseUrl, CreateUserRequest request)
        {
            try
            {
                _client = new RestClient(baseUrl);
                var apiRequest = new RestRequest(Method.POST);
                apiRequest.Resource = "/api/UserApi";
                apiRequest.RequestFormat = DataFormat.Json;
                apiRequest.AddBody(request);
                var response = _client.Execute(apiRequest);
                var data = JsonConvert.DeserializeObject<IEnumerable<TaskListResponseDetail>>(response.Content);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static IEnumerable<AdministratorListResponse> GetListAdministrator(string baseUrl, string userName)
        {
            try
            {
                _client = new RestClient(baseUrl);
                var apiRequest = new RestRequest(Method.GET);
                apiRequest.Resource = "/api/UserApi/"+userName;
                var response = _client.Execute(apiRequest);
                var data = JsonConvert.DeserializeObject<IEnumerable<AdministratorListResponse>>(response.Content);

                return data;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static IEnumerable<UsersResponse> GetAllUsers(string baseUrl, string searchName)
        {
            try
            {
                _client = new RestClient(baseUrl);
                var apiRequest = new RestRequest(Method.GET);
                apiRequest.Resource = "/api/UserApi/getusers/" + searchName;
                var response = _client.Execute(apiRequest);
                var data = JsonConvert.DeserializeObject<IEnumerable<UsersResponse>>(response.Content);

                return data;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteUser(string baseUrl, RemoveUserAdminRequest request)
        {
            try
            {
                _client = new RestClient(baseUrl);
                var apiRequest = new RestRequest(Method.DELETE)
                {
                    Resource = "/api/UserApi",
                    RequestFormat = DataFormat.Json
                };
                apiRequest.AddBody(request);
                var response = _client.Execute(apiRequest);
               // var data = JsonConvert.DeserializeObject<IEnumerable<AdministratorListResponse>>(response.Content);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
