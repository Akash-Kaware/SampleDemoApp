using Dapper;
using SampleDemoApp.Model;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleDemoApp.Services
{
    public class UserDetailsService : IUserDetailsService
    {
        private readonly IDapper _dapper;
        public UserDetailsService(IDapper dapper)
        {
            _dapper = dapper;
        }        

        public async Task<List<UserDetails>> GetAll()
        {
            var result = await Task.FromResult(_dapper.GetAll<UserDetails>($"Select * from [UserDetails]", null, commandType: CommandType.Text));
            return result;
        }

        public async Task<UserDetails> GetById(int Id)
        {
            var result = await Task.FromResult(_dapper.Get<UserDetails>($"Select * from [UserDetails] where Id = {Id}", null, commandType: CommandType.Text));
            return result;
        }

        public async Task<int> Create(UserDetails data)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Id", data.Id, DbType.Int32);
            var result = await Task.FromResult(_dapper.Insert<int>("[dbo].[SP_Add_UserDetails]"
                , dbparams,
                commandType: CommandType.StoredProcedure));
            return result;
        }

        public async Task<int> Update(UserDetails data)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("Id", data.Id);
            dbPara.Add("Name", data.Name, DbType.String);

            var updateArticle = await Task.FromResult(_dapper.Update<int>("[dbo].[SP_Update_UserDetails]",
                            dbPara,
                            commandType: CommandType.StoredProcedure));
            return updateArticle;
        }

        public async Task<int> Delete(int Id)
        {
            var result = await Task.FromResult(_dapper.Execute($"Delete [UserDetails] Where Id = {Id}", null, commandType: CommandType.Text));
            return result;
        }
    }
}
