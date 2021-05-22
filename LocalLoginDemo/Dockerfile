# escape=`

#Base Image from Microsoft
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build

#Enviornment Variables
ENV ASPNETCORE_URLS="http://*:5000"
ENV ASPNETCORE_ENVIRONMENT="Development"

#set up a directory in container
WORKDIR /scr

#copy sourceCode to /src folder on container
COPY LocalLoginDemo.Web/ .

#restore nuget packages -- #RUN: Used to execute a command during the build process of the docker image
RUN dotnet restore

#Build the app
RUN dotnet build

#Expose Port
EXPOSE 5000

#Run the app
ENTRYPOINT [ "dotnet", "run" ]

#docker image build -t locallogin .
#docker run --rm --name locallogin -p 5000:5000 locallogin
