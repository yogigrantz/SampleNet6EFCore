using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestEFCore.Test;


[Table("Client", Schema = "data")]
public class Client
{
    public int ClientId { get; set; }
    [MaxLength(50), Required]
    public string Name { get; set; }
    [MaxLength(12), Required]
    public string Phone { get; set; }
    [MaxLength(60), Required]
    public string Email { get; set; }
    [MaxLength(50), Required]
    public string CompanyName { get; set; }
}
