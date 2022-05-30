using AutoMapper;

namespace UnitTest.Config
{
    public static class AutoMapperTestIntance
    {
        public static IMapper Get()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            return mockMapper.CreateMapper();
        }
    }
}
