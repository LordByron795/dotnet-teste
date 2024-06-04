using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicantTracking.Application.DTOs
{
    public record TimelinesRequestDto([Required]  int idTimelineType, [Required]  int idAggregateRoot, string oldData, string newData, [Required]  DateTime createdAt);
}
