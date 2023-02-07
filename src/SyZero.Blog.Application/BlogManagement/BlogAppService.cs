using Org.BouncyCastle.Crypto.Tls;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using SyZero.Application.Service;
using SyZero.Authorization.IApplication.Users;
using SyZero.Authorization.IApplication.Users.Dto;
using SyZero.Blog.IApplication.BlogManagement.Dto;
using SyZero.Blog.IApplication.Users;
using SyZero.Blog.Repository;
using SyZero.Cache;
using SyZero.Logger;
using SyZero.Runtime.Security;
using SyZero.Runtime.Session;
using SyZero.Serialization;
using SyZero.Web.Common;

namespace SyZero.Blog.Application.Users
{
    public class BlogAppService : ApplicationService, IBlogAppService
    {
        private readonly IBlogRepository _userRepository;
        private readonly ICache _cache;
        private readonly ISyEncode _syEncode;
        private readonly IToken _token;
        private readonly IJsonSerialize _jsonSerialize;
        private readonly ILogger _logger;
        private readonly ISySession _sySeeion;
        private readonly IAuthAppService _authAppService;

        public BlogAppService(IBlogRepository userRepository,
           ICache cache,
           ISyEncode syEncode,
           IToken token,
           IJsonSerialize jsonSerialize,
           ILogger logger,
           ISySession sySeeion,
           IAuthAppService authAppService)
        {
            _userRepository = userRepository;
            _cache = cache;
            _syEncode = syEncode;
            _token = token;
            _jsonSerialize = jsonSerialize;
            _logger = logger;
            _sySeeion = sySeeion;
            _authAppService = authAppService;
        }

        //public async Task<object> GetInfo(string p)
        //{
        //    bool opo = await _authAppService.GetVerificationCode(p);

        //    return opo;
        //}
       

        public async Task<string> Login(Login2Dto input)
        {
            //var dto = ObjectMapper.Map<LoginDto>(input);

            var opo = await _authAppService.GetUserInfo();

            return _jsonSerialize.ObjectToJSON(opo);
        }
    }  
}



