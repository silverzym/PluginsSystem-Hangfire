using Abp.Dependency;
using Abp.Runtime.Caching;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginsSystemHangfire
{
    /// <summary>
    /// 缓存管理
    /// </summary>
    public sealed class ServiceCacheManager
    {
        #region 实例化

        /// <summary>
        /// 实例化对象
        /// </summary>
        private static readonly ServiceCacheManager _instance = new ServiceCacheManager(IocManager.Instance.Resolve<ICacheManager>());

        /// <summary>
        /// 静态属性
        /// </summary>
        public static ServiceCacheManager Instance
        {
            get
            {
                return ServiceCacheManager._instance;
            }
        }
        public ServiceCacheManager(ICacheManager cacheManager)
        {
            this._cacheManager = cacheManager;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// ABP中有两种cache的实现方式：MemroyCache 和 RedisCache，两者都继承至ICache接口（准确说是CacheBase抽象类）。
        ///     ABP核心模块封装了MemroyCache 来实现ABP中的默认缓存功能。 
        ///     Abp.RedisCache这个模块封装RedisCache来实现缓存（通过StackExchange.Redis这个类库访问redis）。
        /// ICacheManager.GetCache方法返回一个ICache。缓存对象是单例的，第一次请求时会创建缓存，以后都是返回相同的缓存对象。
        ///     因此，我们可以在不同的类（客户端）中共享具有相同名字的相同缓存。
        /// </summary>
        private readonly ICacheManager _cacheManager;

        /// <summary>
        /// 获取缓存实例，如若不存在，则创建
        /// </summary>
        /// <param name="cacheInstanceName">缓存实例名称</param>
        private ICache GetCacheInstance(string cacheInstanceName)
        {
            if (string.IsNullOrWhiteSpace(cacheInstanceName))
            {
                cacheInstanceName = defaultCacheInstanceName;
            }

            return this._cacheManager.GetCache(cacheInstanceName);
        }

        /// <summary>
        /// 默认缓存实例名称
        /// </summary>
        private readonly string defaultCacheInstanceName = "Cache-Default";
        #endregion

        #region Set Value

        #region Async
        /// <summary>
        /// 插入缓存 (默认的缓存实例名称)
        /// </summary>
        /// <param name="cacheItemKey">插入缓存项-Key</param>
        /// <param name="cacheItemKeyValue">插入缓存项-Value</param>
        public async Task SetAsync(string cacheItemKey, object cacheItemKeyValue)
        {
            await this.SetAsync(null, cacheItemKey, cacheItemKeyValue, null, null);
        }

        /// <summary>
        /// 插入缓存 (默认的缓存实例名称)
        /// </summary>
        /// <param name="cacheItemKey">插入缓存项-Key</param>
        /// <param name="cacheItemKeyValue">插入缓存项-Value</param>
        /// <param name="absoluteExpireTime">绝对过期时间</param>
        /// <param name="slidingExpireTime">滑动过期时间</param>
        public async Task SetAsync(string cacheItemKey, object cacheItemKeyValue, TimeSpan? absoluteExpireTime, TimeSpan? slidingExpireTime)
        {
            await this.SetAsync(null, cacheItemKey, cacheItemKeyValue, absoluteExpireTime, slidingExpireTime);
        }

        /// <summary>
        /// 插入缓存
        /// </summary>
        /// <param name="cacheInstanceName">缓存实例名称</param>
        /// <param name="cacheItemKey">插入缓存项-Key</param>
        /// <param name="cacheItemKeyValue">插入缓存项-Value</param>
        public async Task SetAsync(string cacheInstanceName, string cacheItemKey, object cacheItemKeyValue)
        {
            await this.SetAsync(cacheInstanceName, cacheItemKey, cacheItemKeyValue, null, null);
        }

        /// <summary>
        /// 插入缓存
        /// </summary>
        /// <param name="cacheInstanceName">缓存实例名称</param>
        /// <param name="cacheItemKey">插入缓存项-Key</param>
        /// <param name="cacheItemKeyValue">插入缓存项-Value</param>
        /// <param name="absoluteExpireTime">绝对过期时间</param>
        /// <param name="slidingExpireTime">滑动过期时间</param>
        public async Task SetAsync(string cacheInstanceName, string cacheItemKey, object cacheItemKeyValue, TimeSpan? absoluteExpireTime, TimeSpan? slidingExpireTime)
        {
            ICache cache = GetCacheInstance(cacheInstanceName);

            // 绝对过期时间
            if (absoluteExpireTime.HasValue)
            {
                await cache.SetAsync(cacheItemKey, cacheItemKeyValue, absoluteExpireTime.Value, null);
                return;
            }
            // 滑动过期时间
            if (slidingExpireTime.HasValue)
            {
                await cache.SetAsync(cacheItemKey, cacheItemKeyValue, null, slidingExpireTime.Value);
                return;
            }

            await cache.SetAsync(cacheItemKey, cacheItemKeyValue);
        }

        #endregion

        /// <summary>
        /// 插入缓存 (默认的缓存实例名称)
        /// </summary>
        /// <param name="cacheItemKey">插入缓存项-Key</param>
        /// <param name="cacheItemKeyValue">插入缓存项-Value</param>
        public void Set(string cacheItemKey, object cacheItemKeyValue)
        {
            this.Set(null, cacheItemKey, cacheItemKeyValue, null, null);
        }

        /// <summary>
        /// 插入缓存 (默认的缓存实例名称)
        /// </summary>
        /// <param name="cacheItemKey">插入缓存项-Key</param>
        /// <param name="cacheItemKeyValue">插入缓存项-Value</param>
        /// <param name="absoluteExpireTime">绝对过期时间</param>
        /// <param name="slidingExpireTime">滑动过期时间</param>
        public void Set(string cacheItemKey, object cacheItemKeyValue, TimeSpan? absoluteExpireTime, TimeSpan? slidingExpireTime)
        {
            this.Set(null, cacheItemKey, cacheItemKeyValue, absoluteExpireTime, slidingExpireTime);
        }

        /// <summary>
        /// 插入缓存
        /// </summary>
        /// <param name="cacheInstanceName">缓存实例名称</param>
        /// <param name="cacheItemKey">插入缓存项-Key</param>
        /// <param name="cacheItemKeyValue">插入缓存项-Value</param>
        public void Set(string cacheInstanceName, string cacheItemKey, object cacheItemKeyValue)
        {
            this.Set(cacheInstanceName, cacheItemKey, cacheItemKeyValue, null, null);
        }

        /// <summary>
        /// 插入缓存
        /// </summary>
        /// <param name="cacheInstanceName">缓存实例名称</param>
        /// <param name="cacheItemKey">插入缓存项-Key</param>
        /// <param name="cacheItemKeyValue">插入缓存项-Value</param>
        /// <param name="absoluteExpireTime">绝对过期时间</param>
        /// <param name="slidingExpireTime">滑动过期时间</param>
        public void Set(string cacheInstanceName, string cacheItemKey, object cacheItemKeyValue, TimeSpan? absoluteExpireTime, TimeSpan? slidingExpireTime)
        {
            ICache cache = GetCacheInstance(cacheInstanceName);

            // 绝对过期时间
            if (absoluteExpireTime.HasValue)
            {
                cache.Set(cacheItemKey, cacheItemKeyValue, absoluteExpireTime.Value, null);
                return;
            }
            // 滑动过期时间
            if (slidingExpireTime.HasValue)
            {
                cache.Set(cacheItemKey, cacheItemKeyValue, null, slidingExpireTime.Value);
                return;
            }

            cache.Set(cacheItemKey, cacheItemKeyValue);
        }

        #endregion

        #region Get Value

        #region Async

        public async Task<Object> GetAsync(string cacheInstanceName, string cacheItemKey)
        {
            ICache cache = GetCacheInstance(cacheInstanceName);

            return await cache.GetAsync(cacheItemKey, null);
        }

        #endregion

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="cacheItemKey">获取的缓存项-Key</param>
        public Object Get(string cacheItemKey)
        {
            return this.Get(null, cacheItemKey);
        }
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="cacheInstanceName">缓存实例名称</param>
        /// <param name="cacheItemKey">获取的缓存项-Key</param>
        public Object Get(string cacheInstanceName, string cacheItemKey)
        {
            ICache cache = GetCacheInstance(cacheInstanceName);

            return cache.Get(cacheItemKey, null);
        }

        #endregion

        #region Remove Cache

        #region Async
        /// <summary>
        /// 删除缓存·异步
        /// </summary>
        /// <param name="cacheItemKey">缓存项-Key</param>
        public async Task RemoveAsync(string cacheItemKey)
        {
            await this.RemoveAsync(null, cacheItemKey);
        }

        /// <summary>
        /// 删除缓存·异步
        /// </summary>
        /// <param name="cacheInstanceName">缓存实例名称</param>
        /// <param name="cacheItemKey">缓存项-Key</param>
        public async Task RemoveAsync(string cacheInstanceName, string cacheItemKey)
        {
            ICache cache = GetCacheInstance(cacheInstanceName);
            await cache.RemoveAsync(cacheItemKey);
        }

        /// <summary>
        /// 删除缓存·当前实例下的所有缓存·异步
        /// </summary>
        /// <param name="cacheInstanceName">缓存实例名称</param>
        public async Task RemoveAllAsync(string cacheInstanceName)
        {
            await GetCacheInstance(cacheInstanceName).ClearAsync();
        }
        #endregion

        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="cacheItemKey">缓存项-Key</param>
        public void Remove(string cacheItemKey)
        {
            this.Remove(null, cacheItemKey);
        }
        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="cacheInstanceName">缓存实例名称</param>
        /// <param name="cacheItemKey">缓存项-Key</param>
        public void Remove(string cacheInstanceName, string cacheItemKey)
        {
            ICache cache = GetCacheInstance(cacheInstanceName);
            cache.Remove(cacheItemKey);
        }

        /// <summary>
        /// 删除缓存 当前实例下的所有缓存
        /// </summary>
        /// <param name="cacheInstanceName">缓存实例名称</param>
        public void RemoveAll(string cacheInstanceName)
        {
            GetCacheInstance(cacheInstanceName).Clear();
        }

        #endregion
    }
}
