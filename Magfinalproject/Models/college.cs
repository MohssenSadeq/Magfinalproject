using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Magfinalproject.Models
{
    public class college
    {
        public int id { get; set; }
        [Display(Name = " نوع المركز")]
        public int centerID { get; set; }
        public virtual center center { get; set; }
        [Required]
        [StringLength(70, ErrorMessage = "يجب أن يكون العنوان أقل من 60 حرف")]
        [Display(Name = "اسم الكلية")]
        public string name { get; set; }
        [Required]
        [Display(Name = "تاريخ التعديل")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MMMM d, yyyy, hh:mm tt}")]

        public DateTime date { get; set; }

        [Display(Name = "صورة الكلية")]
        public string photo { get; set; }
        [Required]
        [Display(Name = "نبذة عن الكلية")]
        [AllowHtml]
        public string about { get; set; }
        //[Required]
        //[Display(Name = "اهداف الكلية")]
        //public string goals { get; set; }
        //[Required]
        //[Display(Name = "الدرجات الممنوحة في الكلية")]
        //public string digrees { get; set; }
        //[Required]
        //[Display(Name = "للتواصل بالكلية")]
        //public string contact { get; set; }
        public string userid { get; set; }
        public virtual ApplicationUser user { get; set; }


        public virtual ICollection<staff> staffs { get; set; }
        public virtual ICollection<department> department { get; set; }
    }
}