import { inject } from '@angular/core';
import { AuthService } from './auth.service';
import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { catchError, throwError } from 'rxjs';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const authService = inject(AuthService);
  const authToken = authService.getToken();
  const router = inject(Router);
  const snackBar = inject(MatSnackBar);

  if (authToken && authService.isTokenExpired()) {
    authService.logout();
    router.navigate(['/login']);
    snackBar.open('Sessão expirada, faça login novamente', undefined, {
      duration: 2000
    });
  }

  if (authToken && !authService.isTokenExpired()) {
    req = req.clone({
      setHeaders: {
        Authorization: `Bearer ${authToken}`
      }
    });
  }

  return next(req).pipe(
    catchError((err: any) => {
      if (err instanceof HttpErrorResponse) {
        if (err.status === 401) {
          console.error('Unauthorized request:', err);
        } if (err.status === 403) {
          console.error('Forbidden request:', err);
        }
      } else {
        console.error('An error occurred:', err);
      }

      return throwError(() => err);
    })
  );
};
