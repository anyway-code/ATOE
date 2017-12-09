using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ATOEServer.Models
{
    public class Project
    {
        [Key]
        public int PID { get; set; }

        public string Name { get; set; }
    }
}