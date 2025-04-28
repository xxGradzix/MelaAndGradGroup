
public class UserDTO
{
    public string username { get; set; }
    public string password { get; set; }

    public UserDTO(String username, String password)
    {
        this.username = username;
        this.password = password;
    }

}
