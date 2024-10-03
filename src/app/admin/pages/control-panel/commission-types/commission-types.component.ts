import { Component, inject, OnInit } from '@angular/core';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatMenuModule } from '@angular/material/menu';
import { MatTableModule } from '@angular/material/table';
import { TranslocoModule, provideTranslocoScope } from '@jsverse/transloco';
import { TipoComissao } from './commission-types.models';
import { CommissionTypesService } from './commission-types.service';

@Component({
  selector: 'app-commission-types',
  standalone: true,
  imports: [TranslocoModule, MatInputModule, MatTableModule, MatMenuModule, MatIconModule, MatDialogModule],
  providers: [provideTranslocoScope({ scope: 'control-panel/commission-types', alias: 'commissionTypes' })],
  templateUrl: './commission-types.component.html'
})
export class CommissionTypesComponent implements OnInit {
  private readonly _service = inject(CommissionTypesService);

  public displayedColumns = ['commissionTypeId', 'descricao'];
  public commissionTypes: TipoComissao[] = [];

  ngOnInit(): void {
    this._service.commissionTypes$.subscribe(response => this.commissionTypes = response);
  }

  public openDeleteModal(x: any, y: any) {

  }
}
