using System;
using Microsoft.AspNetCore.Identity;
using Olm.Common.Interfaces;

namespace Olm.Model.Entities
{
    public class AppUser: IdentityUser<Guid>
    {
        public AppUser() { }

        public AppUser(Guid id, string fullName, string email, bool isActive, DateTime birthDay)
        {
            Id = id;
            FullName = fullName;
            IsActive = isActive;
            BirthDay = birthDay;
        }
        public string FullName { get; set; }
        public bool IsActive { get; set; }
        public DateTime? BirthDay { set; get; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}