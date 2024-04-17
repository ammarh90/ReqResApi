using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReqResApi.DataLayer.Models;

namespace ReqResApi.API.Interfaces
{
    public interface IUserService
    {
        Task<Root> GetUsers();
        Task<User.Rootobject> GetUserId(int id);
        Task<ResponseCreateUser> CreateUser(CreateUser user);
        Task<RootResource> GetResources();
        Task<RootResource> GetOneResource(int id);

    }
}
