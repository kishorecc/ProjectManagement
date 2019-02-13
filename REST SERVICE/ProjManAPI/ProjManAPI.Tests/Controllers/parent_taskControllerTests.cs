using ProjManAPI.Controllers;
using System;
using Moq;
using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjManAPI.Controllers.Tests
{

    [TestFixture]
    public class parent_taskControllertests
    {
        [Test]
        public void parent_taskControllerTest()
        {
            var service = new parent_taskController();
            Assert.IsNotNull(service);
        }
        [Test]
        public void parent_taskControllerParamTest()
        {
            var service = new parent_taskController(new MSBI_NBREQSEntities1());
            Assert.IsNotNull(service);
        }
        [Test]
        public void GetPTsTest()
        {
            var data = new List<parent_task>
            {
               new parent_task { parent_id = 1, parent_task1="Task1" },
               new parent_task { parent_id = 2, parent_task1="Task2" },
               new parent_task { parent_id = 3, parent_task1="Task3" },


            }.AsQueryable();

            var mockSet = new Mock<DbSet<parent_task>>();
            mockSet.As<IQueryable<parent_task>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<parent_task>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<parent_task>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<parent_task>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());


            var mockContext = new Mock<MSBI_NBREQSEntities1>();
            mockContext.Setup(c => c.parent_task).Returns(mockSet.Object);

            var service = new parent_taskController(mockContext.Object);
            var blogs = service.Getparent_task();

            Assert.AreEqual(data.Select(c => c.parent_id == 1), blogs.Select(c => c.parent_id == 1));
            Assert.AreEqual(data.Select(c => c.parent_id == 2), blogs.Select(c => c.parent_id == 2));
            Assert.AreEqual(data.Count(), blogs.Count());

        }

        [Test]
        public void GetPTTest()
        {
            var data = new List<parent_task>
            {
               new parent_task { parent_id = 1, parent_task1="Task1" },
               new parent_task { parent_id = 2, parent_task1="Task2" },
               new parent_task { parent_id = 3, parent_task1="Task3" },


            }.AsQueryable();

            var mockSet = new Mock<DbSet<parent_task>>();
            mockSet.As<IQueryable<parent_task>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<parent_task>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<parent_task>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<parent_task>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            mockSet.Setup(set => set.Find(It.IsAny<int>()))
                .Returns<object[]>(ids => data.FirstOrDefault(y => y.parent_id == (int)ids[0]));


            var mockContext = new Mock<MSBI_NBREQSEntities1>();
            mockContext.Setup(c => c.parent_task).Returns(mockSet.Object);

            var service = new parent_taskController(mockContext.Object);
            IHttpActionResult actionResult = service.Getparent_task(1);
            var blogs = actionResult as OkNegotiatedContentResult<parent_task>;



            Assert.IsNotNull(blogs);
            Assert.IsNotNull(blogs.Content);
            Assert.AreEqual("Task1", blogs.Content.parent_task1);
        }
        [Test]
        public void GetPTTestNULL()
        {
            var data = new List<parent_task>
            {
               new parent_task { parent_id = 1, parent_task1="Task1" },
               new parent_task { parent_id = 2, parent_task1="Task2" },
               new parent_task { parent_id = 3, parent_task1="Task3" },


            }.AsQueryable();

            var mockSet = new Mock<DbSet<parent_task>>();
            mockSet.As<IQueryable<parent_task>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<parent_task>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<parent_task>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<parent_task>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            mockSet.Setup(set => set.Find(It.IsAny<int>()))
                .Returns<object[]>(ids => data.FirstOrDefault(y => y.parent_id == (int)ids[0]));


            var mockContext = new Mock<MSBI_NBREQSEntities1>();
            mockContext.Setup(c => c.parent_task).Returns(mockSet.Object);

            var service = new parent_taskController(mockContext.Object);
            IHttpActionResult actionResult = service.Getparent_task(12);
            var blogs = actionResult as OkNegotiatedContentResult<parent_task>;

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
            NUnit.Framework.Assert.IsNull(blogs);
        }


        [Test]
        public void PutPTTest()
        {
            var data = new List<parent_task>
            {
               new parent_task { parent_id = 1, parent_task1="Task1" },
               new parent_task { parent_id = 2, parent_task1="Task2" },
               new parent_task { parent_id = 3, parent_task1="Task3" },


            }.AsQueryable();

            var mockSet = new Mock<DbSet<parent_task>>();
            mockSet.As<IQueryable<parent_task>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<parent_task>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<parent_task>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<parent_task>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            mockSet.Setup(set => set.Find(It.IsAny<int>()))
                .Returns<object[]>(ids => data.FirstOrDefault(y => y.parent_id == (int)ids[0]));


            var mockContext = new Mock<MSBI_NBREQSEntities1>();
            mockContext.Setup(c => c.parent_task).Returns(mockSet.Object);

            var service = new parent_taskController(mockContext.Object);
            IHttpActionResult actionResult = service.Putparent_task(new parent_task { parent_task1 = "Task44", parent_id = 44 });
            var blogs = actionResult as OkNegotiatedContentResult<parent_task>;

            mockContext.Verify(m => m.SaveChanges(), Times.Once());
            NUnit.Framework.Assert.IsNull(blogs);
        }


        [Test]
        public void PostPTTest()
        {
            var mockSet = new Mock<DbSet<parent_task>>();

            var mockContext = new Mock<MSBI_NBREQSEntities1>();
            mockContext.Setup(m => m.parent_task).Returns(mockSet.Object);

            var service = new parent_taskController(mockContext.Object);
            IHttpActionResult actionResult = service.Postparent_task(new parent_task { parent_task1 = "Task44", parent_id = 44 });

            mockSet.Verify(m => m.Add(It.IsAny<parent_task>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
        [Test]
        public void DeletePTTest()
        {
            var data = new List<parent_task>
            {
               new parent_task { parent_id = 1, parent_task1="Task1" },
               new parent_task { parent_id = 2, parent_task1="Task2" },
               new parent_task { parent_id = 3, parent_task1="Task3" },


            };//.AsQueryable();

            var mockSet = new Mock<DbSet<parent_task>>();
            
            mockSet.As<IQueryable<parent_task>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            mockSet.Setup(set => set.Find(It.IsAny<int>()))
                .Returns<object[]>(ids => data.FirstOrDefault(y => y.parent_id == (int)ids[0]));
            var mockContext = new Mock<MSBI_NBREQSEntities1>();
            mockSet.Setup(set => set.Remove(It.IsAny<parent_task>())).Callback<parent_task>((entity) => data.Remove(entity));
            mockContext.Setup(c => c.parent_task).Returns(mockSet.Object);

            var service = new parent_taskController(mockContext.Object);
            IHttpActionResult actionResult = service.Deleteparent_task(1);
            var blogs = actionResult as OkNegotiatedContentResult<parent_task>;

            mockContext.Verify(m => m.SaveChanges(), Times.Once());
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(actionResult, typeof(OkNegotiatedContentResult<parent_task>));

        }
        [Test]
        public void DeletePTTestNULL()
        {
            var data = new List<parent_task>
            {
               new parent_task { parent_id = 1, parent_task1="Task1" },
               new parent_task { parent_id = 2, parent_task1="Task2" },
               new parent_task { parent_id = 3, parent_task1="Task3" },


            }.AsQueryable();

            var mockSet = new Mock<DbSet<parent_task>>();
            mockSet.As<IQueryable<parent_task>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<parent_task>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<parent_task>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<parent_task>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            mockSet.Setup(set => set.Find(It.IsAny<int>()))
                .Returns<object[]>(ids => data.FirstOrDefault(y => y.parent_id == (int)ids[0]));
            var mockContext = new Mock<MSBI_NBREQSEntities1>();
            mockContext.Setup(c => c.parent_task).Returns(mockSet.Object);

            var service = new parent_taskController(mockContext.Object);
            IHttpActionResult actionResult = service.Deleteparent_task(11);
            var blogs = actionResult as OkNegotiatedContentResult<parent_task>;

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));

        }
    }
}