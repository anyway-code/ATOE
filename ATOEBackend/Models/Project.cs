using System.ComponentModel.DataAnnotations;

namespace ATOEBackend.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        public string Name { get; set; }

        public string ProjectNum { get; set; }
    }
}