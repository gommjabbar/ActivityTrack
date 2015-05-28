using ActivityTrack.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActivityTrack.Models
{
    [Table("Activities")]
    public class ActivityEO
    {
        public int Id { get; set; }

        [Display(Name="Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Description")]
        public string ActivityDescription { get; set; }

        [Display(Name = "Type")]
        public int ActivtyTypeId { get; set; }
        public virtual ActivityType ActivityType { get; set; }

        [Display(Name = "Project Id")]
        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }
        
        public IEnumerable<SelectListItem> TypesList { get; set; }

        public ActivityEO()
        {

        }
        public ActivityEO(activity a)
        {            
        }
    }
}