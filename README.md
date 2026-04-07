# JwtAuthDemo

Простой проект на **.NET 10** с JWT авторизацией и PostgreSQL.  
Демонстрирует регистрацию, логин, JWT + refresh токены и защищённые endpoints с Swagger.

Repo: [https://github.com/NikaNGit/JwtAuthDemo](https://github.com/NikaNGit/JwtAuthDemo)

---

## 1. Клонирование 

```bash
git clone https://github.com/NikaNGit/JwtAuthDemo.git
cd JwtAuthDemo
```

## 2. Настройка PostgreSQL

Создать базу и пользователя (фейковые данные):

```
CREATE DATABASE "DemoDb";
CREATE USER demo WITH PASSWORD 'demo';
GRANT ALL PRIVILEGES ON DATABASE "DemoDb" TO demo;
GRANT USAGE, CREATE ON SCHEMA public TO demo;
ALTER DEFAULT PRIVILEGES IN SCHEMA public GRANT ALL PRIVILEGES ON TABLES TO demo;
```

В **appsettings.json** проверить _ConnectionStrings_:

```
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=DemoDb;Username=demo;Password=demo"
}
```

## 3. Настройка JWT (фейковые секреты)

```
  "JwtSettings": {
    "Issuer": "DemoProject",
    "Audience": "DemoUsers",
    "SecretKey": "super-secret-key-that-is-at-least-32-characters",
    "ExpiryMinutes": 15,
    "RefreshTokenExpiryDays": 7
  }
```

## 4. Установка пакетов и миграции

```
dotnet restore
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## 5. Запуск проекта

` dotnet run `

Swagger: [http://localhost:5250/swagger](http://localhost:5250/swagger)

## 6. Тестирование через Swagger

Регистрация: **POST /api/auth/register**
{ "username": "_xxx_", "password": "_yyy_" }

Логин: **POST /api/auth/login** → получить JWT

Авторизация: кнопка **Authorize** в Swagger → вставить: _Bearer <JWT_TOKEN>_

Доступ к защищённому endpoint: **GET /api/test/protected**

---
**Технологии:** .NET 10, EF Core 10 + PostgreSQL, JWT, Swagger, BCrypt
