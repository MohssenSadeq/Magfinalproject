using Magfinalproject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;
using System.Linq;

[assembly: OwinStartupAttribute(typeof(Magfinalproject.Startup))]
namespace Magfinalproject
{
    public partial class Startup
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateDefaultRolesAndUser();
            CreateDefaultRolesAndUsers();
            CreateDefaultRolesAndUserentery();
            cat();
        }
        public void CreateDefaultRolesAndUser()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            IdentityRole role = new IdentityRole();
            if (!roleManager.RoleExists("Magic"))
            {
                role.Name = "Magic";

                roleManager.Create(role);
                ApplicationUser user = new ApplicationUser();
                user.UserName = "Magic@Dev.mag";
                user.UserType = "Magic";
                user.nikname = "Magic";
                user.LockoutEnabled = true;

                user.Email = "Magic@Dev.mag";
                var Check = userManager.Create(user, "M.kh2020");
                if (Check.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Magic");
                }
            }
        }
        public void CreateDefaultRolesAndUserentery()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            IdentityRole role = new IdentityRole();
            if (!roleManager.RoleExists("User"))
            {
                role.Name = "User";
                roleManager.Create(role);
                ApplicationUser user = new ApplicationUser();
                user.UserName = "userentry@adenuni.edu";
                user.UserType = "User";
                user.nikname = "مدخل بيانات";
                user.LockoutEnabled = true;

                user.Email = "userentry@adenuni.edu";
                var Check = userManager.Create(user, "M.kh2020");
                if (Check.Succeeded)
                {
                    userManager.AddToRole(user.Id, "User");
                }
            }
        }
        public void CreateDefaultRolesAndUsers()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            IdentityRole role = new IdentityRole();
            if (!roleManager.RoleExists("Admins"))
            {                                                                       
                role.Name = "Admins";
                roleManager.Create(role);
                ApplicationUser user = new ApplicationUser();
                user.UserName = "adenuni.mag@gmail.com";
                user.UserType = "Admins";
                user.nikname = "مسؤوول";
                user.LockoutEnabled = true;    
                user.Email = "adenuni.mag@gmail.com";
                var Check = userManager.Create(user, "M.kh2020");
                if (Check.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admins");
                }
            }
          
            
         

        }
        public void cat()
        {
            var cat = db.Categories;
            if (cat.Count() == 0)
            {
                db.Categories.Add(new Categorie { classname = "الأحداث", date = DateTime.Now });
                db.Categories.Add(new Categorie { classname = "الأخبار", date = DateTime.Now });
                db.Categories.Add(new Categorie { classname = "الطلاب", date = DateTime.Now });
                db.Categories.Add(new Categorie { classname = "مجتمع محلي", date = DateTime.Now });
                db.Categories.Add(new Categorie { classname = "الخريجين", date = DateTime.Now });
                db.Categories.Add(new Categorie { classname = "حول الجامعة", date = DateTime.Now });
                db.Categories.Add(new Categorie { classname = "القبول والتسجيل", date = DateTime.Now });
                db.Categories.Add(new Categorie { classname = "الشئون الأكاديمية", date = DateTime.Now });
                db.Categories.Add(new Categorie { classname = "الدراسات العلياء والبحث العلمي", date = DateTime.Now });
                db.SaveChanges();
              
            }
        }
      

    }
    }

