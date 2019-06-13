
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /app
<<<<<<< HEAD
COPY $(ArtifactDirectory) ./
=======
COPY ArtifactDirectory ./
>>>>>>> Development
CMD ["dotnet", "WebClient.dll"]
