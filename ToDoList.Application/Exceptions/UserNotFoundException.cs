namespace ToDoList.Application.Exceptions
{
    public class UserNotFoundException : CustomException
    {
        public Guid Id { get; }

        public UserNotFoundException(Guid id) : base($"user with id: {id} not found") => Id = id;
    }
}
