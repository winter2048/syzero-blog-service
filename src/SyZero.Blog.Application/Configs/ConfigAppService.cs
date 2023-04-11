using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyZero.Application.Service;
using SyZero.Authorization.IApplication.Users.Dto;
using SyZero.Blog.Core.Configs;
using SyZero.Blog.IApplication.Configs.Dto;
using SyZero.Blog.IApplication.Configs;
using SyZero.Domain.Repository;
using SyZero.Runtime.Session;
using Dynamitey.DynamicObjects;
using SyZero.Authorization.IApplication.Users;

namespace SyZero.Blog.Application.Configs
{
    public class ConfigAppService : ApplicationService, IConfigAppService
    {
        private readonly ConfigManager _configManager;
        private readonly IUserAppService _userAppService;

        private readonly IRepository<Config> _configRepository;
        public ConfigAppService(ConfigManager configAppService, IRepository<Config> configRepository, IUserAppService userAppService)
        {
            _configManager = configAppService;
            _configRepository = configRepository;
            _userAppService = userAppService;
        }
        /// <summary>
        /// 获取基础设置
        /// </summary>
        /// <returns></returns>
        public async Task<BasicsSettingDto> BasicsSetting()
        {
            BasicsSettingDto dto = new BasicsSettingDto();
            dto.BlogIcon = await _configManager.GetValueAsync(AppConts.站点图标) ?? "";
            dto.BlogName = await _configManager.GetValueAsync(AppConts.站点标题) ?? "";
            dto.BlogUrl = await _configManager.GetValueAsync(AppConts.站点地址) ?? "";
            dto.BlogInfo = await _configManager.GetValueAsync(AppConts.站点副标题) ?? "";
            dto.FooterInfo = await _configManager.GetValueAsync(AppConts.版权说明) ?? "";
            dto.IndexLogNum = (await _configManager.GetValueAsync(AppConts.每页文章数量) ?? "0").ToInt32();
            dto.IsClose = await _configManager.GetValueAsync(AppConts.关闭网站) == "true";
            dto.AttType = await _configManager.GetValueAsync(AppConts.上传文件类型) ?? "";
            dto.AttMaxSize = (await _configManager.GetValueAsync(AppConts.上传文件大小) ?? "0").ToInt32();
            return dto;
        }



        public async Task<bool> BasicsSetting(BasicsSettingDto dto)
        {
            await UnitOfWork.BeginTransactionAsync();
            await _configManager.SetValueAsync(AppConts.站点图标, dto.BlogIcon);
            await _configManager.SetValueAsync(AppConts.站点标题, dto.BlogName);
            await _configManager.SetValueAsync(AppConts.站点地址, dto.BlogUrl);
            await _configManager.SetValueAsync(AppConts.站点副标题, dto.BlogInfo);
            await _configManager.SetValueAsync(AppConts.版权说明, dto.FooterInfo);
            await _configManager.SetValueAsync(AppConts.每页文章数量, dto.IndexLogNum.ToString());
            await _configManager.SetValueAsync(AppConts.关闭网站, dto.IsClose.ToString());
            await _configManager.SetValueAsync(AppConts.上传文件类型, dto.AttType);
            await _configManager.SetValueAsync(AppConts.上传文件大小, dto.AttMaxSize.ToString());
            await UnitOfWork.CommitTransactionAsync();
            return true;
        }


        public async Task<SeoSettingDto> SeoSetting()
        {
            SeoSettingDto dto = new SeoSettingDto();
            dto.SeoDescription = await _configManager.GetValueAsync(AppConts.SEO描述) ?? "";
            dto.SeoKeywords = await _configManager.GetValueAsync(AppConts.SEO关键字) ?? "";
            dto.SeoTitle = await _configManager.GetValueAsync(AppConts.SEO标题) ?? "";
            dto.SeoTitleStyle = Enum.Parse<TitleStyle>(await _configManager.GetValueAsync(AppConts.文章标题方案) ?? "0");
            return dto;
        }

        public async Task<bool> SeoSetting(SeoSettingDto dto)
        {
            await UnitOfWork.BeginTransactionAsync();
            await _configManager.SetValueAsync(AppConts.SEO描述, dto.SeoDescription);
            await _configManager.SetValueAsync(AppConts.SEO关键字, dto.SeoKeywords);
            await _configManager.SetValueAsync(AppConts.SEO标题, dto.SeoTitle);
            await _configManager.SetValueAsync(AppConts.文章标题方案, ((int)dto.SeoTitleStyle).ToString());
            await UnitOfWork.CommitTransactionAsync();
            return true;
        }

