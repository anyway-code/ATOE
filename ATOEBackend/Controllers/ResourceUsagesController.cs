using ATOEBackend.Models;
using System.Linq;
using System.Web.Http;
using System.Web.OData;

namespace ATOEBackend.Controllers
{
    [EnableQuery]
    public class ResourceUsagesController : ODataController
    {
        private ProjectContext db = new ProjectContext();

        public IQueryable<ResourceUsage> Get()
        {
            return db.ResourceUsages;
        }

        public SingleResult<ResourceUsage> Get(int key)
        {
            IQueryable<ResourceUsage> result = db.ResourceUsages.Where(p => p.ResourceUsageId == key);
            return SingleResult.Create(result);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}