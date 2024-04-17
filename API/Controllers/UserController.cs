
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReqResApi.API.Interfaces;
using ReqResApi.DataLayer.Models;
using static ReqResApi.DataLayer.Models.User;   

namespace ReqResApi.API.Controllers
{
    public class UserController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IUserService _userService;
        public UserController(IUserService userService, IHttpClientFactory httpClientFactory)
        {
            _userService = userService;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("/api/users")]
        public async Task<Root> GetAllUsers(int page, int per_page)
        {
            try
            {

                return await _userService.GetUsers();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("/api/users/{id}")]
        public async Task<User.Rootobject> GetUserId([FromRoute] int id)
        {
            try
            {

                return await _userService.GetUserId(id);

            }
            catch (Exception ex)
            {
                    throw;
            }
        }

        [HttpPost]
        [Route("/api/users")]
        public async Task<ResponseCreateUser> CreateUser(CreateUser user)
        {
            try
            {

                return await _userService.CreateUser(user);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("/api/unknown")]
        public async Task<RootResource> GetResources(int page, int per_page)
        {
            try
            {

                return await _userService.GetResources();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("/api/unknown/{id}")]
        public async Task<RootResource> GetOneResource(int id)
        {
            try
            {

                return await _userService.GetOneResource(id);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
