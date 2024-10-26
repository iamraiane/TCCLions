import { Component, Inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogModule } from '@angular/material/dialog';
import { provideTranslocoScope, TranslocoModule } from '@jsverse/transloco';

@Component({
  selector: 'app-delete-minute-modal',
  standalone: true,
  imports: [MatDialogModule, MatButtonModule, TranslocoModule],
  providers: [
    provideTranslocoScope({ scope: 'control-panel/minutes/modals/delete-minute', alias: 'delete-minute' })
  ],
  templateUrl: './delete-minute-modal.component.html'
})
export class DeleteMinuteModalComponent {
  nomeDaAta: string;

  constructor(@Inject(MAT_DIALOG_DATA) public data: string) {
    this.nomeDaAta = data;
  }
}
