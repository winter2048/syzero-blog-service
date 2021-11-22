### SYZERO-Blog 一个简洁美观、功能强大并且自适应的 C#博客。使用 Asp.Net Core3.1 开发，前端使用 Vue/Nuxt.js。支持移动端自适应，配有完备的前台和后台管理功能

[![Author](https://img.shields.io/badge/author-landy-green.svg?style=flat-square)](http://mtons.com)
[![JDK](https://img.shields.io/badge/jdk-1.8-green.svg?style=flat-square)](#)
[![Release](https://img.shields.io/github/release/langhsu/mblog.svg?style=flat-square)](https://github.com/langhsu/mblog)
[![license](https://img.shields.io/badge/license-GPL--3.0-green.svg)](https://github.com/langhsu/mblog/blob/master/LICENSE)
[![Docker](https://img.shields.io/docker/automated/langhsu/mblog.svg?style=flat-square)](https://hub.docker.com/r/langhsu/mblog)
[![QQ群](https://img.shields.io/badge/chat-Mtons-green.svg)](https://jq.qq.com/?_wv=1027&k=521CRdF)

### 技术选型：

- Asp.Net Core3.1
- MySQL / Sql Server
- SYZERO
- Vue
- Nuxt.js
- ElementUI
- D2Admin
 
### 启动：

- /src/syzeroblog-webapi WebApi 接口
- /src/syzeroblog-admin 后台管理界面
- /src/syzeroblog-ssr 前台界面234

```xml
配置：src/main/resources/application-mysql.yml (数据库账号密码)、新建db_mblog的数据库
运行：src/main/java/com/mtons/mblog/BootApplication
访问：http://localhost:8080/
后台：http://localhost:8080/admin
账号：默认管理员账号为 admin/12345
```

- 演示
  - 前台: [http://demo.blog.syzero.com](http://demo.blog.syzero.com)
  - 后台管理: [http://demo.blog.syzero.com/admin](http://demo.blog.syzero.com/admin)
- QQ 交流：522112669

### 功能简介

- 编辑器：支持 Markdown 富文本编辑器
- 友情链接：站长可自由配置友情链接
- 百度推送：支持百度推送功能，加速百度搜索引擎收录博文
- 评论系统：支持匿名评论、回复
- 权限管理：后台配备完善的权限管理
- SEO：使用 SSR(服务端渲染)技术
- 系统配置：可通过后台手动修改域名信息、SEO 优化、赞赏码等
- 文件存储：目前仅支持本地文件存储
- 页面管理：支持自定义页面
- 验证码：注册验证码使用阿里短信

### 版本(1.0)更新内容：

    1. 文件存储目录可配置, 见 site.location, 默认为 user.dir
    2. 支持在${site.location}/storage/templates 目录下扩展自己的主题(${site.location}具体位置见启动日志)
    3. 后台未配置对应第三方登录信息时, 前端不显示对应的按钮
    4. 模板优化
    5. 后台配置主题改为自动从目录中加载
    6. 新增markdown编辑器, 可在后台选择tinymce/markdown

### 图片演示
![首页](https://images.gitee.com/uploads/images/2020/0520/102220_661dfb4c_2332485.png "首页.png")
![博文管理](https://images.gitee.com/uploads/images/2020/0520/102023_db50610d_2332485.png "博文管理.png")
![文章编辑](https://images.gitee.com/uploads/images/2020/0520/102044_dcabb116_2332485.png "文章编辑.png")
![系统配置](https://images.gitee.com/uploads/images/2020/0520/102119_90f3a657_2332485.png "系统配置.png")