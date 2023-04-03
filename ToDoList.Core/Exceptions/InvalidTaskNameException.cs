namespace ToDoList.Core.Exceptions;

public class InvalidTaskNameException : CustomException
{
    public string TaskName { get; }

    public InvalidTaskNameException(string taskName) 
        : base($"Task name {taskName} is invalid") 
        => TaskName = taskName;
}