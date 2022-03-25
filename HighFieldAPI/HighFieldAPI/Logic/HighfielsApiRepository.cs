using HighFieldAPI.Extensions;
using HighFieldAPI.Models;
using HighFieldAPI.Models.API;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HighFieldAPI.Logic
{
    public class HighfielsApiRepository : IDisposable
    {
        public readonly HighFieldSettings HighfieldSettings;
        public readonly HttpClient Client;

        public HighfielsApiRepository(HighFieldSettings settings)
        {
            HighfieldSettings = settings;
            Client = this.CreateHighfieldClient();
        }
        [HttpGet]
        public async Task<List<HighFieldUserEntity>> GetUsersAsync()
        {
            try
            {
                var HighfieldsUri = new Uri(this.HighfieldSettings.BaseUrl);
                var users = await this.QueryApiGet<List<HighFieldUserEntity>>(HighfieldsUri.PathAndQuery);
                var activeProjects = users ?? new List<HighFieldUserEntity>();

                return activeProjects;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<HighFieldUserEntity>();
            }
        }

       

        public void Dispose()
        {
            Client?.Dispose();
        }
    }
}
