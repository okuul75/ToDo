using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Moq;
using ToDo.Domain.Abstract;
using ToDo.Domain.Entities;
using ToDo.Domain.Concrete;

namespace ToDo.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            Mock<IToDoTaskRepository> mock = new Mock<IToDoTaskRepository>();
            mock.Setup(m => m.ToDoTasks).Returns(new List<ToDoTask> {
            new ToDoTask{Description = "zadanie 1", CreatingDate = System.DateTime.Now, RealizationDate = System.DateTime.Now, RealizationState = false},
            new ToDoTask{Description = "zadanie 2", CreatingDate = System.DateTime.Now, RealizationDate = System.DateTime.Now, RealizationState = false},
            new ToDoTask{Description = "zadanie 3", CreatingDate = System.DateTime.Now, RealizationDate = System.DateTime.Now, RealizationState = false}

            });

            //kernel.Bind<IToDoTaskRepository>().ToConstant(mock.Object);
            kernel.Bind<IToDoTaskRepository>().To<EFToDoTaskRepository>();
        }
    }
}
