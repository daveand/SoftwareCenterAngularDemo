// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  authConfig: {
    instance: 'https://login.microsoftonline.com/',
    tenant: 'anderssonttmgmail.onmicrosoft.com',
    tenentId: 'a7d34208-7be2-41a2-b004-0ee049a34d7b',
    clientId: 'f78a181a-81ea-4f56-993a-743e3814ed2a'
  },
  fileTypes: ['None', 'Backup', 'Issue', 'Knowledge', 'Documentation']
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
