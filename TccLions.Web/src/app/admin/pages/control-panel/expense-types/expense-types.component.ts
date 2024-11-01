import { Component, inject } from '@angular/core';
import { ExpenseTypesService } from './service/expense-types.service';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { TipoDespesa } from './expense-types.modals';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatMenuModule } from '@angular/material/menu';
import { MatTableModule } from '@angular/material/table';
import { provideTranslocoScope, TranslocoModule } from '@jsverse/transloco';
import { CreateExpenseTypeComponent } from './modals/create-expense-type/create-expense-type.component';
import { DeleteExpenseTypeComponent } from './modals/delete-expense-type/delete-expense-type.component';
import { EditExpenseTypeComponent } from './modals/edit-expense-type/edit-expense-type.component';

@Component({
  selector: 'app-expense-types',
  standalone: true,
  imports: [TranslocoModule, MatInputModule, MatTableModule, MatMenuModule, MatIconModule, MatDialogModule, MatButtonModule],
  providers: [
    provideTranslocoScope({ scope: 'control-panel/expense-types', alias: 'expense-types' })
  ],
  templateUrl: './expense-types.component.html'
})
export class ExpenseTypesComponent {
  private readonly _service = inject(ExpenseTypesService);
  private readonly _dialog = inject(MatDialog);
  public displayedColumns = ['descricao', 'actions'];
  public expenseTypes: TipoDespesa[] = [];

  ngOnInit(): void {
    this._service.expenseTypes$.subscribe(response => this.expenseTypes = response);
  }

  public search(description: string) {
    if (description.trim() === '') {
      this._service.expenseTypes$.subscribe(response => this.expenseTypes = response);
    } else {
      this._service.expenseTypes$.subscribe(response => {
        this.expenseTypes = response.filter(expenseType =>
          expenseType.descricao.toLowerCase().includes(description.toLowerCase())
        );
      });
    }
  }

  public openDeleteModal(id: string, description: string) {
    this._dialog.open(DeleteExpenseTypeComponent, {
      data: {
        id,
        description
      },
      width: '300px'
    })
  }

  public openCreateModal() {
    this._dialog.open(CreateExpenseTypeComponent);
  }

  public openEditModal(id: string, description: string) {
    this._dialog.open(EditExpenseTypeComponent, {
      data: {
        id,
        description
      }
    })
  }
}
