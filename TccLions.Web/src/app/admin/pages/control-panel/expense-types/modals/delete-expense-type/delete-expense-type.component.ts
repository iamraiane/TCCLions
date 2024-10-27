import { Component, Inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { provideTranslocoScope, TranslocoModule } from '@jsverse/transloco';
import { ExpenseTypesService } from '../../service/expense-types.service';

@Component({
  selector: 'app-delete-expense-type',
  standalone: true,
  imports: [MatDialogModule, MatButtonModule, TranslocoModule],
  templateUrl: './delete-expense-type.component.html'
})

export class DeleteExpenseTypeComponent {
  constructor(@Inject(MAT_DIALOG_DATA)
  public data: { id: string, description: string },
  public service: ExpenseTypesService,
  public dialogRef: MatDialogRef<DeleteExpenseTypeComponent>) { }

  public get description(): string {
    return this.data.description;
  }

  public delete() {
    this.service.delete(this.data.id).subscribe(() => {
      this.dialogRef.close(true);
    });
  }
}
