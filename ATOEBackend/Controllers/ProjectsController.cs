using ATOEBackend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData;

namespace ATOEBackend.Controllers
{
    [EnableQuery]
    public class ProjectsController : ODataController
    {
        private ProjectContext db = new ProjectContext();

        public IQueryable<Project> Get()
        {
            return db.Projects;
        }
        
        public SingleResult<Project> Get(int key)
        {
            IQueryable<Project> result = db.Projects.Where(p => p.ProjectId == key);
            return SingleResult.Create(result);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}