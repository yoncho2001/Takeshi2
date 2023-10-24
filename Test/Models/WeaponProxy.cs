using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Takeshi.Models;

public class WeaponProxy
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int DamagePoints { get; set; }

    [DefaultValue(1)]
    [Range(1, 3, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int HeroClassType { get; set; } = 1;
}
