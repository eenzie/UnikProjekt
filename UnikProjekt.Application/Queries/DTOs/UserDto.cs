﻿namespace UnikProjekt.Application.Queries.DTOs;

public class UserDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string MobileNumber { get; set; }
    public string Address { get; set; }
    //public List<string> RoleIds { get; set; }
    public byte[] RowVersion { get; set; } = [];
}
