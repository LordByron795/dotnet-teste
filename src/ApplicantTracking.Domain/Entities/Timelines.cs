using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicantTracking.Domain.Entities
{
    [Table("Timelines")]
    public class Timelines(int  idTimelineType, int idAggregateRoot, string oldData, string newData, DateTime? createdAt) : BaseEntity
    {
        [Required]      
        public int IdTimelineType { get; set; } = idTimelineType;

        [Required]
        [ForeignKey("Root")]
        public int IdAggregateRoot { get; set; } = idAggregateRoot;

        public string OldData { get; set; } = oldData;

        public string NewData { get; set; } = newData;

        public DateTime? CreatedAt { get; set; } = createdAt;

    }
}
