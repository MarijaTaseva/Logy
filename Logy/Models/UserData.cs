using System;
using System.Collections.Generic;

namespace Logy.Models
{
    public partial class UserData
    {
        public int UserDataId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public byte[] UserPhoto { get; set; }
        public string Comment { get; set; }
        public int? Pin { get; set; }

        public AspNetUsers User { get; set; }
    }
}
