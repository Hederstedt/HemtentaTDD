using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemtentaTdd2017.blog
{
    public class Blog : IBlog
    {
        public bool UserIsLoggedIn { get; set; }

        public void LoginUser(User u)
        {
            bool BadUserFormat = u == null || string.IsNullOrEmpty(u.Name)
                || string.IsNullOrEmpty(u.Password);
            if (BadUserFormat)
            {
                throw new NoUserException();
            }
            if (u.Name == "username")
            {
                UserIsLoggedIn = true;
            }
            
        }

        public void LogoutUser(User u)
        {
            if (u == null)
            {
                throw new NoUserException();
            }
                UserIsLoggedIn = false;         
        }

        public bool PublishPage(Page p)
        {
            bool BadPageFormat = p == null || string.IsNullOrEmpty(p.Content)
                 || string.IsNullOrEmpty(p.Title);
            if (BadPageFormat)
            {
                throw new BadPageException();
            }
            if (UserIsLoggedIn == true)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public int SendEmail(string address, string caption, string body)
        {
            bool BadMailParameters = string.IsNullOrEmpty(address) 
                || string.IsNullOrEmpty(caption)
                   || string.IsNullOrEmpty(body);
            if (BadMailParameters)
            {
                throw new BadMailParameterExcption();
            }
            if (UserIsLoggedIn == true)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
