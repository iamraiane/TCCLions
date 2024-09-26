import { Component, Inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogModule } from '@angular/material/dialog';
import { provideTranslocoScope, TranslocoModule } from '@jsverse/transloco';

@Component({
  selector: 'app-delete-comissao-modal',
  standalone: true,
  imports: [MatDialogModule, MatButtonModule, TranslocoModule],
  providers: [
    provideTranslocoScope({ scope: 'control-panel/comissions/delete-modal', alias: 'delete-modal' })
  ],
  templateUrl: './delete-comissao-modal.component.html',
  styleUrl: './delete-comissao-modal.component.css'
})
export class DeleteComissaoModalComponent {
  nomeDoMembro: string = ''

  constructor(@Inject(MAT_DIALOG_DATA) public data: string) {
    this.nomeDoMembro = data
  }
}
