﻿namespace dotnet_rpg.Dtos.User
{
    public class UserRegisterDto
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        // Will contain more info about user in future
    }
}
