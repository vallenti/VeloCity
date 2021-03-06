const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:26710';

const PROXY_CONFIG = [
  {
    context: [
      "/api/stations",
      "/api/stations/available",
      "/api/bikes",
      "/api/bikes/service",
      "/api/bikes/available",
      "/api/bikes/statuses",
      "/api/bikes/types",
      "/api/trips",
      "/api/trips/start",
      "/api/trips/end",
      "/api/trips/current",
      "/_configuration",
      "/.well-known",
      "/Identity",
      "/connect",
      "/ApplyDatabaseMigrations",
      "/_framework"
   ],
    target: target,
    secure: false,
    headers: {
      Connection: 'Keep-Alive'
    }
  }
]

module.exports = PROXY_CONFIG;
