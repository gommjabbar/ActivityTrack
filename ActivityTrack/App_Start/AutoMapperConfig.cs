using ActivityTrack.DTO;
using ActivityTrack.Models;
using AutoMapper;

namespace ActivityTrack
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.CreateMap<ProjectEO, project>()
                .ForMember(x => x.id, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.name, opt => opt.MapFrom(src => src.Name));

            Mapper.CreateMap<project, ProjectEO>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.id))
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.name));



            Mapper.CreateMap<ActivityTypeEO, activityType>()
                .ForMember(x => x.id, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.type, opt => opt.MapFrom(src => src.Type))
                .ForMember(x => x.decription, opt => opt.MapFrom(src => src.Description));

            Mapper.CreateMap<activityType, ActivityTypeEO>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.id))
                .ForMember(x => x.Type, opt => opt.MapFrom(src => src.type))
                .ForMember(x => x.Description, opt => opt.MapFrom(src => src.decription));



            Mapper.CreateMap<ActivityEO, activity>()
                .ForMember(x => x.id, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.endDate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(x => x.typeId, opt => opt.MapFrom(src => src.ActivityTypeId))
                .ForMember(x => x.projectId, opt => opt.MapFrom(src => src.ProjectId))
                .ForMember(x => x.description, opt => opt.MapFrom(src => src.Description))
                .ForMember(x => x.type, opt => opt.MapFrom(src => src.ActivityType))
                .ForMember(x => x.elapsedTime, opt => opt.MapFrom(src => src.ElapsedTime))
                .ForMember(x => x.activityState, opt => opt.MapFrom(src => src.ActivityState));

            Mapper.CreateMap<activity, ActivityEO>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.id))
                .ForMember(x => x.EndDate, opt => opt.MapFrom(src => src.endDate))
                .ForMember(x => x.ProjectId, opt => opt.MapFrom(src => src.projectId))
                .ForMember(x => x.ActivityTypeId, opt => opt.MapFrom(src => src.typeId))
                .ForMember(x => x.Description, opt => opt.MapFrom(src => src.description))
                .ForMember(x => x.ElapsedTime, opt => opt.MapFrom(src => src.elapsedTime))
                .ForMember(x => x.ActivityTypeId, opt => opt.MapFrom(src => src.type == null ? (int?) null : src.type.id))
                .ForMember(x => x.ActivityState, opt => opt.MapFrom(src => src.activityState));
        }
    }
}