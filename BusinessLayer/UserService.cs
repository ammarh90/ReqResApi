using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReqResApi.API.Interfaces;
using ReqResApi.DataLayer.Models;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Text.Json;
using static ReqResApi.DataLayer.Models.User;
using static System.Net.Mime.MediaTypeNames;

namespace ReqResApi.BusinessLayer
{
    public class UserService : IUserService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public UserService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Root> GetUsers()
        {
            try
            {
                HttpClient webClient = _httpClientFactory.CreateClient("ReqRes");
                HttpResponseMessage response = await webClient.GetAsync(webClient.BaseAddress + "api/users");
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Root>().Result;
                }
                throw new Exception("Error");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<User.Rootobject> GetUserId([FromRoute]int id)
        {
            try
            {
               
                HttpClient webClient = _httpClientFactory.CreateClient("ReqRes");
                //var parameters = new Dictionary<string, string>();
                //parameters["id"] = id.ToString();
                HttpResponseMessage response = await webClient.GetAsync(webClient.BaseAddress + "api/users/{id}");
                if (response.IsSuccessStatusCode)
                {

                    //JsonConvert.DeserializeObject<User.Rootobject>(JsonConvert.DeserializeObject<string>(response.ToString()));
                    //var result = JsonConvert.DeserializeObject<User.Rootobject>(id.ToString());
                    //JsonConvert.DeserializeObject<ResultContact.Result>
                    //var messages = JsonConvert.DeserializeObject<User.Rootobject>(response.ToString());
                    // var json = response.Content.ReadAsAsync<User.Rootobject>().Result;
                    //var messagesList = JsonSerializer.Deserialize<Rootobject>(json, new JsonSerializerOptions());
                    //var messages = JsonConvert.DeserializeObject<User.Rootobject>(json.ToString());
                    // return json;
                    //var json = JsonConvert.DeserializeObject<User.Rootobject>(File.ReadAllText(id.ToString()));
                    // return json;
                }

                throw new Exception("Error");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseCreateUser> CreateUser(CreateUser user)
        {
            try
            {
                HttpClient webClient = _httpClientFactory.CreateClient("ReqRes");
                StringContent theContent = new StringContent(JsonConvert.SerializeObject(user), System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await webClient.PostAsync(webClient.BaseAddress + "api/users", theContent);
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<ResponseCreateUser>().Result;
                }
                throw new Exception("Error");
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<RootResource> GetResources()
        {
            try
            {
                HttpClient webClient = _httpClientFactory.CreateClient("ReqRes");
                HttpResponseMessage response = await webClient.GetAsync(webClient.BaseAddress + "api/unknown");
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<RootResource>().Result;
                }
                throw new Exception("Error");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<RootResource> GetOneResource(int id)
        {
            try
            {
                HttpClient webClient = _httpClientFactory.CreateClient("ReqRes");
                HttpResponseMessage response = await webClient.GetAsync(webClient.BaseAddress + "api/unknown/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<RootResource>().Result;
                }
                throw new Exception("Error");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
