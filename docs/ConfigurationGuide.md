# Configuration Guide

## 快速指引

### 部署配置

部署配置通过程序根目录下的appsettings.json文件实施，部署配置主要包括：

* 产品名称和运营组织名称
* 程序所使用的后端数据库和连接字符串
* 可选的OAuth/OIDC外部登录解决方案
* 运行日志记录级别

更改appsettings.json配置后，必须重新启动网站才能生效。

## 配置参考

### appsettings.json