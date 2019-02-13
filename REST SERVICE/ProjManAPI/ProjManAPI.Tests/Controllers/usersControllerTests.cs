//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq.EntityFramework;






namespace ProjManAPI.Controllers.Tests
{

    [TestFixture]
    public class usersControllerTests
    {

        [Test]
        public void usersControllerTest()
        {
            var service = new usersController();
            Assert.IsNotNull(service);
        }
        [Test]
        public void usersControllerParamTest()
        {
            var service = new usersController(new MSBI_NBREQSEntities1());
            Assert.IsNotNull(service);
        }

        [Test]
        public void GetusersTest()
        {
            var data = new List<user>
            {
               new user { user_id = 7, f_name = "kishore", l_name = "chinnu", employee_id=10, task_id=3, project_id=1 },
               new user { user_id = 8, f_name = "d", l_name = "da", employee_id = 1, task_id = 3, project_id = 1 },
               new user { user_id = 9, f_name = "ddasdsad", l_name = "da", employee_id = 1525, task_id = 3, project_id = 1 }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<user>>();
            mockSet.As<IQueryable<user>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<user>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<user>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<user>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());


            var mockContext = new Mock<MSBI_NBREQSEntities1>();
            mockContext.Setup(c => c.users).Returns(mockSet.Object);

            var service = new usersController(mockContext.Object);
            var blogs = service.Getusers();

            Assert.AreEqual(data.Select(c => c.user_id == 7) , blogs.Select(c => c.user_id == 7));
            Assert.AreEqual(data.Select(c => c.user_id == 9), blogs.Select(c => c.user_id == 9));
            Assert.AreEqual(data.Count(), blogs.Count());

        }

