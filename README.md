<!DOCTYPE html>
<html lang="es">
<head>
  <meta charset="UTF-8">
  <title>Support Assistant API</title>
  <style>
    body {
      font-family: Arial, Helvetica, sans-serif;
      line-height: 1.6;
      max-width: 900px;
      margin: auto;
      padding: 20px;
      color: #333;
    }
    h1, h2, h3 {
      color: #2c3e50;
    }
    code {
      background: #f4f4f4;
      padding: 3px 6px;
      border-radius: 4px;
    }
    pre {
      background: #f4f4f4;
      padding: 15px;
      overflow-x: auto;
      border-radius: 6px;
    }
    ul {
      margin-left: 20px;
    }
    .section {
      margin-bottom: 40px;
    }
  </style>
</head>
<body>

<h1>🤖 Support Assistant API</h1>

<p>
Support Assistant es una <strong>API de soporte técnico con inteligencia artificial</strong>
desarrollada en <strong>ASP.NET Core</strong>, pensada como un proyecto real de empresa.
La idea principal es simular una <em>mesa de ayuda</em> donde los usuarios pueden
hacer consultas técnicas, recibir respuestas automáticas con IA y, si es necesario,
crear tickets de soporte para ser atendidos por un administrador.
</p>

<p>
Este proyecto fue creado como parte de un portafolio profesional, aplicando buenas prácticas,
principios SOLID y una arquitectura limpia.
</p>

<div class="section">
  <h2>🛠️ Tecnologías utilizadas</h2>
  <ul>
    <li>ASP.NET Core Web API</li>
    <li>SQL Server</li>
    <li>Entity Framework Core</li>
    <li>JWT (Autenticación y Autorización)</li>
    <li>OpenAI API (ChatGPT)</li>
    <li>Swagger (documentación de la API)</li>
  </ul>
</div>

<div class="section">
  <h2>📐 Arquitectura</h2>
  <p>
    El backend está organizado siguiendo una estructura clara y escalable:
  </p>
  <ul>
    <li><strong>Controllers:</strong> manejan las peticiones HTTP</li>
    <li><strong>Services:</strong> contienen la lógica de negocio</li>
    <li><strong>Interfaces:</strong> definen contratos (SOLID - DIP)</li>
    <li><strong>DTOs:</strong> controlan los datos que entran y salen</li>
    <li><strong>Models:</strong> representan las entidades de la base de datos</li>
    <li><strong>Middlewares:</strong> manejo global de errores</li>
  </ul>
</div>

<div class="section">
  <h2>🔐 Autenticación</h2>
  <p>
    El sistema utiliza <strong>JWT</strong> para autenticación y autorización.
    Existen dos roles principales:
  </p>
  <ul>
    <li><strong>User:</strong> puede chatear con la IA y crear tickets</li>
    <li><strong>Admin:</strong> puede ver y gestionar todos los tickets</li>
  </ul>
</div>

<div class="section">
  <h2>💬 Chat con IA</h2>
  <p>
    Los usuarios pueden enviar mensajes a un endpoint de chat protegido.
    El mensaje se envía a la API de OpenAI, la respuesta se procesa y:
  </p>
  <ul>
    <li>Se devuelve al usuario</li>
    <li>Se guarda el historial en la base de datos</li>
    <li>Se clasifica el problema y su prioridad</li>
  </ul>
</div>

<div class="section">
  <h2>🎫 Sistema de Tickets</h2>
  <p>
    Cuando un problema no se puede resolver directamente, el usuario puede crear un ticket.
    El administrador puede:
  </p>
  <ul>
    <li>Ver todos los tickets</li>
    <li>Cambiar el estado (Open, In Progress, Closed)</li>
    <li>Gestionar solicitudes reales de soporte</li>
  </ul>
</div>

<div class="section">
  <h2>⚙️ Instalación y ejecución</h2>

  <h3>1. Clonar el repositorio</h3>
  <pre>
git clone https://github.com/tu-usuario/support-assistant-api.git
cd SupportAssistant.API
  </pre>

  <h3>2. Configurar la base de datos</h3>
  <p>
    Ejecuta el script SQL incluido para crear la base de datos
    <code>SupportAssistantDB</code> en SQL Server.
  </p>

  <h3>3. Configurar <code>appsettings.json</code></h3>
  <pre>
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=SupportAssistantDB;Trusted_Connection=True;"
  },
  "Jwt": {
    "Key": "CLAVE_SECRETA",
    "Issuer": "SupportAssistantAPI",
    "Audience": "SupportAssistantAPIUsers"
  },
  "OpenAI": {
    "ApiKey": "TU_API_KEY"
  }
}
  </pre>

  <h3>4. Ejecutar la aplicación</h3>
  <pre>
dotnet run
  </pre>

  <p>
    La API quedará disponible y podrás acceder a Swagger en:
  </p>
  <pre>
http://localhost:PUERTO/swagger
  </pre>
</div>

<div class="section">
  <h2>🧪 Pruebas</h2>
  <ul>
    <li>Registro y login desde Swagger</li>
    <li>Autorización con JWT</li>
    <li>Chat protegido</li>
    <li>Gestión de tickets por rol</li>
  </ul>
</div>

<div class="section">
  <h2>📌 Notas finales</h2>
  <p>
    Este proyecto fue desarrollado con enfoque en buenas prácticas,
    claridad de código y escalabilidad. Está pensado como una base sólida
    para un sistema real de soporte técnico o como demostración de
    habilidades backend en un entorno profesional.
  </p>
</div>

<hr>

<p>
<strong>Autor:</strong> Anthony Sibaja  
<br>
Ingeniero en Sistemas – Desarrollador Full Stack
</p>

</body>
</html>
