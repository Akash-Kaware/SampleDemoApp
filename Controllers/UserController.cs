using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleDemoApp.Model;
using SampleDemoApp.Services;
using System;
using System.Collections.Generic;
using System.IO;
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
        public async Task<IActionResult> Create([FromForm] UserDetails data)
        {
            if (data.Passport != null)
            {
                data.PassportFilePath = await UploadFile(data.Passport);
            }
            if (data.Photo != null)
            {
                data.PersonPhoto = await UploadFile(data.Photo);
            }

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

        private async Task<string> UploadFile(IFormFile file)
        {
            string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filename);
            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return filename;
        }
    }
}
