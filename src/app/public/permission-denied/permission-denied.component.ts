import { Component } from '@angular/core';
import { provideTranslocoScope, TranslocoModule } from '@jsverse/transloco';

@Component({
  selector: 'app-permission-denied',
  standalone: true,
  imports: [TranslocoModule],
  providers: [
    provideTranslocoScope({ scope: 'permission-denied', alias: 'permissionDenied' })
  ],
  templateUrl: './permission-denied.component.html'
})
export class PermissionDeniedComponent {

}
