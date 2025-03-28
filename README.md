# API_Poliza

Este proyecto es parte de una **prueba técnica** para el manejo de pólizas y asegurados. Desarrollado con **ASP.NET Core Web API**, **Entity Framework** y **SQL Server** para el backend, y un frontend construido en React.

---

## 🔗 Frontend relacionado

El frontend que consume esta API se encuentra en el siguiente repositorio:

👉 [https://github.com/Yuvania/FrontBP](https://github.com/Yuvania/FrontBP)

---

## ⚙️ Tecnologías utilizadas

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- C#
- React (para el frontend)
- Vite + TypeScript (en el frontend)

---

## 🗄️ Base de datos

Antes de ejecutar la API, es necesario crear las tablas y poblar la base de datos.

📄 Ejecutá el siguiente script SQL en tu instancia de SQL Server:

🔗 [SCRIPT_DB.sql](https://github.com/Yuvania/API_Poliza/blob/master/SCRIPT_DB.sql)

---

## 🚀 Cómo ejecutar el backend

1. Abrí la solución `API_Poliza.sln` en **Visual Studio**.
2. Asegurate de tener configurado **SQL Server** y haber ejecutado el script `SCRIPT_DB.sql`.
3. Presioná el **botón verde de "Iniciar con perfil de lanzamiento HTTP"** (ícono ▶️ con texto `https`) en la parte superior de Visual Studio.  
   Esto iniciará el servidor y expondrá los endpoints de la API usando **Kestrel** o **IIS Express**, según la configuración.

---

## 💻 Cómo ejecutar el frontend

> 📌 **Abrí el proyecto en Visual Studio Code para una mejor experiencia.**

1. Cloná el repositorio del frontend:
   ```bash
   git clone https://github.com/Yuvania/FrontBP
   cd FrontBP
1. Instalá las dependencias:
   ```bash
   npm install
3. Iniciá el servidor de desarrollo:
   ```bash
    npm run dev

---

## 🔐 Acceso al sistema
Una vez levantado el frontend, accedé al sistema con:

- **Usuario:** `admin`
- **Contraseña:** `1234`

Desde ahí podrás acceder a los CRUD de Asegurados y Pólizas.

---

## ✨ Autoría
Desarrollado por Yuvania  Castillo como parte de un reto técnico.
