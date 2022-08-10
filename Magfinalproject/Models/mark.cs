using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Magfinalproject.Models
{
    public class mark
    {
        public int id { get; set; }
        [Required]


        [Display(Name = "اسم القسم")]
        public int departmentid { get; set; }
        [Required]


        [Display(Name = "الفصل الدراسي")]
        public int acadyearid { get; set; }
        [Required]


        [Display(Name = "المادة الدراسي")]
        public int subjectid { get; set; }
        [Required]


        [Display(Name = " اسم الطالب")]
        public int studentid { get; set; }
        [Required]
        [Display(Name = " السعة الفصلية")]
        public double sess { get; set; }
        [Required]
        [Display(Name = " الامتحان ")]
        public double exam { get; set; }

        [Display(Name = "  الدرجة")]
        public string grade { get; set; }

        [Display(Name = "  الحالة")]
        public bool state { get; set; }
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
        public virtual subject subject { get; set; }
        public virtual student student { get; set; }
    }
}