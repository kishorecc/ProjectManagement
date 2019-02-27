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

namespace ProjManAPI.Controllers.Tests
{
    [TestFixture]
    public class projectsControllerTests
    {
        [Test]
        public void projectsControllerTest()
        {
            var service = new projectsController();
            Assert.IsNotNull(service);
        }
        [Test]
        public void projectsControllerParamTest()
        {
            var service = new projectsController(new MSBI_NBREQSEntities1());
            Assert.IsNotNull(service);
        }
        [Test]
        public void GetProjectsTest()
        {
            var data = new List<project>
            {
               new project {project_id=1,project1="proj1",start_date=null, end_date=null,priority=10  },
               new project {project_id=2,project1="proj2",start_date=null, end_date=null,priority=10  },
               new project {project_id=3,project1="proj3",start_date=null, end_date=null,priority=10  }


            }.AsQueryable();

            var mockSet = new Mock<DbSet<project>>();
            mockSet.As<IQueryable<project>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<project>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<project>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<project>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());


            var mockContext = new Mock<MSBI_NBREQSEntities1>();
            mockContext.Setup(c => c.projects).Returns(mockSet.Object);

            var service = new projectsController(mockContext.Object);
            var blogs = service.Getprojects();

            Assert.AreEqual(data.Select(c => c.project_id == 1), blogs.Select(c => c.project_id == 1));
            Assert.AreEqual(data.Select(c => c.project_id == 2), blogs.Select(c => c.project_id == 2));
            Assert.AreEqual(data.Count(), blogs.Count());

        }
        [Test]
        public void GetProjectTest()
        {
            var data = new List<project>
            {
               new project {project_id=1,project1="proj1",start_date=null, end_date=null,priority=10  },
               new project {project_id=2,project1="proj2",start_date=null, end_date=null,priority=10  },
               new project {project_id=3,project1="proj3",start_date=null, end_date=null,priority=10  }


            }.AsQueryable();

            var mockSet = new Mock<DbSet<project>>();
            mockSet.As<IQueryable<project>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<project>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<project>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<project>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            mockSet.Setup(set => set.Find(It.IsAny<int>()))
                .Returns<object[]>(ids => data.FirstOrDefault(y => y.project_id == (int)ids[0]));


            var mockContext = new Mock<MSBI_NBREQSEntities1>();
            mockContext.Setup(c => c.projects).Returns(mockSet.Object);

            var service = new projectsController(mockContext.Object);
            IHttpActionResult actionResult = service.Getproject(1);
            var blogs = actionResult as OkNegotiatedContentResult<project>;



            Assert.IsNotNull(blogs);
            Assert.IsNotNull(blogs.Content);
            Assert.AreEqual("proj1", blogs.Content.project1);
        }
        [Test]
        public void GetProjectTestNULL()
        {
            var data = new List<project>
            {
               new project {project_id=1,project1="proj1",start_date=null, end_date=null,priority=10  },
               new project {project_id=2,project1="proj2",start_date=null, end_date=null,priority=10  },
               new project {project_id=3,project1="proj3",start_date=null, end_date=null,priority=10  }


            }.AsQueryable();

            var mockSet = new Mock<DbSet<project>>();
            mockSet.As<IQueryable<project>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<project>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<project>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<project>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            mockSet.Setup(set => set.Find(It.IsAny<int>()))
                .Returns<object[]>(ids => data.FirstOrDefault(y => y.project_id == (int)ids[0]));


            var mockContext = new Mock<MSBI_NBREQSEntities1>();
            mockContext.Setup(c => c.projects).Returns(mockSet.Object);

            var service = new projectsController(mockContext.Object);
            IHttpActionResult actionResult = service.Getproject(11);
            var blogs = actionResult as OkNegotiatedContentResult<project>;


            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
            NUnit.Framework.Assert.IsNull(blogs);
        }

