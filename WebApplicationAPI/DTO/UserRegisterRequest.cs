﻿namespace WebApplicationAPI.DTO
{
    public class UserRegisterRequest
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }

        public string Role { get; set; }

    }
}
