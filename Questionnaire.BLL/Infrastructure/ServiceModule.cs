using System;
using Ninject.Modules;
using Questionnaire.DAL.Interfaces;
using Questionnaire.DAL.Repositories;

namespace Questionnaire.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        string connectionString;

        public ServiceModule(string connection)
        {
            connectionString = connection;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