        [Test]
        public void PutProjectTest()
        {
            var data = new List<project>
            {
               new project {project_id=1,project1="proj1",start_date=null, end_date=null,priority=10  },
               new project {project_id=2,project1="proj2",start_date=null, end_date=null,priority=10  },
               new project {project_id=3,project1="proj3",start_date=null, end_date=null,priority=10  }


            }.AsQueryable();

            var mockSet = new Mock<DbSet<project>>();
            mockSet.As<IQueryable<project>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<project>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<project>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<project>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            mockSet.Setup(set => set.Find(It.IsAny<int>()))
                .Returns<object[]>(ids => data.FirstOrDefault(y => y.project_id == (int)ids[0]));


            var mockContext = new Mock<MSBI_NBREQSEntities1>();
            mockContext.Setup(c => c.projects).Returns(mockSet.Object); ;

            var service = new projectsController(mockContext.Object);
            IHttpActionResult actionResult = service.Putproject(new project { project_id = 10, project1 = "proj1", start_date = null, end_date = null, priority = 10 });
            var blogs = actionResult as OkNegotiatedContentResult<project>;

            mockContext.Verify(m => m.SaveChanges(), Times.Once());
            NUnit.Framework.Assert.IsNull(blogs);
        }
        [Test]
        public void PostProjectTest()
        {
            var mockSet = new Mock<DbSet<project>>();

            var mockContext = new Mock<MSBI_NBREQSEntities1>();
            mockContext.Setup(m => m.projects).Returns(mockSet.Object);

            var service = new projectsController(mockContext.Object);
            IHttpActionResult actionResult = service.Postproject(new project { project_id = 10, project1 = "proj1", start_date = null, end_date = null, priority = 10 });

            mockSet.Verify(m => m.Add(It.IsAny<project>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
        [Test]
        public void DeleteProjectTest()
        {
            var data = new List<project>
            {
               new project {project_id=1,project1="proj1",start_date=null, end_date=null,priority=10  },
               new project {project_id=2,project1="proj2",start_date=null, end_date=null,priority=10  },
               new project {project_id=3,project1="proj3",start_date=null, end_date=null,priority=10  }


            };//.AsQueryable();

            var mockSet = new Mock<DbSet<project>>();
            mockSet.Setup(set => set.Remove(It.IsAny<project>())).Callback<project>((entity) => data.Remove(entity));
            mockSet.As<IQueryable<project>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            mockSet.Setup(set => set.Find(It.IsAny<int>()))
                .Returns<object[]>(ids => data.FirstOrDefault(y => y.project_id == (int)ids[0]));


            var mockContext = new Mock<MSBI_NBREQSEntities1>();
            mockContext.Setup(c => c.projects).Returns(mockSet.Object); ;

            var service = new projectsController(mockContext.Object);
            IHttpActionResult actionResult = service.Deleteproject(1);
            var blogs = actionResult as OkNegotiatedContentResult<project>;

            mockContext.Verify(m => m.SaveChanges(), Times.Once());
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(actionResult, typeof(OkNegotiatedContentResult<project>));

        }
        public void DeleteProjectTestNULL()
        {
            var data = new List<project>
            {
               new project {project_id=1,project1="proj1",start_date=null, end_date=null,priority=10  },
               new project {project_id=2,project1="proj2",start_date=null, end_date=null,priority=10  },
               new project {project_id=3,project1="proj3",start_date=null, end_date=null,priority=10  }


            };//.AsQueryable();

            var mockSet = new Mock<DbSet<project>>();
            mockSet.Setup(set => set.Remove(It.IsAny<project>())).Callback<project>((entity) => data.Remove(entity));
            mockSet.As<IQueryable<project>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            mockSet.Setup(set => set.Find(It.IsAny<int>()))
                .Returns<object[]>(ids => data.FirstOrDefault(y => y.project_id == (int)ids[0]));


            var mockContext = new Mock<MSBI_NBREQSEntities1>();
            mockContext.Setup(c => c.projects).Returns(mockSet.Object); ;

            var service = new projectsController(mockContext.Object);
            IHttpActionResult actionResult = service.Deleteproject(100);
            var blogs = actionResult as OkNegotiatedContentResult<project>;

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));

        }
    }
}