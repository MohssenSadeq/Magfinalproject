using Magfinalproject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Magfinalproject.Models
{
    public class department
    {
        public int id { get; set; }
        [Required]
        [StringLength(70, ErrorMessage = "يجب أن يكون العنوان أقل من 60 حرف")]

        [Display(Name = "اسم القسم")]
        public string name { get; set; }

        [Display(Name = "صورة القسم")]
        public string photo { get; set; }
        [Required]
        [Display(Name = "نبذة عن القسم")]
        [AllowHtml]
        public string about { get; set; }
       
        public int collegeid { get; set; }
      
        [Display(Name = "إسم المستخدم")]
        public string userid { get; set; }
        public virtual ApplicationUser user { get; set; }


        public Mohsen dgreeid { get; set; }
        public virtual college college { get; set; }
        public virtual ICollection<Thesis> thesis { get; set; }


    }

}
public enum Mohsen 
{
       معيد,ماجيستير,دكتور,استاذ_مساعد,استاذ_مٌشارك,استاذ_مٌساعد,استاذ_مشارك,استاذ_بروفيسور,استاذ_متفرغ,استاذ_محاضر,استاذ_كرسي
}