import { Routes } from '@angular/router';
import { LoginComponent } from './public/login/login.component';
import { AuthGuard } from './core/auth/auth.guard';
import { throwError } from 'rxjs';
import { ApplicationConstants } from './core/settings/application-constants';
import { PermissionDeniedComponent } from './public/permission-denied/permission-denied.component';

export const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: 'login',
        resolve: {
          isLogged: () => {
            if (localStorage.getItem('token')) {
              return throwError(() => new Error('Usuário já logado'));
            }

            return true;
          }
        },
        component: LoginComponent
      },
      {
        path: 'permission-denied',
        component: PermissionDeniedComponent
      }
    ]
  },

  {
    path: '',
    canActivate: [AuthGuard],
    canActivateChild: [AuthGuard],
    children: [
      {
        path: 'control-panel',
        data: {
          permissions: [ApplicationConstants.permissions.Admin]
        },
        loadChildren: () => import('./admin/pages/control-panel/control-panel.routes').then(m => m.routes)
      }
    ]
  }
];
