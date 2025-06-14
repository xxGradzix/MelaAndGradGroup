namespace Data.API.Entities
{
    public abstract class IUser
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        //Role role { get; set; }
    }
}
