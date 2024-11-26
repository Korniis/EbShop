using AutoMapper;
using EnShop.Repository.CRepository;
using EnShop.Service.CService;

namespace EnShop.Test
{
    [TestClass]
    public class UnitTest1
    {
        private IMapper mapper;

        [TestMethod]
        public void TestMethod1()
        {
            var UR=  new UserRepository();
           
            var US = new UserService(mapper , UR);
            Console.WriteLine(US.Query());
        }
    }
}