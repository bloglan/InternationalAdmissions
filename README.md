# International Admissions Portal

国际招生门户是一个面向国际学生的门户网站系统，用于发布国际招生信息，办理招生报名、资料递交、留学生档案管理等功能。

## 特性

* 支持通过扫描件或照片识别护照、签证等格式化证件（使用第三方OCR识别服务）
* 支持学生资料的提交、审定、退回等业务流程
* 支持多语言（简体中文、英语）
* 根据学生提交资料执行统计分析
* 发布国际学术项目介绍，发布招生计划
* 支持广告位、文章和博客系统

## 路线图

* 门户部分板块的关闭（禁用）功能

## 开发/调试

### 数据库迁移

```powershell
dotnet ef migrations add <MigrationName> -c PersonIdentityDbContext -o Migrations/PersonIdentityDb
dotnet ef migrations add <MigrationName> -c StudentDocumentDbContext -o Migrations/StudentDocumentDb
```

## Installing

### Initialize Database

1. Install EntityFramework Tools like below:
``` powershell
dotnet tools install dotnet-ef -g
```

2. Create or Upgrade database via Migrations

Locate to application root directory (where .csproj file stored), execute commands below
``` powershell
dotnet ef database update -c PersonIdentityDbContext
dotnet ef database update -c StudentDocumentDbContext
```
> If database has exists, you can run `dotnet ef database delete` before migrations.

3. Initialize Data

## 调试测试数据

为便于调试和集成测试，开发和调试期间，系统将创建如下测试数据：

用户

|登录名|密码|名字|角色|
|---|---|---|---|
|admin@example.com|Pass123$|张三|Administrators|
|mike@example.com|Pass123$|Mike|Teachers|
|andy@example.com|Pass123$|Andy|N/A *|

学生和其他注册者没有赋予角色。

## 发布/部署

有关发布和部署的信息，请参阅[部署指南](docs/Deployment.md)。

有关产品配置的详细资料，请参阅[配置指南](docs/ConfigurationGuide.md)