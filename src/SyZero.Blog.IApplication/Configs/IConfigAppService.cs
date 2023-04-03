using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        [ApiMethod(HttpMethod.GET)]
        Task<BasicsSettingDto> BasicsSetting();

        /// <summary>
        /// 更新基础设置
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [ApiMethod(HttpMethod.POST)]
        Task<bool> BasicsSetting(BasicsSettingDto dto);

        /// <summary>
        /// 获取SEO设置
        /// </summary>
        /// <returns></returns>
        [ApiMethod(HttpMethod.GET)]
        Task<SeoSettingDto> SeoSetting();

        /// <summary>
        /// 更新SEO设置
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [ApiMethod(HttpMethod.POST)]
        Task<bool> SeoSetting(SeoSettingDto dto);

        /// <summary>
        /// 获取其他设置
        /// </summary>
        /// <returns></returns>
        [ApiMethod(HttpMethod.GET)]
        Task<OtherSettingDto> OtherSetting();

        /// <summary>
        /// 更新其他设置
        /// </summary>
        /// <returns></returns>
        [ApiMethod(HttpMethod.POST)]
        Task<bool> OtherSetting(OtherSettingDto dto);

        /// <summary>
        /// 获取阿里短信设置信息
        /// </summary>
        /// <returns></returns>
        [ApiMethod(HttpMethod.GET)]
        Task<SmsConfigDto> AliyunSmsConfig();

        /// <summary>
        /// 设置阿里短信设置信息
        /// </summary>
        /// <returns></returns>
        [ApiMethod(HttpMethod.POST)]
        Task<bool> AliyunSmsConfig(SmsConfigDto dto);
    }
}
