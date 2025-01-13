using System.Threading.Tasks;
using SyZero.Application.Routing;
using SyZero.Blog.IApplication.Configs.Dto;

namespace SyZero.Blog.IApplication.Configs
{
    public interface IConfigAppService : IApplicationServiceBase
    {
        /// <summary>
        /// 获取基础设置
        /// </summary>
        /// <returns></returns>
        [Get("BasicsSetting")]
        Task<BasicsSettingDto> BasicsSetting();

        /// <summary>
        /// 更新基础设置
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Post("BasicsSetting")]
        Task<bool> BasicsSetting(BasicsSettingDto dto);

        /// <summary>
        /// 获取SEO设置
        /// </summary>
        /// <returns></returns>
        [Get("SeoSetting")]
        Task<SeoSettingDto> SeoSetting();

        /// <summary>
        /// 更新SEO设置
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Post("SeoSetting")]
        Task<bool> SeoSetting(SeoSettingDto dto);

        /// <summary>
        /// 获取其他设置
        /// </summary>
        /// <returns></returns>
        [Get("OtherSetting")]
        Task<OtherSettingDto> OtherSetting();

        /// <summary>
        /// 更新其他设置
        /// </summary>
        /// <returns></returns>
        [Post("OtherSetting")]
        Task<bool> OtherSetting(OtherSettingDto dto);

        /// <summary>
        /// 获取阿里短信设置信息
        /// </summary>
        /// <returns></returns>
        [Get("AliyunSmsConfig")]
        Task<SmsConfigDto> AliyunSmsConfig();

        /// <summary>
        /// 设置阿里短信设置信息
        /// </summary>
        /// <returns></returns>
        [Post("AliyunSmsConfig")]
        Task<bool> AliyunSmsConfig(SmsConfigDto dto);


        [Get("WebConfig")]
        Task<object> WebConfig();

        /// <summary>
        /// 获取喜欢数
        /// </summary>
        /// <returns></returns>
        [Get("ShowLikeNum")]
        int GetLikeNum();

        /// <summary>
        /// 喜欢
        /// </summary>
        /// <returns></returns>
        [Post("LikeNum")]
        bool LikeNum();
    }
}
