using ATOEBackend.Models;
using System.Linq;
using System.Web.Http;
using System.Web.OData;

namespace ATOEBackend.Controllers
{
    [EnableQuery]
    public class ResourcesController : ODataController
    {
        private ProjectContext db = new ProjectContext();

        public IQueryable<Resource> Get()
        {
            return db.Resources;
        }

        public SingleResult<Resource> Get(int key)
        {
            IQueryable<Resource> result = db.Resources.Where(p => p.ResourceId == key);
            return SingleResult.Create(result);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}