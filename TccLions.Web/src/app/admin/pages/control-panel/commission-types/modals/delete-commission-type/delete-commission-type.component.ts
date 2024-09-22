import { Component, Inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { CommissionTypesService } from '../../commission-types.service';
import { provideTranslocoScope, TranslocoModule } from '@jsverse/transloco';

@Component({
  selector: 'app-delete-commission-type',
  standalone: true,
  imports: [MatDialogModule, MatButtonModule, TranslocoModule],
  providers: [
    provideTranslocoScope({ scope: 'control-panel/commission-types/delete-commission-type', alias: 'deleteCommissionType' }),
  ],
  templateUrl: './delete-commission-type.component.html'
})

export class DeleteCommissionTypeComponent {
  constructor(@Inject(MAT_DIALOG_DATA) public data: { id: string, description: string }, public service: CommissionTypesService, public dialogRef: MatDialogRef<DeleteCommissionTypeComponent>) { }

  public get description(): string {
    return this.data.description;
  }

  public delete() {
    this.service.delete(this.data.id).subscribe(() => {
      this.dialogRef.close(true);
    });
  }
}
