using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using LewandowskiProject.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LewandowskiProject.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            // Default UserStore constructor uses the default connection string named: DefaultConnection
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);

            var user = new IdentityUser() { UserName = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);

            if (result.Succeeded)
            {
               StatusMessage.Text = string.Format("User " + user.Email + " was created successfully!", user.Email);
            }
            else
            {
               StatusMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}