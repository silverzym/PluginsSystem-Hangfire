namespace PluginsSystemHangfire.Common.DTO.Account
{
    /// <summary>
    /// 输入参数
    /// </summary>
    public class LogoutInput
    {
        /// <summary>
        /// 访问令牌
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// 登录用户ID
        /// </summary>
        public string Id { get; set; }
    }
}
