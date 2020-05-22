export const environment = {
  production: true,
  application: {
    name: 'BookStore',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'http://localhost:35781',
    clientId: 'BookStore_App',
    dummyClientSecret: '1q2w3e*',
    scope: 'BookStore',
    showDebugInformation: true,
    oidc: true,
    requireHttps: false,
  },
  apis: {
    default: {
      url: 'http://localhost:35781',
    },
  },
  localization: {
    defaultResourceName: 'BookStore',
  },
};
