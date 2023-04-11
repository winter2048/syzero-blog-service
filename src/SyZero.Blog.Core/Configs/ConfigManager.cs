using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyZero.Domain.Repository;
using SyZero.Domain.Service;

namespace SyZero.Blog.Core.Configs
{
    public class ConfigManager : DomainService
    {
        private readonly IRepository<Config> _configRepository;
        public ConfigManager(IRepository<Config> configRepository)
        {
            _configRepository = configRepository;
        }

        /// <summary>
        /// 设置值
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetValue(string name, string value)
        {
            var model = _configRepository.GetModel(p => p.Name == name);
            if (model == null)
            {
                model = new Config();
                model.Name = name;
                model.Value = value;
                return _configRepository.Add(model) != null;

            }
            else
            {
                model.Value = value;
                return _configRepository.Update(model) > 0;
            }
        }

        /// <summary>
        /// 设置值
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<bool> SetValueAsync(string name, string value)
        {
            var model = await _configRepository.GetModelAsync(p => p.Name == name);
            if (model == null)
            {
                model = new Config();
                model.Name = name;
                model.Value = value;
                return await _configRepository.AddAsync(model) != null;

            }
            else
            {
                model.Value = value;
                return await _configRepository.UpdateAsync(model) > 0;
            }
        }

        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetValue(string name)
        {
            var model = _configRepository.GetModel(p => p.Name == name);
            return model?.Value;
        }

        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<string> GetValueAsync(string name)
        {
            var model = await _configRepository.GetModelAsync(p => p.Name == name);
            return model?.Value;
        }
    }
}
