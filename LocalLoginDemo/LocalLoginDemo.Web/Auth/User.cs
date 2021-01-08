namespace LocalLoginDemo.Web.Auth
{
    public class User
    {
        public string UserName { get; }

        public User(string userName)
        {
            this.UserName = userName;
        }
    }
}
