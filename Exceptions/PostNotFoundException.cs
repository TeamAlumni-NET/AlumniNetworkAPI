namespace AlumniNetworkAPI.Exceptions
{
    public class PostNotFoundException: Exception
    {
        public PostNotFoundException(int id) : base($"Post with id {id} was not found")
        {

        }
    }
}
