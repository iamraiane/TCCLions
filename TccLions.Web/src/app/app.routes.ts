import { Routes } from '@angular/router';
import { ComissionsComponent } from './admin/pages/comissions/comissions.component';
import { ComissionsService } from './admin/pages/comissions/service/comissions.service';
import { inject } from '@angular/core';
import { MembersComponent } from './admin/pages/members/members.component';
import { MembersService } from './admin/pages/members/service/members.service';

export const routes: Routes = [
  {
    path: 'control-panel/members',
    component: MembersComponent,
    resolve: {
      members: () => inject(MembersService).get('', false, 50, 0)
    }
  },
  {
    path: 'control-panel/comissions',
    component: ComissionsComponent,
    resolve: {
      comissions: () => inject(ComissionsService).get('')
    }
  }
];
