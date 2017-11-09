using Abp.Application.Services;
using Abp.Threading.BackgroundWorkers;
using PluginsSystemHangfire.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginsSystemHangfire.BackgroundWorker
{
    /// <summary>
    /// 后台工作者，后台线程
    /// </summary>
    public interface ITraceLogWorkerAppService : IApplicationService
    {
        /// <summary>
        /// 执行
        /// </summary>
        void Execute();
        /// <summary>
        /// 停止
        /// </summary>
        void Stop();
        /// <summary>
        /// 开始
        /// </summary>
        void Start();
    }
    /// <summary>
    /// 
    /// </summary>
    public class TraceLogWorkerAppService : PluginsSystemHangfireAppServiceBase, ITraceLogWorkerAppService {
        
        private readonly TraceLogWorker traceLogWorker;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="traceLogWorker"></param>
        public TraceLogWorkerAppService(
            TraceLogWorker traceLogWorker)
        {
            this.traceLogWorker = traceLogWorker;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            this.Logger.Info("【TraceLogWorkerAppService】 【Start】 ");
            this.traceLogWorker.Start();
        }

        public void Stop()
        {
            this.Logger.Info("【TraceLogWorkerAppService】 【Stop】 ");
            this.traceLogWorker.Stop();
        }
    }
}
