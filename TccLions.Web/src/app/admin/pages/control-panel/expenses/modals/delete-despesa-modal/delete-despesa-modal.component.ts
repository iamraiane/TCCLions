import { Component, Inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogModule } from '@angular/material/dialog';
import { provideTranslocoScope, TranslocoModule } from '@jsverse/transloco';

@Component({
  selector: 'app-delete-despesa-modal',
  standalone: true,
  imports: [MatDialogModule, MatButtonModule, TranslocoModule],
  providers: [provideTranslocoScope({ scope: 'control-panel/expenses/delete-modal', alias: 'deelte-modal'})],
  templateUrl: './delete-despesa-modal.component.html',
  styleUrl: './delete-despesa-modal.component.css'
})
export class DeleteDespesaModalComponent {
  nomeDoMembro: string=''

  constructor(@Inject(MAT_DIALOG_DATA) public data: string){
    this.nomeDoMembro = data
  }
}
