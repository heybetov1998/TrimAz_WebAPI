namespace Business.Auth;

public class JWTConfig
{
    public string Key { get; set; }

    // refresh token time to live (in days), inactive tokens are
    // automatically deleted from the database after this time
    public int RefreshTokenTTL { get; set; }

    public JWTConfig()
    {
        Key = default!;
    }
}
