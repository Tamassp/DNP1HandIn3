using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models {
public class Person {
    [Required, Key, MaxLength(25)]
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string HairColor { get; set; }
    [Required]
    public string EyeColor { get; set; }
    [Required]
    public int Age { get; set; }
    [Required]
    public float Weight { get; set; }
    [Required]
    public int Height { get; set; }
    [Required]
    public string Sex { get; set; }
}


}