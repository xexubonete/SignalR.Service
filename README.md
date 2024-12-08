# SignalR.Service

Este proyecto es un servidor basado en **ASP.NET Core** que utiliza **SignalR** para habilitar comunicación en tiempo real entre clientes y servidores. Es ideal para aplicaciones que requieren notificaciones en vivo, como chats, paneles de control, y más.

## Características

- **SignalR**: Comunicación en tiempo real con soporte para WebSockets y transporte de reserva.
- **CORS**: Configurado para aceptar solicitudes desde orígenes específicos.
- **Swagger**: Documentación interactiva de la API.
- **Ejemplo de Hub**: Contiene un `ChatHub` preconfigurado para manejar conexiones, mensajes y desconexiones.

## Requisitos previos

- **SDK de .NET 6 o superior**
- Un navegador compatible con WebSockets (como Chrome, Edge o Safari).
- Cliente para probar el servidor (por ejemplo, Postman o un frontend).

## Instalación

1. Clona este repositorio:
   ```bash
   git clone https://github.com/xexubonete/SignalR.Service.git
   cd SignalR.Service
   ```
2. Restaura los paquetes necesarios:
   ```bash
    dotnet restore
   ```
3. Configura el archivo appsettings.json si es necesario.

## Ejecución

1.	Inicia el servidor: 
```bash
  dotnet run
```
2.	Accede a la documentación Swagger en http://localhost:5000/swagger.

3.	Conecta un cliente a SignalR utilizando el endpoint:
```bash
  ws://localhost:5000/signalr
```
## Estructura del Proyecto
├── App  
&nbsp;   ├── index.html  
&nbsp;   ├── node_modules  
│   ├── package.json  
│   └── pnpm-lock.yaml  
├── Hubs.cs  
├── Program.cs  
├── Properties  
│   └── launchSettings.json  
├── README.md  
├── SignalR.Service.csproj  
├── SignalR.Service.http  
├── SignalR.Service.sln  
├── SignalR.Service.sln.DotSettings.user  
├── appsettings.Development.json  
├── appsettings.json  

## Uso de SignalR

### Ejemplo de cliente JavaScript
```javascript
// Crear conexión al Hub
const connection = new signalR.HubConnectionBuilder()
    .withUrl(hubUrl)
    .build();

// Manejo de eventos de conexión
connection.on("notify", message => {
    console.log("Mensaje recibido desde el servidor:", message);
});

// Abrir conexión
async function startConnection() {
    try {
        await connection.start();
        console.log("Conexión abierta con éxito");
    } catch (err) {
        console.error("Error al conectar:", err);
        setTimeout(startConnection, 5000); // Reintentar en 5 segundos
    }
}
```
### Endpoints relevantes
- _/signalr_: Endpoint de SignalR.
- _CORS_: Configurado para aceptar solicitudes desde http://localhost:8080.

### Arquitectura del proyecto
- **Program.cs**: Configuración principal de la aplicación (CORS, SignalR, Swagger).  
- **Hubs.cs**: Implementación del ChatHub, que gestiona las conexiones y mensajes de los clientes.  
- **appsettings.json**: Configuraciones generales de la aplicación.  
