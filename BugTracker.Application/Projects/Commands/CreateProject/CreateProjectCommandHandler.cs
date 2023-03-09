using BugTracker.Application.Common.Interfaces.Persistence;
using BugTracker.Domain.ProjectAggregate;
using BugTracker.Domain.ReporterAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace BugTracker.Application.Projects.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, ErrorOr<Project>>
    {
        private readonly IProjectRepository _projectRepository;

        public CreateProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ErrorOr<Project>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            
            var project = Project.Create(
             //   reporterId: ReporterId.CreateUnique(),
                reporterId: ReporterId.Create(request.ReporterId),
                name: request.Name,
                description: request.Description);
            
            _projectRepository.Add(project);

            return project;
        }
    }
}
