using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.Threading.BackgroundWorkers;
using Abp.Threading.Timers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginsSystemHangfire.Job
{
    public class TraceLogWorker : PeriodicBackgroundWorkerBase, ISingletonDependency
    {
        public TraceLogWorker(AbpTimer timer)
            : base(timer)
        {
            Timer.Period = 2000; // 2 s
           
        }

        [UnitOfWork]
        protected override void DoWork()
        {
            System.Threading.Thread.Sleep(5000);
            Logger.Info(
                System.Threading.Thread.CurrentThread.ManagedThreadId
                + " [ 后台线程 跟踪日志 PeriodicBackgroundWorkerBase DoWork ]");
            throw new Exception("TraceLogWorker DoWork");
            //base.Stop();
        }
        public override void Start()
        {
            Logger.Info(
                System.Threading.Thread.CurrentThread.ManagedThreadId
                + "[ 后台线程 跟踪日志 PeriodicBackgroundWorkerBase Start ]");

            base.Start();
        }
        public override void Stop()
        {
            Logger.Info(
                System.Threading.Thread.CurrentThread.ManagedThreadId
                + "[ 后台线程 跟踪日志 PeriodicBackgroundWorkerBase Stop ]");
            base.Stop();
        }
        public override void WaitToStop()
        {
            base.WaitToStop();
        }
    }
}
