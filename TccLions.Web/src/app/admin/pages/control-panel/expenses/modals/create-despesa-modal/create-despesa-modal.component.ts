import { Component, Inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogModule } from '@angular/material/dialog';
import { provideTranslocoScope, TranslocoModule } from '@jsverse/transloco';

@Component({
  selector: 'app-create-despesa-modal',
  standalone: true,
  imports: [MatDialogModule, MatButtonModule, TranslocoModule],
  providers: [provideTranslocoScope({ scope: 'control-panel/expenses/create-modal', alias: 'modal' })],
  templateUrl: './create-despesa-modal.component.html'
})
export class CreateDespesaModalComponent {
  nomeDoMembro: string = ''

  constructor(@Inject(MAT_DIALOG_DATA) public data: string) {
    this.nomeDoMembro = data
  }
}
