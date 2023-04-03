using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyZero.Domain.Entities;

namespace SyZero.Blog.Core.Configs
{
    public class Config : Entity
    {
        //
        // 摘要:
        //     键
        public string Name { get; set; }

        //
        // 摘要:
        //     值
        public string Value { get; set; }
    }
}
