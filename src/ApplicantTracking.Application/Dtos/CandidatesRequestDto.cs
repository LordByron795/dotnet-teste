using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicantTracking.Application.DTOs
{
    public record CandidatesRequestDto([Required] string Name, [Required] string Surname, [Required] DateTime Birthdate, [Required] string Email, [Required] DateTime CreatedAt, DateTime LastUpdatedAt);
}
