using BugTracker.Application.Projects.Commands.CreateProject;
using BugTracker.Contracts.Projects;
using BugTracker.Domain.ProjectAggregate;
using Mapster;

namespace BugTracker.Api.Common.Mapping
{
    public class ProjectMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(CreateProjectRequest Request, string ReporterId), CreateProjectCommand>()
                .Map(dest => dest.ReporterId, src => src.ReporterId)
                .Map(dest => dest, src => src.Request);

            config.NewConfig<Project, ProjectResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.ReporterId, src => src.ReporterId.reporterId)
                .Map(dest => dest.TaskIds, src => src.TaskIds.Select(taskId => taskId.Value));
        }
    }
}
