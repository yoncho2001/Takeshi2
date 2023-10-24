using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Takeshi.Models;

public class ArmorProxy
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int ArmorPoints { get; set; }
}
