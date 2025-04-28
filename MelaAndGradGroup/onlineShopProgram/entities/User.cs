    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }

    public User() {}
    public User(String username, String password)
    {
        this.username = username;
        this.password = password;
    }
}
