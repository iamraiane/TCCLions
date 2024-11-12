import { Component, Inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { provideTranslocoScope, TranslocoModule } from '@jsverse/transloco';
import { MemberExpenses } from '../../expenses.models';
import { MatTableModule } from '@angular/material/table';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { ExpensesService } from '../../service/expenses.service';

@Component({
  selector: 'app-delete-despesa-modal',
  standalone: true,
  imports: [MatDialogModule, MatButtonModule, TranslocoModule, MatTableModule, MatMenuModule, MatIconModule],
  providers: [provideTranslocoScope({ scope: 'control-panel/expenses/see-member-expenses-modal', alias: 'modal' })],
  templateUrl: './see-member-expenses.component.html'
})
export class SeeMemberExpensesModalComponent {
  displayedColumns = ['registerDate', 'dueDate', 'value', 'expenseType', 'actions']
  memberName: string = ''
  expenses: MemberExpenses[] = []
  totalExpensesValue: number = 0;

  constructor(@Inject(MAT_DIALOG_DATA) public data: { expenses: MemberExpenses[], memberName: string }, private _service: ExpensesService, private _dialogRef: MatDialogRef<SeeMemberExpensesModalComponent>) {
    this.expenses = data.expenses
    this.memberName = data.memberName
    this.totalExpensesValue = data.expenses.reduce((acc, curr) => acc + curr.valorTotal, 0)
  }

  removeExpense(id: string) {
    this._service.delete(id).subscribe({
      next: () => {
        this._dialogRef.close(id);
      }
    })
  }
}
