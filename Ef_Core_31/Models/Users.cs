﻿namespace Ef_Core_31.Models
{
    public class Users
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public DateTime BithDate { get; set; }

        public ICollection<UserBooks> UserBooks { get; set; }
    }
}
