using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Magfinalproject.Models
{
    public class acadyear
    {
        public int id { get; set; }
        [Required]
        [Remote("Check_name", "acadyear", AdditionalFields = "id", ErrorMessage = ".هذا الفصل موجود مسبقا")]
        [Display(Name = "الفصل الدراسي")]
        public string name { get; set; }
        [Display(Name = "تاريخ الإنشاء")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MMMM d, yyyy, hh:mm tt}")]
        public DateTime date { get; set; }

        [Display(Name = "إسم المستخدم")]
        public string userid { get; set; }
        public virtual ApplicationUser user { get; set; }
        public virtual ICollection<subject> subject { get; set; }
        public virtual ICollection<student> student { get; set; }

    }
}