using EnShop.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnShop.Repository
{
    public interface IBaseRepository<TEntity>where TEntity : class
    {
        Task<List<TEntity>> Query();
    }
}
