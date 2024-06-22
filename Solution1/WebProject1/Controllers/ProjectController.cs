using Microsoft.AspNetCore.Mvc;
using WebProject1.Services;

namespace WebProject1.Controllers;

[ApiController]
[Route("/api/task?projectId")]
public class ProjectController : ControllerBase
{
    /*private readonly IProjectService _projectService;
    public ProjectController(IProjectService animalService)
    {
        _projectService = _projectService;
    }

    [HttpGet("")]
    public IActionResult GetProject([FromQuery] int IdProject)
    {
        var animals = _projectService.GetProject(IdProject);
        return Ok(animals);
    }*/
}
    