namespace WebApi
{
    public interface IJWTAuthenticationManager
    {
        string Authenticat(string userName, string Password);
    }
}
