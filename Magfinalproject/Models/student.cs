using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Magfinalproject.Models
{
    public class student
    {
        public int id { get; set; }
        [Required]


        [Display(Name = "اسم القسم")]
        public int departmentid { get; set; }
        [Required]


        [Display(Name = "الفصل الدراسي")]
        public int acadyearid { get; set; }
        [Required]
        [Display(Name = "رقم القيد")]
        public string stuid { get; set; }
        [Required]
        [Display(Name = " اسم الطالب")]
        public string name { get; set; }

        [Display(Name = "  النوع")]
        public string type { get; set; }
     
        [Display(Name = " الصوره ")]
        public string photo { get; set; }

        [Display(Name = "  الحالة")]
        public string state { get; set; }
        [Display(Name = "  ملاحظة")]
        public string note { get; set; }
        
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