namespace AlumniNetworkAPI.Exceptions
{
    public class EventNotFoundException: Exception
    {
        public EventNotFoundException(int id):base($"Event with id {id} was not found")
        { 
        
        }
    }
}
