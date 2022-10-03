namespace Entity.DTO.User;

public class RevokeTokenRequest
{
    public string Token { get; set; }

    public RevokeTokenRequest()
    {
        Token = default!;
    }
}
