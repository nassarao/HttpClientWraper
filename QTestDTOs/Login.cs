namespace QTestDTOs

{

    public class Login
    {

        public string GrantType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Token Token { get; set; }

        public Login()
        {

        }

        public Login(string username, string password)
        {
            GrantType = "password";
            this.UserName = username;
            this.Password = password;
        }

    }


}
