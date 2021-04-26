// For more settings: https://github.com/chimurai/http-proxy-middleware
// Config to route local development API and all other environment apis
const PROXY_CONFIG = [
  {
    context: '/api',
    target: 'http://localhost:5000',
    secure: false,
  },
];

module.exports = PROXY_CONFIG;
