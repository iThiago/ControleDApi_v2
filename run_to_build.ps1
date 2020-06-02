docker run --rm -it `
 -v $pwd\:c:\src `
 -v $pwd\docker:c:\out `
 dockersamples/modernize-aspnet-builder `
 C:\src\build.ps1 