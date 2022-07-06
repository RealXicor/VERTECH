using System;
using System.Collections.Generic;

namespace VERTECH.Models
{
    public partial class Inquiry
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserEmail { get; set; }
        public string? ProductName { get; set; }
        public string? ProductPrice { get; set; }
        public string? UserMsg { get; set; }
    }
}
