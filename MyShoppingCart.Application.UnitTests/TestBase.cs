using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using MyShoppingCart.Application.Queries.GetAllProducts;

namespace MyShoppingCart.Application.UnitTests
{
    public class TestBase
    {
        protected readonly IFixture Fixture;
        protected IMapper Mapper
        {
            get
            {
                if (_mapper == null)
                {
                    var config = new MapperConfiguration(d => d.AddMaps(typeof(GetAllProductsQuery).Assembly));
                    _mapper = config.CreateMapper();
                }

                return _mapper;
            }
        }

        private IMapper _mapper;

        public TestBase()
        {
            Fixture = new Fixture()
                .Customize(new AutoMoqCustomization());
        }
    }
}
