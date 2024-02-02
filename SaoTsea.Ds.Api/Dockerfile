#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#docker build --no-cache -t swr.ap-southeast-2.myhuaweicloud.com/betimes/betimes-wfh_app:1.33 .
#docker run --rm -p 14121:14121 -t swr.ap-southeast-2.myhuaweicloud.com/betimes/betimes-wfh_app:1.33

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 3543

#--- Set timezone ---
ENV TZ=Asia/Bangkok
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

#--- Install lib ---
RUN apt-get update
RUN apt-get install -y software-properties-common
RUN apt-get update
RUN apt install -y libgdiplus libc6 libc6-dev
RUN apt install -y fontconfig libharfbuzz0b libfreetype6 libicu-dev libfontconfig1

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR "/src/."
COPY ["SaoTsea.Ds.Api/SaoTsea.Ds.Api.csproj", ""]
RUN dotnet restore "SaoTsea.Ds.Api.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "SaoTsea.Ds.Api/SaoTsea.Ds.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SaoTsea.Ds.Api/SaoTsea.Ds.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_ENVIRONMENT Production
ENV ASPNETCORE_URLS http://*:3543
ENTRYPOINT ["dotnet", "SaoTsea.Ds.Api/SaoTsea.Ds.Api.csproj.dll"]