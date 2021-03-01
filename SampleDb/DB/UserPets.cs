using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SampleDb.DB
{
    public partial class UserPets
    {
        public int Id { get; set; }
        public string PetName { get; set; }
        public int UserId { get; set; }
    }
}