        public async Task<OtherSettingDto> OtherSetting()
        {
            OtherSettingDto dto = new OtherSettingDto();
            dto.OtherBanner = await _configManager.GetValueAsync(AppConts.首页Banner) ?? "";
            dto.OtherRightImg = await _configManager.GetValueAsync(AppConts.右侧Banner) ?? "";
            dto.OtherLoginImg = await _configManager.GetValueAsync(AppConts.登录Banner) ?? "";
            dto.OtherCsdn = await _configManager.GetValueAsync(AppConts.CSDN) ?? "";
            dto.OtherGithub = await _configManager.GetValueAsync(AppConts.Github账号) ?? "";
            dto.OtherJianli = await _configManager.GetValueAsync(AppConts.简历) ?? "";
            dto.OtherMore = await _configManager.GetValueAsync(AppConts.更多) ?? "";
            dto.OtherQQ = await _configManager.GetValueAsync(AppConts.QQ) ?? "";
            dto.OtherWeibo = await _configManager.GetValueAsync(AppConts.微博) ?? "";
            dto.OtherWx = await _configManager.GetValueAsync(AppConts.微信) ?? "";
            return dto;
        }

        public async Task<bool> OtherSetting(OtherSettingDto dto)
        {
            await UnitOfWork.BeginTransactionAsync();
           await  _configManager.SetValueAsync(AppConts.首页Banner, dto.OtherBanner);
            await _configManager.SetValueAsync(AppConts.右侧Banner, dto.OtherRightImg);
            await _configManager.SetValueAsync(AppConts.登录Banner, dto.OtherLoginImg);
            await _configManager.SetValueAsync(AppConts.CSDN, dto.OtherCsdn);
            await _configManager.SetValueAsync(AppConts.Github账号, dto.OtherGithub);
            await _configManager.SetValueAsync(AppConts.简历, dto.OtherJianli);
            await _configManager.SetValueAsync(AppConts.更多, dto.OtherMore);
            await _configManager.SetValueAsync(AppConts.QQ, dto.OtherQQ);
            await _configManager.SetValueAsync(AppConts.微博, dto.OtherWeibo);
            await _configManager.SetValueAsync(AppConts.微信, dto.OtherWx);
            await UnitOfWork.CommitTransactionAsync();
            return true;
        }

        public async Task<SmsConfigDto> AliyunSmsConfig()
        {
            SmsConfigDto dto = new SmsConfigDto();
            dto.AccessKeyID = await _configManager.GetValueAsync(AppConts.阿里密匙ID) ?? "";
            dto.AccessKeySecret = await _configManager.GetValueAsync(AppConts.阿里密钥) ?? "";
            dto.SignName = await _configManager.GetValueAsync(AppConts.阿里签名) ?? "";
            dto.SignInCode = await _configManager.GetValueAsync(AppConts.阿里登录模板) ?? "";
            dto.RetrieveCode = await _configManager.GetValueAsync(AppConts.阿里找回密码模板) ?? "";
            dto.RegisterCode = await _configManager.GetValueAsync(AppConts.阿里注册模板) ?? "";

            return dto;
        }

        public async Task<bool> AliyunSmsConfig(SmsConfigDto dto)
        {
            await UnitOfWork.BeginTransactionAsync();
            await _configManager.SetValueAsync(AppConts.阿里密匙ID, dto.AccessKeyID);
            await _configManager.SetValueAsync(AppConts.阿里密钥, dto.AccessKeySecret);
            await _configManager.SetValueAsync(AppConts.阿里签名, dto.SignName);
            await _configManager.SetValueAsync(AppConts.阿里登录模板, dto.SignInCode);
            await _configManager.SetValueAsync(AppConts.阿里找回密码模板, dto.RetrieveCode);
            await _configManager.SetValueAsync(AppConts.阿里注册模板, dto.RegisterCode);
            await UnitOfWork.CommitTransactionAsync();
            return true;
        }

        public async Task<object> WebConfig()
        {
            var otherDto = OtherSetting();
            var basicsDto = BasicsSetting();
            var seoDto = SeoSetting();
            var defaultUserDto = await _userAppService.GetUser(1622625989756588032);
            //var defaultUser = _userRepository.GetModel(p => p.Type == 2);
           // var defaultUserDto = ObjectMapper.Map<UserDto>(defaultUser);
            var userDto = defaultUserDto;
            if (SySession.UserId != null)
            {
                userDto = await _userAppService.GetUser(SySession.UserId.Value);
            }
            return new { basics = basicsDto, other = otherDto, baseSeo = seoDto, user = userDto, defaultUser = defaultUserDto };
        }

        public int GetLikeNum()
        {
            int num = _configManager.GetValue(AppConts.喜欢数).ToInt32();
            return num;
        }

        public bool LikeNum()
        {
            int num = _configManager.GetValue(AppConts.喜欢数).ToInt32();
            _configManager.SetValue(AppConts.喜欢数, (++num).ToString());
            return true;
        }
    }
}
