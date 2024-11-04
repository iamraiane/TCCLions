import { CommonModule } from '@angular/common';
import { Component, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { provideTranslocoScope, TranslocoModule } from '@jsverse/transloco';
import { ExpenseTypesService } from '../../service/expense-types.service';
import { CreateTipoDespesa } from '../../expense-types.modals';

@Component({
  selector: 'app-edit-expense-type',
  standalone: true,
  imports: [MatDialogModule, MatButtonModule, MatInputModule, FormsModule, ReactiveFormsModule, CommonModule, TranslocoModule],
  providers: [
    provideTranslocoScope({ scope: 'control-panel/expense-types/modals/edit-expense-type', alias: 'editExpenseType' }),
  ],
  templateUrl: './edit-expense-type.component.html'
})
export class EditExpenseTypeComponent {
  readonly expenseTypeForm: FormGroup = new FormGroup({
    description: new FormControl<string>('', [Validators.required, Validators.maxLength(255)]),
  })

  constructor(@Inject(MAT_DIALOG_DATA) public data: { id: string, description: string }, public service: ExpenseTypesService, public dialogRef: MatDialogRef<EditExpenseTypeComponent>) {
    this.expenseTypeForm.get('description')?.setValue(data.description);
  }

  public edit() {
    if (this.expenseTypeForm.invalid) return

    const expenseType: CreateTipoDespesa = {
      descricao: this.expenseTypeForm.get('description')?.value ?? ''
    }

    this.service.edit(this.data.id, expenseType).subscribe(() => {
      this.dialogRef.close();
    });
  }
}
