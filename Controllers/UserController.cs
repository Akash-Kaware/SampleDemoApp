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
        public async Task<IActionResult> Create(UserDetails data)
        {
            if (data.Id == 0)
            {
                var result = await _UserDetailsService.Create(data);
                return Ok(new { data = result });
            }
            else
            {
                var result = await _UserDetailsService.Update(data);
                return Ok(new { data = result });
            }
        }

        [HttpDelete(nameof(Delete))]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _UserDetailsService.Delete(Id);
            return Ok(new { data = result });
        }
    }
}
