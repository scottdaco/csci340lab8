using System.ComponentModel.DataAnnotations;


public class Lizard
{
    public int Id { get; set; }

    [StringLength(100, MinimumLength = 1)]
    [Required]
    public string? name { get; set; }

    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    [Required]
    [StringLength(50)]
    public string? region { get; set; }

    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    [Required]
    [StringLength(50)]
    public string? length { get; set; }
}