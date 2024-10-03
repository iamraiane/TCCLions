import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatMenuModule } from '@angular/material/menu';
import { MatTableModule } from '@angular/material/table';
import { provideTranslocoScope, TranslocoModule } from '@jsverse/transloco';
import { BehaviorSubject } from 'rxjs';
import { ExpensesService } from './service/expenses.service';
import { Expense } from './despesas.models';

@Component({
  selector: 'app-expenses',
  standalone: true,
  imports: [TranslocoModule, MatInputModule, MatTableModule, MatMenuModule, MatIconModule, MatDialogModule],
  providers: [provideTranslocoScope({ scope: 'control-painel/expenses', alias: 'expenses'})],
  templateUrl: './expenses.component.html',
  styleUrl: './expenses.component.css'
})
export class ExpensesComponent implements OnInit{
  expenses: Expense[] =[];
  displayedColumns= ['membro', 'tipoDespesa', 'actions'];
  filters = {
    memberName: new BehaviorSubject<string>('')
  }

  constructor(private _service: ExpensesService, private _dialog: MatDialog) {}
  
  ngOnInit(): void {
    this._service.expenses$.subscribe(expenses => this.expenses = expenses);

    this.filters.memberName.subscribe(memberName => {
      this._service.get(memberName).subscribe();
    })
  }

  search(value: string) : void {
    this.filters.memberName.next(value);
  }
  
  openDeleteModal(id: string, memberName: stirng){
    let result : this._dialog.open(DeleteDespesaModalComponent, {
      data: memberName
    })

    result.afterClosed().subscribe(result => {
      if (!result) return
      
      this._service.delete(id).subscribe()
    })
  }
}
