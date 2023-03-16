namespace AlumniNetworkAPI.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string username) : base($"User {username} already exists")
        {

        }
    }
}
