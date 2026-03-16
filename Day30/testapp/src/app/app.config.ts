import { ApplicationConfig, provideBrowserGlobalErrorListeners } from '@angular/core';
import { provideRouter } from '@angular/router';
import { HttpTestingController } from '@angular/common/http/testing';
import { routes } from './app.routes';
import { provideHttpClientTesting } from '@angular/common/http/testing';
import { Apiservice } from './apiservice';

export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideRouter(routes),
    provideHttpClientTesting(),
    Apiservice
  ]
};
