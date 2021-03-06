﻿using BLL;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace UserInterface
{ /// <summary>
/// Ouartz
/// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            StartScheduler();
        }
        /// <summary>
        /// dsd
        /// </summary>
        private static void StartScheduler()
        {
            ISchedulerFactory schedFact = new StdSchedulerFactory();
            // get a scheduler, start the schedular before triggers or anything else  
            IScheduler sched = schedFact.GetScheduler();
            sched.Start();
            ////dsdsd
            IJobDetail exchangeRateJob = JobBuilder.Create<CurrencyExchangeUpdate>()
                .WithIdentity("job1", "group1")
                .Build();

            ITrigger exchangeRatetrigger = TriggerBuilder.Create()
                .WithIdentity("job1", "group1")
                .WithDailyTimeIntervalSchedule
                (s =>
                    s.WithIntervalInMinutes(int.Parse(ConfigurationManager.AppSettings["currencyUpdateMinute"]))
                )
                .Build();
            sched.ScheduleJob(exchangeRateJob, exchangeRatetrigger);
        }
        public class CurrencyExchangeUpdate : IJob
        {
            void IJob.Execute(IJobExecutionContext context)
            {
                XMLdataGet.TCMBDovizKuruAl();
            }
        }
    }
}
