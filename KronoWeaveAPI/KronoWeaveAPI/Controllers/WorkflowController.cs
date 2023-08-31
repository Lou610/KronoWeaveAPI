using KronoWeaveAPI.Models;
using KronoWeaveAPI.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KronoWeaveAPI.Controllers
{
    [EnableCors("KronoWeave")]
    [ApiController]
    public class WorkflowController : ControllerBase
    {
        WorkflowRepository WorkflowRepository = new WorkflowRepository();

        [EnableCors("KronoWeave")]
        [HttpGet]
        [Route("api/GetActiveWorkflows")]
        public List<Workflows> GetActiveWorkflows()
        {
            List<Workflows> workflows = new List<Workflows>();

            workflows = WorkflowRepository.GetActiveWorkflows();

            return workflows;
        }
    }
}
