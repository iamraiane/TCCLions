import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatMenuModule } from '@angular/material/menu';
import { MatTableModule } from '@angular/material/table';
import { provideTranslocoScope, TranslocoModule } from '@jsverse/transloco';
import { ExpensesService } from './service/expenses.service';
import { Expense } from './expenses.models';
import { MatButtonModule } from '@angular/material/button';
import { SeeMemberExpensesModalComponent } from './modals/see-member-expenses-modal/see-member-expenses.component';
import { CreateDespesaModalComponent } from './modals/create-despesa-modal/create-despesa-modal.component';

@Component({
  selector: 'app-expenses',
  standalone: true,
  imports: [MatButtonModule, TranslocoModule, MatInputModule, MatTableModule, MatMenuModule, MatIconModule, MatDialogModule],
  providers: [provideTranslocoScope({ scope: 'control-panel/expenses', alias: 'expenses' })],
  templateUrl: './expenses.component.html'
})

export class ExpensesComponent implements OnInit {
  expenses: Expense[] = [];
  displayedColumns = ['membro', 'acoes'];

  constructor(private _service: ExpensesService, private _dialog: MatDialog) { }

  ngOnInit(): void {
    this._service.expenses$.subscribe(expenses => {
      this.expenses = expenses
    });
  }

  search(value: string): void {
  }

  openCreateModal() {
    this._dialog.open(CreateDespesaModalComponent)
  }

  seeExpenses(memberId: string) {
    let dialog = this._dialog.open(SeeMemberExpensesModalComponent, {
      data: {
        expenses: this.expenses.find(expense => expense.id === memberId)?.despesas,
        memberName: this.expenses.find(expense => expense.id === memberId)?.nome
      },
      width: '900px'
    })

    dialog.afterClosed().subscribe((id: string) => {
      if (id) {
        const despesas = this.expenses.findIndex(x => x.id == memberId);

        if (despesas !== -1) {
          const despesaIndex = this.expenses[despesas].despesas.findIndex(x => x.id == id);

          if (despesaIndex !== -1) {
            this.expenses[despesas].despesas.splice(despesaIndex, 1);
          }
        }
      }
    })
  }
}
