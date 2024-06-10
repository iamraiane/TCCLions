import { Routes } from '@angular/router';
import { LoginComponent } from "./admin/public/login/login.component";
import { RegisterComponent } from "./admin/public/register/register.component";
import { AdminPageComponent } from './admin/admin-page/admin-page.component';
import { EventsComponent } from './admin/public/events/events.component';
import { HelpComponent } from './admin/public/help/help.component';
import { AboutComponent } from './admin/public/about/about.component';

export const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'register',
    component: RegisterComponent
  },
  {
    path: 'admin',
    component: AdminPageComponent
  },
  {
    path: 'events',
    component: EventsComponent
  },
  {
    path: 'help',
    component: HelpComponent
  },
  {
    path: 'about',
    component: AboutComponent
  },
];
