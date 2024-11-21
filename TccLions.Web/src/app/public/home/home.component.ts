import { Component, inject, OnInit } from '@angular/core';
import { ExpensesService } from '../../admin/pages/control-panel/expenses/service/expenses.service';
import { MemberExpenses } from '../../admin/pages/control-panel/expenses/expenses.models';
import { provideTranslocoScope, TranslocoModule } from '@jsverse/transloco';
import { Router, RouterLink } from '@angular/router';
import { MembersService } from '../../admin/pages/control-panel/members/service/members.service';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [TranslocoModule, RouterLink, MatIconModule, MatButtonModule, MatTableModule],
  providers: [
    provideTranslocoScope({ scope: "home", alias: "home" })
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  private despesaService = inject(ExpensesService)
  membersCount: number = 0;
  ultimasDespesasCadastradas: MemberExpenses[] = []
  expenses: MemberExpenses[] = []

  constructor(private router: Router, private memberService: MembersService) {

  }

  ngOnInit(): void {
    this.despesaService.get().subscribe({
      error: (err) => {
        if (err.status === 401) {
          this.router.navigate(['/login']);
        }
      }
    });

    this.memberService.get('', false, 1000000, 0).subscribe({
      next: (data) => {
        this.membersCount = data.dados.length;
      }
    })

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
