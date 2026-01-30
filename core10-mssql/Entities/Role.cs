using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using core10_mssql.Entities;

namespace core10_mssql.Entities;

[Table("roles")]
public class Role {

    [Key]
    public int Id {get; set;}

    [Column("name",TypeName="varchar(20)")]
    [Required]
    public string Name {get; set;}

    public ICollection<User> Users { get; set; } = new List<User>();
}