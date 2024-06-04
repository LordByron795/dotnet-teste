using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicantTracking.Domain.Entities
{
    [Table("Genres")]
    public class Candidates(string Name, string Surname, DateTime Birthdate, string Email,  DateTime? CreatedAt, DateTime LastUpdatedAt) : BaseEntity
    {
        [Required]
        [MaxLength(80)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        public string Surname { get; set; } = string.Empty;

        [Required]
        public DateTime Birthdate { get; set; } = DateTime.Now;

        [Required]
        [MaxLength(250)]
        public string Email { get; set; } =string.Empty;


        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        
        public DateTime LastUpdatedAt { get; set; } = DateTime.Now;


    }
}
