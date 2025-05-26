using System.ComponentModel.DataAnnotations;
public class LocalState
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Description { get; set; } = string.Empty;

    public ICollection<Location>? Locations { get; set; }
}
