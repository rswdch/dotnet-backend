﻿namespace dotnet_rpg.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public byte[] PasswordHash { get; set; } = new byte[0];
        public byte[] PasswordSalt { get; set; } = new byte[0];
        public List<Character>? Characters { get; set; }
    }
}
