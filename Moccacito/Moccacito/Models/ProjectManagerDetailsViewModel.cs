﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Moccacito.Models
{
    public class ProjectManagerDetailsViewModel
    {
        public string PictureUrl;
        public string Firstname;
        public string Lastname;
        public string Email;
        public string Telephone;
        public List<Worker> Workers;
    }
}