        [Test]
        public void GetuserTest()
        {
            var data = new List<user>
            {
               new user { user_id = 7, f_name = "kishore", l_name = "chinnu", employee_id=10, task_id=3, project_id=1 },
               new user { user_id = 8, f_name = "d", l_name = "da", employee_id = 1, task_id = 3, project_id = 1 },
               new user { user_id = 9, f_name = "ddasdsad", l_name = "da", employee_id = 1525, task_id = 3, project_id = 1 }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<user>>();


            mockSet.As<IQueryable<user>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<user>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<user>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<user>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            mockSet.Setup(set => set.Find(It.IsAny<int>()))
                .Returns<object[]>(ids => data.FirstOrDefault(y => y.user_id == (int)ids[0]));


            var mockContext = new Mock<MSBI_NBREQSEntities1>();
            mockContext.Setup(c => c.users).Returns(mockSet.Object);

            var service = new usersController(mockContext.Object);
            IHttpActionResult actionResult = service.Getuser(7);
            var blogs = actionResult as OkNegotiatedContentResult<user>;



            Assert.IsNotNull(blogs);
            Assert.IsNotNull(blogs.Content);
            Assert.AreEqual("kishore", blogs.Content.f_name);
        }

        [Test]
        public void GetuserTestNull()
        {
            var data = new List<user>
            {
               new user { user_id = 7, f_name = "kishore", l_name = "chinnu", employee_id=10, task_id=3, project_id=1 },
               new user { user_id = 8, f_name = "d", l_name = "da", employee_id = 1, task_id = 3, project_id = 1 },
               new user { user_id = 9, f_name = "ddasdsad", l_name = "da", employee_id = 1525, task_id = 3, project_id = 1 }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<user>>();


            mockSet.As<IQueryable<user>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<user>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<user>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<user>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mockSet.Setup(set => set.Find(It.IsAny<int>()))
                .Returns<object[]>(ids => data.FirstOrDefault(y => y.user_id == (int)ids[0]));


            var mockContext = new Mock<MSBI_NBREQSEntities1>();
            mockContext.Setup(c => c.users).Returns(mockSet.Object);

            var service = new usersController(mockContext.Object);
            IHttpActionResult actionResult = service.Getuser(127);
            var blogs = actionResult as OkNegotiatedContentResult<user>;


            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
            NUnit.Framework.Assert.IsNull(blogs);
            
        }

      
        [Test]
        public void PutuserTest()
        {
            var data = new List<user>
            {
               new user { user_id = 7, f_name = "kishore", l_name = "chinnu", employee_id=10, task_id=3, project_id=1 },
               new user { user_id = 8, f_name = "d", l_name = "da", employee_id = 1, task_id = 3, project_id = 1 },
               new user { user_id = 9, f_name = "ddasdsad", l_name = "da", employee_id = 1525, task_id = 3, project_id = 1 }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<user>>();


            mockSet.As<IQueryable<user>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<user>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<user>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<user>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mockSet.Setup(set => set.Find(It.IsAny<int>()))
                .Returns<object[]>(ids => data.FirstOrDefault(y => y.user_id == (int)ids[0]));


            var mockContext = new Mock<MSBI_NBREQSEntities1>();
            mockContext.Setup(c => c.users).Returns(mockSet.Object);

            var service = new usersController(mockContext.Object);
            IHttpActionResult actionResult = service.Putuser(new user { user_id = 10, f_name = "kishore", l_name = "da", employee_id = 1525, task_id = 3, project_id = 1 });
            var blogs = actionResult as OkNegotiatedContentResult<user>;

            mockContext.Verify(m => m.SaveChanges(), Times.Once());
            NUnit.Framework.Assert.IsNull(blogs);
        }
       
        [Test]
        public void PostuserTest()
        {
            var mockSet = new Mock<DbSet<user>>();
          
            var mockContext = new Mock<MSBI_NBREQSEntities1>();
            mockContext.Setup(m => m.users).Returns(mockSet.Object);
            
            var service = new usersController(mockContext.Object);
            IHttpActionResult actionResult=service.Postuser(new user { user_id = 11, f_name = null, l_name = "da", employee_id = 1, task_id = 3, project_id = 1 });

            mockSet.Verify(m => m.Add(It.IsAny<user>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Test]
        public void DeleteuserTestNUL()
        {
            var data = new List<user>
            {
               new user { user_id = 7, f_name = "kishore", l_name = "chinnu", employee_id=10, task_id=3, project_id=1 },
               new user { user_id = 8, f_name = "d", l_name = "da", employee_id = 1, task_id = 3, project_id = 1 },
               new user { user_id = 9, f_name = "ddasdsad", l_name = "da", employee_id = 1525, task_id = 3, project_id = 1 }
            };//.AsQueryable();

            var mockSet = new Mock<DbSet<user>>();
            var mockContext = new Mock<MSBI_NBREQSEntities1>();
            
            mockSet.Setup(set => set.Remove(It.IsAny<user>())).Callback<user>((entity) => data.Remove(entity));
            mockSet.As<IQueryable<user>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mockSet.Setup(set => set.Find(It.IsAny<int>())).Returns<object[]>(ids => data.FirstOrDefault(y => y.user_id == (int)ids[0]));
            
            mockContext.Setup(c => c.users).Returns(mockSet.Object);

            var service = new usersController(mockContext.Object);
            IHttpActionResult actionResult = service.Deleteuser(9);
            var blogs = actionResult as OkNegotiatedContentResult<user>;

            mockContext.Verify(m => m.SaveChanges(), Times.Once());
             Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(actionResult, typeof(OkNegotiatedContentResult<user>));

        }

        [Test]
        public void DeleteuserTest()
        {
            var data = new List<user>
            {
               new user { user_id = 7, f_name = "kishore", l_name = "chinnu", employee_id=10, task_id=3, project_id=1 },
               new user { user_id = 8, f_name = "d", l_name = "da", employee_id = 1, task_id = 3, project_id = 1 },
               new user { user_id = 9, f_name = "ddasdsad", l_name = "da", employee_id = 1525, task_id = 3, project_id = 1 }
            };//.AsQueryable();

            var mockSet = new Mock<DbSet<user>>();
            var mockContext = new Mock<MSBI_NBREQSEntities1>();

            mockSet.Setup(set => set.Remove(It.IsAny<user>())).Callback<user>((entity) => data.Remove(entity));
            mockSet.As<IQueryable<user>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mockSet.Setup(set => set.Find(It.IsAny<int>())).Returns<object[]>(ids => data.FirstOrDefault(y => y.user_id == (int)ids[0]));


            mockContext.Setup(c => c.users).Returns(mockSet.Object);

            var service = new usersController(mockContext.Object);
            IHttpActionResult actionResult = service.Deleteuser(11);
           
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        
    }
}