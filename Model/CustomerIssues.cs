using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BCT.SwaggerAPI.Model
{
    public class CustomerIssues
    {
        public int Id { get; set; }
        [Required]
        public string Issue { get; set; } = "Duplicate";
        [Required]
        public string CreationDate { get; set; } = "2021-01-01";
        [Required]
        public string IssueTrackingDate { get; set; } = "2021-02-28";
        [Required]
        public string Status { get; set; } = "Pending";
        [Required]
        public string Amount { get; set; } = "100.00";
        public string UserLastUpdated { get; set; } = "ez001";
       
    }
}
