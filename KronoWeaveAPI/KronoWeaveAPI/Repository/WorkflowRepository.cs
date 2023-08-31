using KronoWeaveAPI.Models;

namespace KronoWeaveAPI.Repository
{
    public class WorkflowRepository
    {
        KronoWeaveContext KronoWeaveContext = new KronoWeaveContext();


        public List<Workflows> GetActiveWorkflows()
        {
            List<Workflows> workflows = new List<Workflows>();

            workflows = KronoWeaveContext.Workflows.Where(x => x.Status == "Active").Select(x => x).ToList<Workflows>();

            return workflows;
        }
    }
}
