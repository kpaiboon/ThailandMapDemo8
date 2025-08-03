FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5500  # เปิด port 5500 ใน container สำหรับ mapping กับ host

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "ThailandMapDemo8/ThailandMapDemo8.csproj"
RUN dotnet publish "ThailandMapDemo8/ThailandMapDemo8.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:5500  # กำหนดให้ ASP.NET Core ฟังที่ port 5500 ใน container
ENTRYPOINT ["dotnet", "ThailandMapDemo8.dll"]

# วิธีรัน container และ map port:
# docker build -t thailandmapdemo8 .
# docker run -p 5500:5500 thailandmapdemo8

# หมายเหตุ:
# - หากต้องการเปลี่ยน port ที่ host ให้แก้ตัวเลขหน้าคำสั่ง -p เช่น -p 8080:5500
# - สามารถใช้ environment variable ASPNETCORE_ENVIRONMENT เพื่อกำหนดโหมด (Development/Production)
# - ตรวจสอบว่าไฟล์ publish อยู่ใน