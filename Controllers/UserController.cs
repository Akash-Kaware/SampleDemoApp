using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleDemoApp.Model;
using SampleDemoApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleDemoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserDetailsService _UserDetailsService;
        public UserController(IUserDetailsService userDetailsService)
        {
            this._UserDetailsService = userDetailsService;
        }

        [HttpGet(nameof(Get))]
        public async Task<List<UserDetails>> Get()
        {
            return await _UserDetailsService.GetAll();
        }


        [HttpGet(nameof(GetById))]
        public async Task<UserDetails> GetById(int id)
        {
            return await _UserDetailsService.GetById(id);
        }

        [HttpPost(nameof(Create))]
        public async Task<int> Create(UserDetails data)
        {
           
            return await _UserDetailsService.Create(data);
        }

        [HttpPatch(nameof(Update))]
        public async Task<int> Update(UserDetails data)
        {
            return await _UserDetailsService.Update(data);
        }

        [HttpDelete(nameof(Delete))]
        public async Task<int> Delete(int Id)
        {
            var result = await _UserDetailsService.Delete(Id);
            return result;
        }
    }
}
