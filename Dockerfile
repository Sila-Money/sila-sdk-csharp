FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster
RUN apt-get update
RUN apt-get install -y default-jdk