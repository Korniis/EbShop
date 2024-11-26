using AutoMapper;
using EnShop.IService;
using EnShop.Repository;
using EnShop.Repository.CRepository;

namespace EnShop.Service.CService
{
    public class BaseService<TEntity, TDTO> : IBaseService<TEntity,TDTO> where TEntity : class , new()
    {
        public  IMapper _mapper;
        public  IBaseRepository<TEntity> _baseRepository;
      

        public BaseService(IMapper mapper, IBaseRepository<TEntity> baseRepository)
        {
            _mapper = mapper;
           _baseRepository = baseRepository;
        }

        public async Task<List<TDTO>> Query()
        {
           
            var users = await _baseRepository.Query();
            var llout = _mapper.Map<List<TDTO>>(users);
            return llout;
        }
    }
}
