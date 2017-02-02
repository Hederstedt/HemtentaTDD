using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HemtentaTdd2017.blog;
using NUnit.Framework;
using Moq;

namespace HemtentaTester
{
    [TestFixture]
   public class BlogTests
    {
        private Blog b;
        private User u;
        private Page p;

        [SetUp]
        public void SetUp()
        {
            b = new Blog();
            u = new User("username");
            p = new Page { Title = "hej", Content = "Svej" };
        }

        #region UserLogin/outTests


        [Test]
        public void LogInUser_NullValues_ThrowsException()
        {
            Assert.That(() => b.LoginUser(null), Throws.TypeOf<NoUserException>());
        }
        [Test]
        public void LogInUser_pass()
        {
            //var mock = new Mock<IAuthenticator>();
            //mock.Setup(x => x.GetUserFromDatabase("username")).Returns(new User("username"));
            //IAuthenticator au = mock.Object;
            b.LoginUser(u);
            Assert.That(b.UserIsLoggedIn, Is.True);
            //au.GetUserFromDatabase("username");                   
            //Assert.That(au.GetUserFromDatabase("username"), Is.EqualTo(u.Name));                      
        }
        [Test]
        public void LogInUser_Fail()
        {
            Assert.That(b.UserIsLoggedIn, Is.False);
        }
        [Test]
        public void LogOutUser_ThrowsException()
        {
            Assert.That(() => b.LogoutUser(null), Throws.TypeOf<NoUserException>());
        }
        [Test]
        public void LogOutUser_pass()
        {
            b.LogoutUser(u);
            Assert.That(b.UserIsLoggedIn, Is.False);
        }
        #endregion
        #region PageTests


        [Test]
        public void Page_Throws_Exception_If_PageIsNull()
        {                     
            Assert.That(() => b.PublishPage(null), Throws.TypeOf<BadPageException>());
        }

        
        [TestCase("","")]
        [TestCase(null, "Hej")]
        [TestCase("hej", null)]
        [TestCase("hej", "")]
        [TestCase("", "hej")]
        public void Page_Throws_Exception_If_PageParametersIsNull(string title, string content)
        {
            Page TCp = new Page
            {
                Title = title,
                Content = content
            };
            Assert.That(() => b.PublishPage(TCp), Throws.TypeOf<BadPageException>());
        }

        [Test]
        public void Page_Returns_True_If_UserIsLoggedIn_And_Page_OK()
        {         
            b.LoginUser(u);
            Assert.That(b.PublishPage(p), Is.True);
        }
        [Test]
        public void Page_Returns_FalseIf_UserIsNotLoggedIn_And_Page_OK()
        {
            User n = new User("Benny");
            b.LoginUser(n);
            Assert.That(b.PublishPage(p), Is.False);

        }
        #endregion
        #region SendEmailTests

       
        [TestCase("", "", "")]
        [TestCase(null, "hej", "svej")]
        [TestCase("svej", null, "hej")]
        [TestCase("hej", "svej", null)]
        [TestCase("", null, "hej")]
        [TestCase("hej", "", null)]
        [TestCase(null, "svej", "")]
        public void SendEmail_Parameter_Test_Throws_BadMailParameterExcption
            (string address, string caption, string body)
        {         
            Assert.That(() => b.SendEmail(address, caption, body), 
                Throws.TypeOf<BadMailParameterExcption>());
        }
        [Test]
        public void SendEmail_Returns_0()
        {
            int result = b.SendEmail("hej", "Svej", "Nej");
            Assert.That(result, Is.EqualTo(0));
        }
        [Test]
        public void SendEmail_Returns_1()
        {
            b.LoginUser(u);
            int result = b.SendEmail("hej", "Svej", "Nej");
            Assert.That(result, Is.EqualTo(1));
        }
        #endregion

    }
}
