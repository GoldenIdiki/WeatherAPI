﻿using Microsoft.AspNetCore.Identity;

namespace WeatherAPI.Domain
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}