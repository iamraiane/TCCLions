import { Component, inject, OnInit } from '@angular/core';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatInput, MatInputModule } from '@angular/material/input';
import { MatMenuModule } from '@angular/material/menu';
import { MatTableModule } from '@angular/material/table';
import { provideTranslocoScope, TranslocoModule } from '@jsverse/transloco';

@Component({
  selector: 'app-expenses-type',
  standalone: true,
  imports: [TranslocoModule, MatInputModule, MatTableModule, MatMenuModule, MatIconModule, MatDialogModule],
  providers: [provideTranslocoScope({scope: 'control-panel/expenses-types', alias: 'expenseTypes'})],
  templateUrl: './expenses-type.component.html',
})
export class ExpensesTypeComponent implements OnInit{
  private readonly _service = inject(ExpenseTypesService);

  public displayedColumns = ['expenseTypeId', 'descricao'];
  public expenseTypes: TipoDespensa[] = [];

  ngOnInit(): void {
    this._service.expensetype$.subscribe(response => this.expenseTypes = response);
  }

  public openDeleteModal(x: any, y: any){
    
  }
}
