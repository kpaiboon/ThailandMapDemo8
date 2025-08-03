# ThailandMapDemo8

แอปพลิเคชันตัวอย่าง ASP.NET Core สำหรับแสดงแผนที่ประเทศไทยและเส้นทางด้วย Longdo Map และ OpenStreetMap

## วิธีใช้งาน

### 1. Clone Repo

```sh
git clone https://github.com/<your-username>/ThailandMapDemo8.git
cd ThailandMapDemo8
```

### 2. ตั้งค่า API Key สำหรับ Longdo Map

- เปิดไฟล์ `appsettings.json` หรือกำหนดใน Environment Variable
- หรือแก้ไขในไฟล์ `Views/Home/Index.cshtml` ตรง `@ViewBag.LongdoApiKey`

### 3. รันด้วย .NET Core (สำหรับนักพัฒนา)

```sh
dotnet restore
dotnet run
```
- เปิดเว็บเบราว์เซอร์ไปที่ `http://localhost:80` (หรือพอร์ตที่ตั้งไว้ใน `launchSettings.json`)

### 4. รันด้วย Docker

#### Build Docker Image

```sh
docker build -t thailandmapdemo8 .
```

#### Run Docker Container

```sh
docker run -p 5500:5500 thailandmapdemo8
```
- เปิดเว็บเบราว์เซอร์ไปที่ `http://localhost:5500`

#### หมายเหตุ
- หากต้องการเปลี่ยน port ที่ host ให้แก้ตัวเลขหน้าคำสั่ง -p เช่น `-p 8080:5500`
- สามารถใช้ environment variable `ASPNETCORE_ENVIRONMENT` เพื่อกำหนดโหมด (Development/Production)

### 5. การแก้ไข config

- **เปลี่ยนพอร์ต:**  
  แก้ไขไฟล์ `launchSettings.json` ที่ `applicationUrl` หรือแก้ไข Dockerfile ที่ `EXPOSE` และ `ENV ASPNETCORE_URLS`
- **เปลี่ยน API Key:**  
  แก้ไขในไฟล์ที่มีการใช้ `@ViewBag.LongdoApiKey` หรือกำหนดผ่าน environment variable

### 6. CI/CD (ถ้ามี)

- Workflow ตัวอย่างอยู่ที่ `.github/workflows/ci-cd.yml`
- ต้องตั้งค่า Secrets สำหรับ DockerHub ใน GitHub Actions

---

## โครงสร้างโปรเจกต์

```
ThailandMapDemo8/
├── ThailandMapDemo8/                # โค้ดโปรเจกต์หลัก
├── Properties/
│   └── launchSettings.json
├── .github/
│   └── workflows/
│       └── ci-cd.yml
├── Dockerfile
├── .gitignore
├── README.md
```

---

## ติดต่อ/สอบถาม

- เพิ่ม issue