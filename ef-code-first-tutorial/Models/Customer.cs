using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_code_first_tutorial.Models; 
public class Customer {

    public int Id { get; set; } = 0;
    [StringLength(50)]
    [Required]
    public string Name { get; set; } = string.Empty;
    [StringLength(30)]
    public string City { get; set; } = string.Empty;
    [StringLength(2)]
    public string StateCode { get; set; } = "OH";
    [Column(TypeName ="decimal(9,2)")]
    public decimal Sales { get; set; }
    public bool Active { get; set; } = true;

    public virtual ICollection<Order> Orders { get; set; }

    public Customer() { }

}
