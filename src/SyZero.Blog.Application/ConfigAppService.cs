using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SyZero;
using SyZero.Application.Service;
using SyZero.Web.Common;
using SyZero.Blog.IApplication;
using SyZero.Blog.Repository;
using SyZero.Cache;
using SyZero.Runtime.Security;
using SyZero.Serialization;
using SyZero.Blog.Core.Authorization.Users;
using System.Linq;

namespace SyZero.Blog.Application
{
    public class ConfigAppService : ApplicationService, IConfigAppService
    {
        private readonly IUserAppService _userAppService;

        private readonly IUserRepository _userRepository;
        private readonly ICache _cache;
        private readonly ISyEncode _syEncode;
        private readonly IToken _token;
        private readonly IJsonSerialize _jsonSerialize;

        public ConfigAppService(IUserRepository userRepository,
           ICache cache,
           ISyEncode syEncode,
           IToken token,
           IJsonSerialize jsonSerialize,
           IUserAppService userAppService)
        {
            _userRepository = userRepository;
            _cache = cache;
            _syEncode = syEncode;
            _token = token;
            _jsonSerialize = jsonSerialize;
            _userAppService = userAppService;
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="file">文件</param>
        /// <returns>
        /// result
        /// </returns>
        public async Task<string> ConfigInfo()
        {
            var list =   _userAppService.GetUserAll(22);



            return _jsonSerialize.ObjectToJSON(list);
        }

        public Task<string> ConfigInfo(int pp)
        {
            throw new NotImplementedException();
        }

        public Task<string> PostConfigInfo(int num, bool isok)
        {
            throw new NotImplementedException();
        }
    }
}



