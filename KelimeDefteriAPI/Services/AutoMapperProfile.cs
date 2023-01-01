    using AutoMapper;
using KelimeDefteriAPI.Context.EntityConcretes;
using KelimeDefteriAPI.Context.ViewModels;

namespace KelimeDefteriAPI.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RecordViewModel, Record>();
            CreateMap<WordViewModel, Word>().ForMember(word => word.Name, opt => opt.MapFrom(vm => vm.Name))
                .ForMember(word => word.Definitions, opt => opt.MapFrom(vm => vm.Definitions));
            CreateMap<DefinitionViewModel, Definition>()
                .ForMember(def => def.Description, opt => opt.MapFrom(vm => vm.definition))
                .ForMember(def => def.DescriptionType, opt => opt.MapFrom(vm => vm.definitionType));
        }
    }
}
