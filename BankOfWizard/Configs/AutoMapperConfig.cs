

using AutoMapper;
using BankOfWizard.App.Common;

namespace BankOfWizard.Configs
{
    public static class AutoMapperConfig
    {
        public static IMapper GetAutoMapperConfiguration()
        {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingConfig()); });
            return mappingConfig.CreateMapper();
        }
    }
}
