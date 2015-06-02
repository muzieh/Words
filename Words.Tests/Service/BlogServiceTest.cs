using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using DataAccess;
using Moq;
namespace Words.Tests.Service
{
    [TestClass]
    public class BlogServiceTest
    {
        [TestMethod]
        public void AddBlog_ContextCalled()
        {
            var moqContext = new Mock<IBloggingContext>(MockBehavior.Loose);
            var blog = new Blog() { BlogId = 1, Name = "abc", Posts = null, Url = string.Empty};
            moqContext.Setup(s => s.Blogs.Add(It.IsAny<Blog>()));
            var context = moqContext.Object;
            var service = new BlogService(context);
            service.AddBlog("abc", null);
            //moqContext.Verify(s => s.Blogs.Add(It.IsAny<Blog>()));
            moqContext.Verify(s => s.Blogs.Add(It.Is<Blog>(p =>p.Name == "abc" && p.Url == string.Empty)));
        }
    }
}
