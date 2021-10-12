using SampleDemoApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleDemoApp.Services
{
    public interface IUserDetailsService
    {
        Task<int> Create(UserDetails data);
        Task<List<UserDetails>> GetAll();
        Task<UserDetails> GetById(int Id);
        Task<int> Delete(int Id);
        Task<int> Update(UserDetails data);
    }
}
