using ATOEServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.OData;

namespace ATOEServer.Controllers
{
    [EnableQuery]
    public class ProjectsController : ODataController
    {
        public IHttpActionResult Get()
        {
            List<Project> projects = new List<Project>();
            projects.Add(new Project() { PID = 1, Name = "Test" });

            return Ok(projects.AsQueryable());
        }
    }
}