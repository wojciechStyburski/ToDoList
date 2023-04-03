﻿namespace ToDoList.Application.DataTransferObject;

public class UserDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Role { get; set; }
    public DateTime CreatedAt { get; set; }
}