del MorpherSDK.zip

winrar a -m5 -ierr -r MorpherSDK.zip *.cs *.csproj *.sln *.resx *.svcinfo *.datasource *.svcmap *.wsdl *.disco Morpher.API\bin\Release\Morpher.API.dll Morpher.API\bin\Release\Morpher.API.xml *.aspx *.css *.config Site.master -x*\TestResults\*

if errorlevel 2 goto error

goto exit

:error
echo Error!

:exit
