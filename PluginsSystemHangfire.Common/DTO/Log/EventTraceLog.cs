using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginsSystemHangfire.Common.DTO.Log
{
    /// <summary>
    /// 事件跟踪日志
    /// </summary>
    [Serializable]
    public  class EventTraceLog
    {
        public int Id { get; set; }
        /// <summary>
        /// 事件类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 事件类型
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 事件发生所在服务
        /// </summary>
        public string ServiceName { get; set; }
        /// <summary>
        /// 事件发生所在业务域
        /// </summary>
        public string App { get; set; }
        /// <summary>
        /// 事件级别
        /// </summary>
        public string Level { get; set; }
        /// <summary>
        /// 事件发生时间
        /// </summary>
        public int Timestamp { get; set; }
        /// <summary>
        /// 事件标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 事件详细描述
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 事件发生所在主机
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// 事件发生所在应用实例名
        /// </summary>
        public string Instance { get; set; }
        /// <summary>
        /// 事件发生所在应用模块
        /// </summary>
        public string Module { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        public string Tags { get; set; }
        /// <summary>
        /// 采样率，由顶层服务设定，透传到下游服务
        /// </summary>
        public int TTL { get; set; }
        /// <summary>
        /// 自定义字段列表，K/V键值对，K 的名字可随意
        /// </summary>
        public string CustomFields { get; set; }
    }
}
