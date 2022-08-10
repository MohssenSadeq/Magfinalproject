using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Magfinalproject.Models
{
    public class subject
    {
        public int id { get; set; }
        [Required]
      

        [Display(Name = "اسم القسم")]
        public int departmentid { get; set; }
        [Required]


        [Display(Name = "الفصل الدراسي")]
        public int acadyearid { get; set; }
        [Required]
        [Display(Name = "اسم المادة")]
        public string name { get; set; }
        [Required]
        [Display(Name = "المحاضرات")]
        public string lecture { get; set; }
       
        [Display(Name = "  المختبر")]
        public string lab { get; set; }
        [Required]
        [Display(Name = " الوحدة")]
        public string credit { get; set; }
        
        [Display(Name = "  الطلب")]
        public string prerequest { get; set; }
       
        [Display(Name = "تاريخ الإنشاء")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MMMM d, yyyy, hh:mm tt}")]
        public DateTime date { get; set; }
        [Display(Name = "إسم المستخدم")]
        public string userid { get; set; }
        public virtual ApplicationUser user { get; set; }


        public virtual department department { get; set; }
        public virtual acadyear acadyear { get; set; }
    }
}