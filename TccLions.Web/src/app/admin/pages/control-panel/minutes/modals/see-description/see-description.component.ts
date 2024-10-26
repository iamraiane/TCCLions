import { Component, Inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogModule } from '@angular/material/dialog';
import { provideTranslocoScope, TranslocoModule } from '@jsverse/transloco';

@Component({
  selector: 'app-see-description',
  standalone: true,
  imports: [MatDialogModule, TranslocoModule, MatButtonModule],
  providers: [
    provideTranslocoScope({ scope: 'control-panel/minutes/modals/see-description', alias: 'see-minute-description' })
  ],
  templateUrl: './see-description.component.html'
})
export class SeeDescriptionComponent {
  description: string;

  constructor(@Inject(MAT_DIALOG_DATA) public data: string) {
    this.description = data;
  }
}
