using ATOEBackend.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IHttpActionResult> Post(Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Projects.Add(project);
            await db.SaveChangesAsync();
            return Created(project);
        }

        private bool ProjectsExists(int key)
        {
            return db.Projects.Any(p => p.ProjectId == key);
        }

        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Project> project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await db.Projects.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            project.Patch(entity);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectsExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(entity);
        }

        public async Task<IHttpActionResult> Put([FromODataUri] int key, Project update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.ProjectId)
            {
                return BadRequest();
            }
            db.Entry(update).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectsExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(update);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}