import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { TranslocoModule } from '@jsverse/transloco';
import { ExpenseTypesService } from '../../service/expense-types.service';
import { CreateTipoDespesa } from '../../expense-types.modals';

@Component({
  selector: 'app-create-expense-type',
  standalone: true,
  imports: [MatDialogModule, MatButtonModule, MatSelectModule, CommonModule, MatIconModule, TranslocoModule, FormsModule, ReactiveFormsModule, MatFormFieldModule, MatInputModule],
  templateUrl: './create-expense-type.component.html'
})
export class CreateExpenseTypeComponent {
  readonly expenseTypeForm: FormGroup = new FormGroup({
    description: new FormControl<string>('', [Validators.required, Validators.maxLength(255)]),
  })

  constructor(private dialogRef: MatDialogRef<CreateExpenseTypeComponent>, private _service: ExpenseTypesService) { }

  submit() {
    if (this.expenseTypeForm.invalid) return

    const expenseType: CreateTipoDespesa = {
      descricao: this.expenseTypeForm.get('description')?.value ?? ''
    }

    this._service.create(expenseType).subscribe(() => {
      this.dialogRef.close();
    });
  }
}
