using System.ComponentModel.DataAnnotations;

public class Location
{
    public int Id { get; set; }

    [Required]
    public int LocalTypeId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Number { get; set; } = string.Empty;

    [Required]
    public int LocationClassId { get; set; }

    [Required]
    [MaxLength(50)]
    public string LocationNumber { get; set; } = string.Empty;

    public int FloorNumber { get; set; }

    public int SquareMeters { get; set; }

    [Required]
    public int LocalityId { get; set; }

    [Required]
    public int LocalStateId { get; set; }

    [MaxLength(500)]
    public string Observation { get; set; } = string.Empty;
    public LocalType? LocalType { get; set; }
    public LocationClass? LocationClass { get; set; }
    public Locality? Locality { get; set; }
    public LocalState? LocalState { get; set; }
}
