namespace core10_mssql.Models;

public class TokenModel {
    public string Email { get; set; }
    public string secretKey { get; set; }
    public bool verified { get; set; }        
}