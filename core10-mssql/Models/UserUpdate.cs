using System.ComponentModel.DataAnnotations;

namespace core10_mssql.Models.dto;

public class UserUpdate
{        
    [Required]
    public string Firstname { get; set; }

    [Required]
    public string Lastname { get; set; }
    public string Password { get; set; }

    public string Mobile { get; set; }
    // public IFormFile Profilepic { get; set; }
    // public bool Twofactorenabled { get; set; }

    public DateTime UpdatedAt { get; set; }
}