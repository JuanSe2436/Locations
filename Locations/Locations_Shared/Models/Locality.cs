﻿using System.ComponentModel.DataAnnotations;

public class Locality
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    public ICollection<Location>? Locations { get; set; }
}
