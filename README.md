# HexFutureDemo

# 项目说明
# 

# github托管地址：https://github.com/fafagb/HexFutureDemo.git
# vscode文件夹管理
# dotnet项目框架搭建命令
#  cd  D:\mywork\github\HexFutureDemo\Domain
# dotnet  new  classlib   -n  Domain.StudentModel
# dotnet  new  classlib   -n  Domain.ClassModel
# dotnet  new  classlib   -n  Domain.ClassStudentRelationshipModel

#  cd D:\mywork\github\HexFutureDemo\Domain\Impl

# dotnet  new  classlib   -n  Domain.StudentModel.Service.Impl
# dotnet  new  classlib   -n  Domain.ClassModel.Service.Impl
# dotnet  new  classlib   -n  Domain.ClassStudentRelationshipModel.Service.Impl

# cd D:\mywork\github\HexFutureDemo\DomainServer
# dotnet  new  console   -n  ManageClassDomainServer   纠正===》  dotnet  new  webapi   -n  ManageClassDomainServer

#  D:\mywork\github\HexFutureDemo\WebApi

# dotnet  new  classlib   -n  ManageClassWebApi

# dotnet  new  console   -n  ManageClassWebApiServer

# cd  D:\mywork\github\HexFutureDemo
#  dotnet new sln --name "ManageClass"




#  dotnet  sln   ManageClass.sln   add    D:\mywork\github\HexFutureDemo\Domain\Domain.ClassModel\Domain.ClassModel.csproj

# 此方式可以解决vs解决方案文件夹和磁盘文件夹不同步的问题



# 错误一  System.Exception: 加载Domain.ClassModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null失败！异常：System.Exception: 编译EntAppSoft.Infrastructure.ClassModel.Auto.dll出错：System.UnauthorizedAccessException: Access to the path 'D:\mywork\github\HexFutureDemo\DomainServer\ManageClassDomainServer\bin\Debug\netcoreapp3.1\EntAppSoft.Infrastructure.ClassModel.Auto.pdb' is denied.


# 错误一解决方案
# Class改为GClass

# 命令
# dotnet  ManageClassWebApiServer.dll --webApiServiceAddress http://localhost:10020 --zkConfigServer w1.confandsa.zk.group.hex.com:2181,w2.confandsa.zk.group.hex.com:2181,w3.confandsa.zk.group.hex.com:2181 --zkAppRole GB-ManageClassApi --runScope Core991 --msGroup zw5 --zkTimeOut 1000000000 --mcTimeOut 100000000 --minThreadCount 100 --webApiHelp on --trace off --debugPrefix debuggb --debugCompile true     --ser protobuf


# dotnet  ManageClassDomainServer.dll --serviceName manageClass-gb --zkConfigServer w1.confandsa.zk.group.hex.com:2181,w2.confandsa.zk.group.hex.com:2181,w3.confandsa.zk.group.hex.com:2181        --zkAppRole Demo-ReadEbook   --aop off  --minThreadCount 10 --serviceAddress  debuggb:tcp://localhost:20010  --runScope Core991 --msGroup zw5 --zkTimeOut 5000 --mcTimeOut 1000000  --debugCompile true    --trace file   --ser protobuf  --KPversion  2   --psapp v2


#  EBook 测试请求串  http://localhost:10020/UserReadEbook/SearchEbookCategoryAsync?categoryName=%E5%8F%A4%E5%85%B8



# ManageClass 测试请求串  http://localhost:10020/ManageClass/SearchClassCategoryAsync?categoryName=%E9%AB%98%E4%B8%80




# 存在的问题，dotnetcore的控制台经常会假死，需要按回车
# zookeeper经常会连接超时

# probufer 在http传输过程中更安全，但是现在到后端传输需要二次转换


# 要删除代理文件 p_Domain.ClassModel.Service.Interface_ClassClientProxy.dll


#  //   list = await Where(x => x.Grade.Key == gradeId && x.Name.Contains(className)).SearchNPAsync();   只能左模糊  linq是左右都模糊



#   需要用变量接受参数  string code = studentDTO.StudentCode;var entity = await this.Where(entity => entity.StudentCode == code).Top(1).FindTopAsync();