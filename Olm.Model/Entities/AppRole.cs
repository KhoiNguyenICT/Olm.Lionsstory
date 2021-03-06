﻿using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Olm.Model.Entities
{
    public class AppRole: IdentityRole<Guid>
    {
        public AppRole() : base()
        {

        }

        public AppRole(string name, string description): base(name)
        {
            Description = description;
        }
        [StringLength(250)]
        public string Description { get; set; }
    }
}