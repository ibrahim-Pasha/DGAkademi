namespace WebApi
{
    public interface IUserService
    {
        /// <summary>
        /// Method to chack if user registered
        /// </summary>
        /// <param name="UserName">Required string UserName</param>
        /// <param name="password">Required string Password</param>
        /// <returns></returns>
        User AuthenticateUser(string UserName, string password);
        /// <summary>
        /// Method to add new user to db
        /// </summary>
        /// <param name="name">Required string Name</param>
        /// <param name="surName">Required string SurName</param>
        /// <param name="userName">Required string UserName</param>
        /// <param name="password">Required string Password</param>
        void AddUser(string name, string surName, string userName, string password);
    }
}
