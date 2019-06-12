
FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS Domain
# WORKDIR /app
# COPY 
# RUN dotnet restore 
# RUN dotnet build 

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS Data
# WORKDIR /app
# COPY 
# COPY 
# RUN dotnet restore 
# RUN dotnet build 

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS WebApi
# WORKDIR /app
# COPY 
# COPY 
# COPY 
# RUN dotnet restore 
# RUN dotnet build 
# RUN dotnet publish 

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS WebClient
# WORKDIR /app
# COPY 
# RUN dotnet restore 
# RUN dotnet build 
# RUN dotnet publish 

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS deploy
WORKDIR /app
COPY --from=WebClient app/out/ ./
CMD ["dotnet", ".dll"]
