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

namespace ProjManAPI.Controllers.Tests
{
    [TestFixture]
    public class tasksControllerTests
    {
        [Test]
        public void tasksControllerTest()
        {
            var service = new tasksController();
            Assert.IsNotNull(service);
        }
        [Test]
        public void tasksControllerPAramTests()
        {
            var service = new tasksController(new MSBI_NBREQSEntities1());
            Assert.IsNotNull(service);
        }

        [Test]
        public void GettasksTest()
        {
            var data = new List<task>
            {
               new task { task_id = 1, parent_id=1,project_id=1,start_date=null,end_date=null,priority=10,status=true,Tasks="Task1" },
               new task { task_id = 2, parent_id=1,project_id=1,start_date=null,end_date=null,priority=10,status=true,Tasks="Tas21" },
               new task { task_id = 3, parent_id=1,project_id=1,start_date=null,end_date=null,priority=10,status=true,Tasks="Task3" }

    }.AsQueryable();

            var mockSet = new Mock<DbSet<task>>();
            mockSet.As<IQueryable<task>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<task>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<task>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<task>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());


            var mockContext = new Mock<MSBI_NBREQSEntities1>();
            mockContext.Setup(c => c.tasks).Returns(mockSet.Object);

            var service = new tasksController(mockContext.Object);
            var blogs = service.Gettasks();

