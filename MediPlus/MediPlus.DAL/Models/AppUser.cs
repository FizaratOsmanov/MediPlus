﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MediPlus.DAL.Models
{
    public class AppUser :IdentityUser
    {


        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
