using EnShop.Model.DTO;

namespace EnShop.IService
{
    public interface IBaseService<TEntity,TDTO>where TEntity : class
    {

        Task<List<TDTO>> Query();

    }
}
