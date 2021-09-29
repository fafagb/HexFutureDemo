# HexFutureDemo 项目说明
## 项目基本信息
    * github托管地址：https://github.com/fafagb/HexFutureDemo.git
    * 开发工具：vs和vscode混合开发
## 项目框架搭建命令（根目录HexFutureDemo）
    * cd  Domain
    * dotnet  new  classlib   -n  Domain.StudentModel
    * dotnet  new  classlib   -n  Domain.ClassModel
    * dotnet  new  classlib   -n  Domain.ClassStudentRelationshipModel
    * cd Domain\Impl
    * dotnet  new  classlib   -n  Domain.StudentModel.Service.Impl
    * dotnet  new  classlib   -n  Domain.ClassModel.Service.Impl
    * dotnet  new  classlib   -n  Domain.ClassStudentRelationshipModel.Service.Impl
    * cd DomainServer
    * dotnet  new  webapi   -n  ManageClassDomainServer
    * cd WebApi
    * dotnet  new  classlib   -n  ManageClassWebApi
    * dotnet  new  console   -n  ManageClassWebApiServer
    * dotnet new sln --name "ManageClass"
    * dotnet  sln   ManageClass.sln   add    Domain\Domain.ClassModel\Domain.ClassModel.csproj
    * dotnet  sln   ManageClass.sln   add    **/*.csproj
    * 命令创建可以解决vs解决方案文件夹和磁盘文件夹不同步的问题
## 项目启动命令
    * dotnet  ManageClassWebApiServer.dll --webApiServiceAddress http://localhost:10020 --zkConfigServer w1.confandsa.zk.group.hex.com:2181,w2.confandsa.zk.group.hex.com:2181,w3.confandsa.zk.group.hex.com:2181 --zkAppRole GB-ManageClassApi --runScope Core991 --msGroup zw5 --zkTimeOut 1000000000 --mcTimeOut 100000000 --minThreadCount 100 --webApiHelp on --trace off --debugPrefix debuggb --debugCompile true     --ser protobuf
    * dotnet  ManageClassDomainServer.dll --serviceName manageClass-gb --zkConfigServer w1.confandsa.zk.group.hex.com:2181,w2.confandsa.zk.group.hex.com:2181,w3.confandsa.zk.group.hex.com:2181        --zkAppRole Demo-ReadEbook   --aop off  --minThreadCount 10 --serviceAddress  debuggb:tcp://localhost:20010  --runScope Core991 --msGroup zw5 --zkTimeOut 5000 --mcTimeOut 1000000  --debugCompile true    --trace file   --ser protobuf  --KPversion  2   --psapp v2

## 遇到的问题
    * System.Exception: 加载Domain.ClassModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null失败！异常：System.Exception: 编译EntAppSoft.Infrastructure.ClassModel.Auto.dll出错：System.UnauthorizedAccessException: Access to the path 'D:\mywork\github\HexFutureDemo\DomainServer\ManageClassDomainServer\bin\Debug\netcoreapp3.1\EntAppSoft.Infrastructure.ClassModel.Auto.pdb' is denied.
    * 解决方案 Class改为GClass
    * dotnetcore的控制台经常会假死
    * 解决方案 用powershell
    * zookeeper经常会连接超时
    * 代码改动要删除代理文件 p_Domain.ClassModel.Service.Interface_ClassClientProxy.dll 后进行调试
    * list = await Where(x => x.Grade.Key == gradeId && x.Name.Contains(className)).SearchNPAsync();   只能左模糊  linq是左右都模糊
    * 需要定义新变量接受参数  string code = studentDTO.StudentCode;var entity = await this.Where(entity => entity.StudentCode == code).Top(1).FindTopAsync();
![alt 报错1](file:///D:/mywork/github/HexFutureDemo/img/%E6%8A%A5%E9%94%991.png "报错1")
![alt 报错2](file:///D:/mywork/github/HexFutureDemo/img/报错2.png "报错2")
