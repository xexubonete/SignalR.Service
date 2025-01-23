# 🚀 SignalR.Service

A real-time communication server built with **ASP.NET Core** and **SignalR**, designed for applications requiring live notifications, chat systems, dashboards, and more.

## ✨ Features

- **Real-time Communication**: WebSocket-based communication with fallback transport options
- **Cross-Origin Resource Sharing (CORS)**: Configured for specific origins
- **API Documentation**: Interactive Swagger documentation
- **Pre-configured ChatHub**: Handles connections, messages, and disconnections with IP tracking
- **Sample Client**: Includes a basic HTML/JavaScript client for testing

## 📋 Prerequisites

- **.NET 8.0 SDK** or higher
- WebSocket-compatible browser (Chrome, Firefox, Edge, Safari)
- Node.js (for running the test client)

## 📁 Project Structure

```
├── App
│   ├── index.html
│   ├── node_modules
│   │   └── http-server -> .pnpm/http-server@14.1.1/node_modules/http-server
│   ├── package.json
│   └── pnpm-lock.yaml
├── ChatHub.cs
├── Program.cs
├── Properties
│   └── launchSettings.json
├── README.md
├── SignalR.Service.csproj
├── SignalR.Service.http
├── SignalR.Service.sln
├── SignalR.Service.sln.DotSettings.user
├── appsettings.Development.json
└── appsettings.json
```

## 🚦 Getting Started

1. Clone the repository:
```bash
git clone https://github.com/xexubonete/SignalR.Service.git
cd SignalR.Service
```

2. Restore dependencies:
```bash
dotnet restore
```

3. Run the server:
```bash
dotnet run
```

4. To test with the sample client:
```bash
cd App
npm install
npx http-server
```

## ⚙️ Configuration

- **Server**: Runs on `http://localhost:5078` by default
- **SignalR Endpoint**: `/signalr`
- **CORS**: Configured for `http://localhost:8080` and `http://127.0.0.1:8080`
- **Swagger**: Available at `http://localhost:5078/swagger` in development mode

## 💻 Client Integration

```javascript
const connection = new signalR.HubConnectionBuilder()
    .withUrl("http://localhost:5078/signalr")
    .build();

// Handle notifications
connection.on("notify", message => {
    console.log("Server message:", message);
});

// Connect to hub
async function startConnection() {
    try {
        await connection.start();
        console.log("Connected successfully");
    } catch (err) {
        console.error("Connection failed:", err);
        setTimeout(startConnection, 5000);
    }
}
```

## 🔍 Features in Detail

### 💬 ChatHub Functionality
- Tracks client connections with IP addresses
- Broadcasts connection/disconnection events
- Supports message broadcasting between clients

### 🔒 Security
- CORS policy configured for development environments
- Supports both HTTP and HTTPS protocols
- Anonymous authentication enabled

## 👨‍💻 Development

The project uses:
- ASP.NET Core 8.0
- SignalR for real-time communications
- Swagger for API documentation
- jQuery and SignalR client libraries for the test application

## 📄 License

ISC License (as specified in package.json)
