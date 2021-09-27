# HexFutureDemo
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
# dotnet  new  console   -n  ManageClassDomainServer

#  D:\mywork\github\HexFutureDemo\WebApi

# dotnet  new  classlib   -n  ManageClassWebApi

# dotnet  new  console   -n  ManageClassWebApiServer

# cd  D:\mywork\github\HexFutureDemo
#  dotnet new sln --name "ManageClass"




#  dotnet  sln   ManageClass.sln   add    D:\mywork\github\HexFutureDemo\Domain\Domain.ClassModel\Domain.ClassModel.csproj

# 此方式可以解决vs解决方案文件夹和磁盘文件夹不同步的问题



# 错误一  System.Exception: 加载Domain.ClassModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null失败！异常：System.Exception: 编译EntAppSoft.Infrastructure.ClassModel.Auto.dll出错：System.UnauthorizedAccessException: Access to the path 'D:\mywork\github\HexFutureDemo\DomainServer\ManageClassDomainServer\bin\Debug\netcoreapp3.1\EntAppSoft.Infrastructure.ClassModel.Auto.pdb' is denied.




