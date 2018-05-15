using API_Services.Configuration;
using Business_Layer.Managers;
using Common.Unity;
using Contracts.Business;
using Services_WebApi2.App_Start.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace API_Services.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = BuildUnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            IoCContainerHolder.UnityContainer = new UnityIoCContainer(container);
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            //Configurations
            container.BindInRequestScope<IWebAppConfiguration, WebAppConfiguration>();


            //Managers
            container.BindInRequestScope<IEmployeeManager, EmployeeManager>();

            //Repositories
            //container.BindInRequestScope<IMasterDataRepository, MasterDataRepository>();
           
            return container;
        }
    }
}