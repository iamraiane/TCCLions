import { Component, inject, OnInit } from '@angular/core';
import { ExpensesService } from '../../admin/pages/control-panel/expenses/service/expenses.service';
import { MemberExpenses } from '../../admin/pages/control-panel/expenses/expenses.models';
import { provideTranslocoScope, TranslocoModule } from '@jsverse/transloco';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [TranslocoModule],
  providers: [
    provideTranslocoScope({ scope: "home", alias: "home" })
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  private despesaService = inject(ExpensesService)
  ultimasDespesasCadastradas: MemberExpenses[] = []

  constructor(private router: Router) {

  }

  ngOnInit(): void {
    this.despesaService.get().subscribe({
      error: (err) => {
        if (err.status === 401) {
          this.router.navigate(['/login']);
        }
      }
    });

    this.despesaService.expenses$.subscribe((data) => {
      const todasDespesas: MemberExpenses[] = data.flatMap(expense => expense.despesas);

      this.ultimasDespesasCadastradas = todasDespesas
        .sort((a, b) => {
          const dateA = new Date(a.dataRegistro).getTime();
          const dateB = new Date(b.dataRegistro).getTime();
          return dateB - dateA;
        })
        .slice(0, 5);
    })
  }
}
