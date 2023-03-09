using BugTracker.Application.Projects.Commands.CreateProject;
using BugTracker.Contracts.Projects;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Api.Controllers
{
    [Route("reporters/{reporterId}/projects")]
    public class ProjectsController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public ProjectsController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(CreateProjectRequest request, string reporterId)
        {
            var command = _mapper.Map<CreateProjectCommand>((request, reporterId));
            
            var createProjectResult = await _mediator.Send(command);

            return createProjectResult.Match(
                project => Ok(_mapper.Map<ProjectResponse>(project)),
                errors => Problem(errors));
        }
    }
}
