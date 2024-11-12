import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { provideTranslocoScope, TranslocoModule } from '@jsverse/transloco';
import { MembersService } from '../../../members/service/members.service';
import { Member } from '../../../members/members.models';
import { CommonModule } from '@angular/common';
import { ExpenseTypesService } from '../../../expense-types/service/expense-types.service';
import { TipoDespesa } from '../../../expense-types/expense-types.modals';
import { provideNativeDateAdapter } from '@angular/material/core';
import { ExpensesService } from '../../service/expenses.service';

@Component({
  selector: 'app-create-despesa-modal',
  standalone: true,
  imports: [MatDialogModule, CommonModule, MatButtonModule, TranslocoModule, MatInputModule, MatDatepickerModule, MatSelectModule, FormsModule, ReactiveFormsModule],
  providers: [provideTranslocoScope({ scope: 'control-panel/expenses/create-modal', alias: 'create-modal' }), provideNativeDateAdapter()],
  templateUrl: './create-despesa-modal.component.html'
})
export class CreateDespesaModalComponent implements OnInit {
  members: Member[] = [];
  expenseTypes: TipoDespesa[] = [];
  expenseForm: FormGroup = new FormGroup({
    valorTotal: new FormControl(null, [Validators.required]),
    membroId: new FormControl<string>('', [Validators.required]),
    dataVencimento: new FormControl('', [Validators.required]),
    dataRegistro: new FormControl('', [Validators.required]),
    tipoDeDespesaId: new FormControl('', [Validators.required]),
  })

  constructor(public memberService: MembersService, public expenseTypeService: ExpenseTypesService, public expenseService: ExpensesService, private dialogRef: MatDialogRef<CreateDespesaModalComponent>) {
    this.memberService.get('', false, 1000000, 0).subscribe();
    this.expenseTypeService.getAll().subscribe();
  }

  ngOnInit(): void {
    this.memberService.members$.subscribe(members => this.members = members);
    this.expenseTypeService.expenseTypes$.subscribe(expenseTypes => this.expenseTypes = expenseTypes);
  }

  save() {
    if (this.expenseForm.invalid) return;

    let dataRegistroValue: Date = this.expenseForm.get('dataRegistro')?.value;

    if (dataRegistroValue) {
      const dateWithoutTime = dataRegistroValue.toISOString().split('T')[0];
      this.expenseForm.get('dataRegistro')?.setValue(dateWithoutTime);
    }

    const dataVencimentoValue = this.expenseForm.get('dataVencimento')?.value;

    if (dataVencimentoValue) {
      const dueDateWithoutTime = dataVencimentoValue.toISOString().split('T')[0];
      this.expenseForm.get('dataVencimento')?.setValue(dueDateWithoutTime);
    }

    this.expenseService.create(this.expenseForm.value).subscribe({
      next: () => {
        this.dialogRef.close();
        this.expenseForm.reset();
      }
    });
  }
}
