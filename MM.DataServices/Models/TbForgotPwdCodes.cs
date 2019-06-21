using System;
using System.Collections.Generic;

namespace MM.DataServices.Models
{
    public partial class TbForgotPwdCodes
    {
        public int CodeId { get; set; }
        public string Email { get; set; }
        public DateTime? CodeDate { get; set; }
        public int? Status { get; set; }
    }
}
