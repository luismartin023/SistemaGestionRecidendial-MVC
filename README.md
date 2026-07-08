# 🏢 Sistema de Gestión Residencial - MVC (Windows Forms)

Sistema de administración de apartamentos, inquilinos, contratos y pagos desarrollado con **Windows Forms** y el patrón **MVC (Model-View-Controller)**.

**Repositorio:** https://github.com/luismartin023/SistemaGestionRecidendial-MVC.git

---

## 👥 Equipo de Desarrollo

| Miembro | Rol | Rama GitHub |
|---------|-----|-------------|
| Luis | Modelos | `feature/luis-modelos` |
| Ángel | Repositorios | `feature/angel-repositorios` |
| Yadfreidel | Controllers | `feature/yadfreidel-controllers` |
| Railyn | Windows Forms (Views) | `feature/railyn-vistas` |
| Alberto | Configuración | `feature/alberto-config` |

---

## 🎯 Características

### Gestión de Apartamentos
- CRUD completo
- 4 estados: Disponible, Ocupado, En Mantenimiento, Pendiente Renovación
- Filtros por estado
- Información detallada: número, piso, bloque, habitaciones, metros cuadrados, precio

### Gestión de Inquilinos
- CRUD completo
- Tipos de documento: Cédula, Pasaporte
- Foto del inquilino
- Búsqueda por nombre y documento

### Gestión de Contratos
- CRUD completo
- Validación de duración mínima (1 año)
- Solo 1 contrato activo por apartamento
- Información: apartamento, inquilino, fechas, monto mensual, depósito

### Gestión de Pagos
- CRUD completo
- Pago siempre completo (sin parciales)
- Recargo del 3% por mora
- Número de recibo automático
- Métodos: Efectivo, Transferencia, Tarjeta

### Autenticación y Roles
- 3 roles: Admin, Recepcionista, Usuario
- Login con hash de contraseña
- Dashboards diferentes por rol
- Cambio de contraseña

---

## 🏗️ Arquitectura MVC

```
┌─────────────────────────────────────┐
│  Views (Windows Forms)             │  ← Railyn
│  - MainForm                        │
│  - LoginForm                       │
│  - DashboardForms                  │
│  - CRUD Forms                      │
└──────────────┬──────────────────────┘
               │
┌──────────────▼──────────────────────┐
│  Controllers                       │  ← Yadfreidel
│  - ApartamentoController           │
│  - InquilinoController             │
│  - ContratoController              │
│  - PagoController                  │
│  - AuthController                  │
│  - DashboardController             │
└──────────────┬──────────────────────┘
               │
┌──────────────▼──────────────────────┐
│  Repositories                       │  ← Ángel
│  - IRepository<T>                  │
│  - ApartamentoRepository           │
│  - InquilinoRepository             │
│  - ContratoRepository              │
│  - PagoRepository                  │
└──────────────┬──────────────────────┘
               │
┌──────────────▼──────────────────────┐
│  DbContext                         │  ← Luis
│  - ResidencialDbContext            │
│  - Models (Entidades)              │
└─────────────────────────────────────┘
```

---

## 📦 Tecnologías

- **Framework:** .NET 8+
- **UI:** Windows Forms
- **ORM:** Entity Framework Core
- **Base de Datos:** SQLite
- **Lenguaje:** C#

### Paquetes NuGet
- `Microsoft.EntityFrameworkCore.Sqlite`
- `Microsoft.EntityFrameworkCore.Tools`

---

## 🚀 Configuración Inicial

### 1. Clonar el repositorio
```bash
git clone https://github.com/luismartin023/SistemaGestionRecidendial-MVC.git
cd SistemaGestionRecidendial-MVC
```

### 2. Crear rama personal
```bash
git checkout -b feature/[tu-nombre]-[tu-tarea]
# Ejemplo: git checkout -b feature/luis-modelos
```

