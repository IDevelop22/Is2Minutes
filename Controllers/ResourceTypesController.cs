using Is2MinutesBackend.PostgreSQL;
using Is2MinutesBackend.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Is2MinutesBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceTypesController : ControllerBase
    {
        private readonly IEverythingRepo<ResourceType> _resourceTypeRepo;

        public ResourceTypesController(IEverythingRepo<ResourceType> resourceTypeRepo)
        {
            _resourceTypeRepo = resourceTypeRepo;
        }

        [HttpPost]
        public async Task<ActionResult<ResourceType>> AddResourceType(ResourceType resourceType)
        {
            var result = await _resourceTypeRepo.Add(resourceType);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResourceType>>> GetAll()
        {
            var result = await _resourceTypeRepo.GetAll();
            return Ok(result);
        }
}
}
