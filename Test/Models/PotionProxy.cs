using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Takeshi.Models;

public class PotionProxy
{

    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    
    [DefaultValue(1)]
    [Range(1, 3, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int AffectingField { get; set; } = 1;

    public int AffectingValue { get; set; }
}
