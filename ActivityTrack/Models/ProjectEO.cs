using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActivityTrack.Models
{
    [Table("Projects")]
    public class ProjectEO: BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ActivityEO> Activities { get; set; }
    }
}