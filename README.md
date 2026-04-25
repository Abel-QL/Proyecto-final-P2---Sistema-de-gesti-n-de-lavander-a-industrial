# 🌕 Moon Laundry — Sistema de Gestión de Lavandería Industrial (SGL)

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=for-the-badge&logo=dotnet)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![React](https://img.shields.io/badge/React-18.2-61DAFB?style=for-the-badge&logo=react&logoColor=black)
![TailwindCSS](https://img.shields.io/badge/Tailwind_CSS-38B2AC?style=for-the-badge&logo=tailwind-css&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)

## 📖 Descripción del Proyecto
**Moon Laundry** es una plataforma de software B2B diseñada para administrar y optimizar las operaciones de lavanderías industriales. El sistema permite gestionar la cartera de clientes corporativos, controlar el ciclo de vida de los lotes de ropa (desde la recepción hasta el despacho), automatizar la facturación y planificar rutas de entrega. 

Este proyecto resuelve el problema de la trazabilidad en operaciones a gran escala, asegurando que cada libra de ropa procesada sea auditada, facturada y entregada correctamente, operando bajo una robusta arquitectura distribuida N-Capas.

---

## ⚙️ Requerimientos Funcionales

### 1. Directorio B2B (Gestión de Clientes)
- Registrar empresas con su Razón Social, RNC (validado), y límite de crédito aprobado.
- Mantener un registro de contactos autorizados (teléfono y correo) para facturación.
- Visualización unificada del perfil financiero del cliente.

### 2. Control de Planta (Gestión de Lotes)
- Ingreso de lotes especificando cliente, peso total (Kg), cantidad de artículos y el Operador receptor.
- **Trazabilidad de Estado:** Transición de estados operativos (`RECEPCIONADO` -> `EN PROCESO` -> `FINALIZADO` -> `ENTREGADO`).
- **Auditoría Estricta:** Registro automático en el historial de transiciones, vinculando qué operador autorizó el cambio de estado y en qué momento exacto.

### 3. Tesorería y Facturación
- Emisión de comprobantes fiscales asociando directamente un lote procesado a un cliente.
- Cálculo automático de impuestos (ITBIS 18%) mediante sobrecarga de métodos en la capa de servicios.
- Control de cuentas por cobrar con liquidación interactiva de balances (`PENDIENTE` a `PAGADO`).

### 4. Logística de Entregas
- Asignación de Lotes finalizados a conductores específicos.
- Registro de placa del vehículo y fecha/hora programada para la ruta.
- Control del estado del despacho en tiempo real.

### 5. Dashboard General
- Panel analítico en tiempo real que consolida: Lotes activos en planta, cartera de clientes, facturación bruta acumulada y entregas pendientes.

---

## 🚀 Requerimientos No Funcionales

### 1. UI/UX y Diseño Centrado en el Usuario
- **Single Page Application (SPA):** Interfaz web servida directamente desde el `wwwroot` de la API, construida con React y estilizada con Tailwind CSS.
- **Heurísticas de Nielsen Aplicadas:** - *Prevención de errores y Control:* Cuadros de diálogo (`DialogoNotificacion`) que exigen confirmación antes de asentar pagos o modificar registros.
  - *Visibilidad del Estado:* Alertas asíncronas tipo Toast y "Badges" de colores dinámicos para identificar el estado de lotes y facturas.
- Experiencia fluida sin recargas de página.

### 2. Rendimiento y Seguridad
- Programación 100% asíncrona (`async/await`) en toda la pila (Controllers, Services y Repositories) para evitar el bloqueo del hilo principal.
- Uso del patrón **DTO (Data Transfer Object)** mediado por AutoMapper para evitar la sobreexposición del modelo de dominio.

### 3. Arquitectura y Patrones de Diseño
- **Clean Architecture:** Separación estricta del proyecto en capas: `SGL.Domain`, `SGL.Application`, `SGL.Infrastructure` y `SGL.API`.
- **Patrón Repository & Unit of Work:** Centralización de las transacciones de base de datos para garantizar la atomicidad (ej. Guardar un lote y su historial al mismo tiempo).
- **ORM:** Entity Framework Core 10 bajo el enfoque *Code-First*.

---

## 🧠 Conceptos de POO Aplicados

- **Clase Abstracta:** Se implementó la clase `BaseEntity` que define las propiedades transversales (`Id`, `Activo`, `FechaCreacion`). No puede ser instanciada directamente.
- **Herencia:** Todas las entidades del dominio (`Cliente`, `Lote`, `Factura`, etc.) heredan de `BaseEntity`, reutilizando su estructura.
- **Constructores Parametrizados:** Uso de constructores en las entidades (ej. `public Lote(int clienteId, decimal pesoTotal, ... )`) para asegurar que los objetos nazcan en un estado válido y consistente.
- **Sobrecarga de Métodos:** - En `LoteService`: `CambiarEstadoAsync(id, estado, operadorId)` y `CambiarEstadoAsync(id, estado, operadorId, observaciones)`.
  - En `FacturaService`: `CreateAsync(dto)` y `CreateAsync(dto, aplicarItbis)` para inyectar lógica de impuestos dinámicamente.
- **Encapsulamiento:** Ocultamiento de la lógica de asignación de fechas (`DateTime.UtcNow`) dentro de los Servicios de Aplicación, manteniendo las entidades como POCOs puros.

---

--
*Proyecto final desarrollado para la asignatura de Programación 2 (P2).*
