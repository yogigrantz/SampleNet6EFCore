using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestEFCore.Test;


[Table("Candidate", Schema = "data")]
public class Candidate
{
    public int CandidateId { get; set; }
    [MaxLength(50), Required]
    public string Name { get; set; }
    [MaxLength(11), Required]
    public string SSN { get; set; }
    [MaxLength(50), Required]
    public string BioHeader { get; set; }
    [MaxLength(4000), Required]
    public string Bio { get; set; }
    [MaxLength(50), Required]
    public string CompanyName { get; set; }
}
