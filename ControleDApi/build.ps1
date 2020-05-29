$nuGetPath = "C:\Chocolatey\bin\nuget.bat"
$msBuildPath = "C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe"

cd c:\src
& $nuGetPath restore .\ControleDApi.sln
& $msBuildPath .\ControleDApi\ControleDApi.csproj /p:OutputPath=c:\out\web\ControleDApi /p:DeployOnBuild=true /p:VSToolsPath=C:\MSBuild.Microsoft.VisualStudio.Web.targets.14.0.0.3\tools\VSToolsPath
