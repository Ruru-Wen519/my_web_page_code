# 使用 .NET Core SDK 作為基礎鏡像
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# 複製專案文件
COPY . ./

# 還原 NuGet 套件
RUN dotnet restore

# 建置應用程式
RUN dotnet publish -c Release -o out

# 使用 .NET Core Runtime 作為最終鏡像
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "webapi_order_system.dll"]