# 📚 Flashcards AI – Sistema Inteligente de Memorización

[![.NET](https://img.shields.io/badge/.NET-8-blue?logo=dotnet)](https://dotnet.microsoft.com/)
[![License](https://img.shields.io/badge/License-GPL_v3-blue.svg)](LICENSE)
[![SQL Server](https://img.shields.io/badge/DB-SQL_Server-red?logo=Microsoft)](https://www.microsoft.com/sql-server)

**Flashcards AI** es una aplicación desarrollada en C# con .NET que permite a los usuarios crear, organizar y estudiar tarjetas de memorización (flashcards). Incorpora principios de Clean Architecture y planea integrar inteligencia artificial para mejorar la experiencia de aprendizaje.

---

## ✨ Características

- ✏️ Crear, editar y eliminar flashcards
- 🗂️ Agrupar tarjetas por mazos (decks)
- 👥 Autenticación y gestión de usuarios
- 📊 Seguimiento del progreso del usuario
- 🧠 Recomendaciones inteligentes (con IA en futuras versiones)

---

## 🧱 Arquitectura del Proyecto

Este proyecto sigue los principios de **Clean Architecture** para una mejor separación de responsabilidades y escalabilidad:

```
/Domain → Entidades puras del dominio (POCOs)
/Application → Interfaces, servicios, lógica de negocio
/Infrastructure → Acceso a datos (EF Core), DbContext, Repositorios
/WebAPI → Controladores, puntos de entrada HTTP
```

---

## ⚙️ Tecnologías Utilizadas

- **Lenguaje:** C# (.NET 8 o superior)
- **Base de datos:** SQL Server
- **ORM:** Entity Framework Core (Fluent API)
- **Arquitectura:** Clean Architecture
- **Frontend:** React
- **IA (Futuro):** Integración con modelos de lenguaje o algoritmos de aprendizaje adaptativo

---

## 🚀 Instalación y Ejecución

### 🔧 Requisitos previos

- [.NET SDK 8.0+](https://dotnet.microsoft.com/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server)
- [Visual Studio o VS Code](https://visualstudio.microsoft.com/)
- (Opcional) [EF Core CLI](https://learn.microsoft.com/es-es/ef/core/cli/)

### 🧪 Pasos para ejecutar localmente

1. **Clonar el repositorio**
   ```bash
   git clone https://github.com/CamiloSTDev/flashcards-with-AI.git
   cd flashcards-with-AI
   ```

2. **Actualizar cadena de conexión en archivo de configuracion .env:**
   ```bash
  
     DB_CONNECTION="Server=localhost;Database=FlashcardsApp;Trusted_Connection=True;"
   
   ```

3. **Aplicar migraciones y crear la base de datos**
   ```bash
   dotnet ef database update --project Infrastructure
   ```

4. **Ejecutar la aplicación**
   ```bash
   dotnet run --project WebAPI
   ```

---

## 🧠 Funcionalidad futura con IA

Se planea integrar funciones de IA para:

- Recomendaciones personalizadas de estudio
- Detección de tarjetas difíciles
- Generación automática de tarjetas con GPT

---

## 📌 Estado del Proyecto

🛠️ **En desarrollo** – se encuentra en una etapa inicial con enfoque en backend y estructura sólida para futuras integraciones inteligentes.

---

## 📄 Licencia

Este proyecto está bajo la licencia GNU General Public License v3.0 (GPL-3.0). Esto significa que puedes usar, modificar y distribuir el código, pero cualquier trabajo derivado debe también ser distribuido bajo la misma licencia GPL-3.0.

---

## 🤝 Contribuciones

¡Contribuciones son bienvenidas! Si quieres colaborar, abre un pull request o envía un issue para sugerencias o mejoras.