            Assert.AreEqual(data.Select(c => c.task_id == 1), blogs.Select(c => c.task_id == 1));
            Assert.AreEqual(data.Select(c => c.task_id == 2), blogs.Select(c => c.task_id == 2));
            Assert.AreEqual(data.Count(), blogs.Count());

        }
        [Test]
        public void GetTaskTest()
        {
            var data = new List<task>
            {
               new task { task_id = 1, parent_id=1,project_id=1,start_date=null,end_date=null,priority=10,status=true,Tasks="Task1" },
               new task { task_id = 2, parent_id=1,project_id=1,start_date=null,end_date=null,priority=10,status=true,Tasks="Tas21" },
               new task { task_id = 3, parent_id=1,project_id=1,start_date=null,end_date=null,priority=10,status=true,Tasks="Task3" }

    }.AsQueryable();

            var mockSet = new Mock<DbSet<task>>();
            mockSet.As<IQueryable<task>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<task>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<task>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<task>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            mockSet.Setup(set => set.Find(It.IsAny<int>()))
                .Returns<object[]>(ids => data.FirstOrDefault(y => y.task_id == (int)ids[0]));


            var mockContext = new Mock<MSBI_NBREQSEntities1>();
            mockContext.Setup(c => c.tasks).Returns(mockSet.Object);

            var service = new tasksController(mockContext.Object);
            IHttpActionResult actionResult = service.Gettask(2);
            var blogs = actionResult as OkNegotiatedContentResult<task>;



            Assert.IsNotNull(blogs);
            Assert.IsNotNull(blogs.Content);
            Assert.AreEqual("Tas21", blogs.Content.Tasks);
        }
        [Test]
        public void GetTaskTestNULL()
        {
            var data = new List<task>
            {
               new task { task_id = 1, parent_id=1,project_id=1,start_date=null,end_date=null,priority=10,status=true,Tasks="Task1" },
               new task { task_id = 2, parent_id=1,project_id=1,start_date=null,end_date=null,priority=10,status=true,Tasks="Tas21" },
               new task { task_id = 3, parent_id=1,project_id=1,start_date=null,end_date=null,priority=10,status=true,Tasks="Task3" }

    }.AsQueryable();

            var mockSet = new Mock<DbSet<task>>();
            mockSet.As<IQueryable<task>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<task>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<task>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<task>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            mockSet.Setup(set => set.Find(It.IsAny<int>()))
                .Returns<object[]>(ids => data.FirstOrDefault(y => y.task_id == (int)ids[0]));


            var mockContext = new Mock<MSBI_NBREQSEntities1>();
            mockContext.Setup(c => c.tasks).Returns(mockSet.Object);

            var service = new tasksController(mockContext.Object);
            IHttpActionResult actionResult = service.Gettask(5);
            var blogs = actionResult as OkNegotiatedContentResult<task>;

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
            NUnit.Framework.Assert.IsNull(blogs);
        }
        [Test]
        public void PutTaskTest()
        {
            var data = new List<task>
            {
               new task { task_id = 1, parent_id=1,project_id=1,start_date=null,end_date=null,priority=10,status=true,Tasks="Task1" },
               new task { task_id = 2, parent_id=1,project_id=1,start_date=null,end_date=null,priority=10,status=true,Tasks="Tas21" },
               new task { task_id = 3, parent_id=1,project_id=1,start_date=null,end_date=null,priority=10,status=true,Tasks="Task3" }

    }.AsQueryable();

            var mockSet = new Mock<DbSet<task>>();
            mockSet.As<IQueryable<task>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<task>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<task>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<task>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            mockSet.Setup(set => set.Find(It.IsAny<int>()))
                .Returns<object[]>(ids => data.FirstOrDefault(y => y.task_id == (int)ids[0]));


            var mockContext = new Mock<MSBI_NBREQSEntities1>();
            mockContext.Setup(c => c.tasks).Returns(mockSet.Object);

            var service = new tasksController(mockContext.Object);
            IHttpActionResult actionResult = service.Puttask(new task { task_id = 4, parent_id = 1, project_id = 1, start_date = null, end_date = null, priority = 10, status = true, Tasks = "Task3" });
            var blogs = actionResult as OkNegotiatedContentResult<task>;

            mockContext.Verify(m => m.SaveChanges(), Times.Once());
            NUnit.Framework.Assert.IsNull(blogs);
        }
        [Test]
        public void PostTaskTest()
        {
            var mockSet = new Mock<DbSet<task>>();

            var mockContext = new Mock<MSBI_NBREQSEntities1>();
            mockContext.Setup(m => m.tasks).Returns(mockSet.Object);

            var service = new tasksController(mockContext.Object);
            IHttpActionResult actionResult = service.Posttask(new task { task_id = 4, parent_id = 1, project_id = 1, start_date = null, end_date = null, priority = 10, status = true, Tasks = "Task3" });

            mockSet.Verify(m => m.Add(It.IsAny<task>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }


        [Test]
        public void DeleteTaskTestNUL()
        {
            var data = new List<task>
            {
               new task { task_id = 1, parent_id=1,project_id=1,start_date=null,end_date=null,priority=10,status=true,Tasks="Task1" },
               new task { task_id = 2, parent_id=1,project_id=1,start_date=null,end_date=null,priority=10,status=true,Tasks="Tas21" },
               new task { task_id = 3, parent_id=1,project_id=1,start_date=null,end_date=null,priority=10,status=true,Tasks="Task3" }
    };

            var mockSet = new Mock<DbSet<task>>();

            var mockContext = new Mock<MSBI_NBREQSEntities1>();

            mockSet.Setup(set => set.Remove(It.IsAny<task>())).Callback<task>((entity) => data.Remove(entity));
            mockSet.As<IQueryable<task>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mockSet.Setup(set => set.Find(It.IsAny<int>())).Returns<object[]>(ids => data.FirstOrDefault(y => y.task_id == (int)ids[0]));

            mockContext.Setup(c => c.tasks).Returns(mockSet.Object);

            var service = new tasksController(mockContext.Object);
            IHttpActionResult actionResult = service.Deletetask(1);
            var blogs = actionResult as OkNegotiatedContentResult<task>;

            mockContext.Verify(m => m.SaveChanges(), Times.Once());
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(actionResult, typeof(OkNegotiatedContentResult<task>));

        }
        [Test]
        public void DeleteTaskTest()
        {
            var data = new List<task>
            {
               new task { task_id = 1, parent_id=1,project_id=1,start_date=null,end_date=null,priority=10,status=true,Tasks="Task1" },
               new task { task_id = 2, parent_id=1,project_id=1,start_date=null,end_date=null,priority=10,status=true,Tasks="Tas21" },
               new task { task_id = 3, parent_id=1,project_id=1,start_date=null,end_date=null,priority=10,status=true,Tasks="Task3" }
    };

            var mockSet = new Mock<DbSet<task>>();

            var mockContext = new Mock<MSBI_NBREQSEntities1>();

            mockSet.Setup(set => set.Remove(It.IsAny<task>())).Callback<task>((entity) => data.Remove(entity));
            mockSet.As<IQueryable<task>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mockSet.Setup(set => set.Find(It.IsAny<int>())).Returns<object[]>(ids => data.FirstOrDefault(y => y.task_id == (int)ids[0]));

            mockContext.Setup(c => c.tasks).Returns(mockSet.Object);

            var service = new tasksController(mockContext.Object);
            IHttpActionResult actionResult = service.Deletetask(11);
            var blogs = actionResult as OkNegotiatedContentResult<task>;

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));

        }
    }
}