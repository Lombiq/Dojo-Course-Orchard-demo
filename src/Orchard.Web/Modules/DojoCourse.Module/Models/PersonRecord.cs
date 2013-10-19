﻿using Orchard.Data.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DojoCourse.Module.Models
{
    public class PersonRecord
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual Sex Sex { get; set; }

        public virtual DateTime? BirthDateUtc { get; set; }

        [StringLengthMax]
        public virtual string Biography { get; set; }

        public PersonRecord()
        {
            Biography = "No bio written yet.";
        }
    }

    public enum Sex
    {
        Male,
        Female
    }
}