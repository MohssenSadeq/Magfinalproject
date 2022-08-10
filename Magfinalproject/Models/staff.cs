using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Magfinalproject.Models
{
    public class staff
    {
        public int id { get; set; }
        [Required]
        [StringLength(70, ErrorMessage = "يجب أن يكون العنوان أقل من 60 حرف")]                 
        [Display(Name = "الأسم الكامل بالعربي")]

        public string name { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "يجب أن يكون العنوان أقل من 60 حرف")]
        [Display(Name = "الأسم الأول بالأنجليزي")]
        public string name_en  { get; set; }
        [Display(Name = "تاريخ التعديل")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MMMM d, yyyy, hh:mm tt}")]

        public DateTime date  { get; set; }
        
        [Display(Name = "الصورة")]
        public string photo { get; set; }
        [Display(Name = "المسيرة العلمية")]
        [AllowHtml]
        public string about { get; set; }

        [Display(Name = "الكلية ")]
        public int collegesid { get; set; }
    
        public virtual college colleges { get; set; }


        [Display(Name = "إسم المستخدم")]
        public string userid { get; set; }
        public virtual ApplicationUser user { get; set; }

        [Display(Name = "إسم المستخدم")]
        public string user_name { get; set; }
        [Display(Name = "كلمة السر")]
        public string password  { get; set; }
  
        public virtual ICollection<Request_to_edit> request_to_edit { get; set; }
        [Display(Name = "الدرجة العلمية")]

        public Mohsen dgreesid { get; set; }
     
    }

}