### 3. Instalar paquetes NuGet
```bash
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

### 4. Compilar el proyecto
```bash
dotnet build
```

### 5. Ejecutar
```bash
dotnet run
```

---

## 📁 Estructura del Proyecto

```
SistemaGestionRecidencial-MVC/
├── SISTEMA/              ← Código del proyecto
│   ├── Models/              ← Luis (Entidades de datos)
│   │   ├── Enums/
│   │   ├── Apartamento.cs
│   │   ├── Inquilino.cs
│   │   ├── Contrato.cs
│   │   ├── Pago.cs
│   │   └── Usuario.cs
│   ├── Data/                ← Luis (DbContext)
│   │   ├── ResidencialDbContext.cs
│   │   └── DbInitializer.cs
│   ├── Interfaces/          ← Ángel (Interfaces de repositorios)
│   │   ├── IRepository.cs
│   │   ├── IApartamentoRepository.cs
│   │   ├── IInquilinoRepository.cs
│   │   ├── IContratoRepository.cs
│   │   └── IPagoRepository.cs
│   ├── Repositories/        ← Ángel (Implementación de repositorios)
│   │   ├── Repository.cs
│   │   ├── ApartamentoRepository.cs
│   │   ├── InquilinoRepository.cs
│   │   ├── ContratoRepository.cs
│   │   └── PagoRepository.cs
│   ├── Controllers/         ← Yadfreidel (Lógica de negocio)
│   │   ├── ApartamentoController.cs
│   │   ├── InquilinoController.cs
│   │   ├── ContratoController.cs
│   │   ├── PagoController.cs
│   │   ├── AuthController.cs
│   │   └── DashboardController.cs
│   ├── Forms/               ← Railyn (Windows Forms)
│   │   ├── MainForm.cs
│   │   ├── LoginForm.cs
│   │   ├── DashboardAdminForm.cs
│   │   ├── DashboardRecepcionistaForm.cs
│   │   ├── DashboardUsuarioForm.cs
│   │   ├── ApartamentoForm.cs
│   │   ├── InquilinoForm.cs
│   │   ├── ContratoForm.cs
│   │   ├── PagoForm.cs
│   │   └── CambiarPasswordForm.cs
│   ├── Services/            ← Alberto (Configuración)
│   │   └── DependencyInjection.cs (opcional)
│   ├── Program.cs           ← Alberto (Punto de entrada)
│   └── App.config           ← Alberto (Configuración)
└── ESQUEMA/             ← Documentación del proyecto
    ├── FLUJO_TRABAJO.md
    ├── PLAN_TRABAJO.md
    ├── PRONT.md
    ├── IMPLEMENTATION_PLAN.md
    ├── ROLES_Y_RESPONSABILIDADES.md
    └── SISTEMA_DESCRIPCION.md
```

---

## 🔐 Usuarios de Prueba

| Usuario | Contraseña | Rol |
|---------|-----------|-----|
| admin | admin123 | Admin |
| recepcionista | recepcionista123 | Recepcionista |
| usuario | usuario123 | Usuario |

---

## 📊 Flujo de Trabajo

1. Cada miembro trabaja en su rama propia
2. Se hace pull request a `develop` para revisión
3. El equipo hace merge a `develop` después de revisión (por consenso)
4. Cuando está completo, se hace merge a `main`

**Ver detalles completos en:** [FLUJO_TRABAJO.md](./FLUJO_TRABAJO.md)

---

## 📋 Plan de Trabajo

El proyecto se divide en 4 sesiones:

### Sesión 1 — Cimientos
- Luis: Modelos y DbContext
- Ángel: Interfaces y Repositorios
- Yadfreidel: Estructura de Controllers
- Railyn: MainForm y LoginForm
- Alberto: Program.cs y App.config

### Sesión 2 — Base de datos y Login
- Integración de todos los componentes
- AuthController completo
- DashboardForms básicos

### Sesión 3 — Módulos CRUD
- Controllers completos
- Forms CRUD completos
- Integración Controllers + Forms

### Sesión 4 — Pulido
- Pruebas de punta a punta
- Ajustes de diseño
- Merge final a main

**Ver detalles completos en:** [PLAN_TRABAJO.md](./PLAN_TRABAJO.md)

---

## 🎨 Diseño

### Paleta de Colores
- **Primario:** Azul (#0078D4)
- **Secundario:** Azul oscuro (#005A9E)
- **Fondo:** Gris claro (#F5F5F5)
- **Texto:** Negro (#000000)
- **Blanco:** (#FFFFFF)

### Componentes UI
- DataGridView para listas
- TextBox para entrada de texto
- ComboBox para selecciones
- Button para acciones
- Panel para contenedores
- SplitContainer para layouts divididos

---

## 🔄 Reutilización

Este proyecto MVC **reutiliza** los modelos y repositorios del proyecto WPF/MVVM existente:
- **Repositorio WPF:** https://github.com/Yadfreidel/SistemaResidencial.git
- **Qué se reutiliza:** Models, Interfaces, Repositories
- **Qué es nuevo:** Controllers, Windows Forms, Configuración

---

## 📝 Documentación

- [FLUJO_TRABAJO.md](./FLUJO_TRABAJO.md) - Flujo de trabajo y ramas
- [PLAN_TRABAJO.md](./PLAN_TRABAJO.md) - Plan detallado por miembro
- [PRONT.md](./PRONT.md) - Objetivos y requisitos
- [IMPLEMENTATION_PLAN.md](./IMPLEMENTATION_PLAN.md) - Pasos de implementación

---

## ✅ Criterios de Aceptación

- [ ] Login funciona con los 3 usuarios de prueba
- [ ] Dashboards muestran información correcta según rol
- [ ] CRUD de Apartamentos funciona con los 4 estados
- [ ] CRUD de Inquilinos funciona con foto y documento
- [ ] CRUD de Contratos valida duración mínima de 1 año
- [ ] CRUD de Pagos calcula mora del 3% automáticamente
- [ ] Cambio de contraseña funciona
- [ ] Búsqueda y filtros funcionan en todas las listas
- [ ] Código compila sin errores
- [ ] Patrón MVC se respeta correctamente

---

## 📞 Contacto

- **Contacto del equipo:** Luis
- **Repositorio:** https://github.com/luismartin023/SistemaGestionRecidendial-MVC.git

---

## 📄 Licencia

Este proyecto es desarrollado con fines educativos para el equipo de desarrollo.
