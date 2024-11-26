using EnShop.Model.UserModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnShop.Repository
{
    public   class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
    

        public async Task<List<TEntity>> Query()
        {
           
                await Task.CompletedTask;
                var data = "[{\"Id\" :18,\"Name\":\" hajimi \" },{\"Id\" :18,\"Name\":\" hajimi \" }]";
                return JsonConvert.DeserializeObject<List<TEntity>>(data) ?? new List<TEntity>();
            
        }
    }
}
