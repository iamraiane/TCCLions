import { Component, inject, OnInit } from '@angular/core';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatMenuModule } from '@angular/material/menu';
import { MatTableModule } from '@angular/material/table';
import { TranslocoModule, provideTranslocoScope } from '@jsverse/transloco';
import { TipoComissao } from './commission-types.models';
import { CommissionTypesService } from './commission-types.service';
import { MatButtonModule } from '@angular/material/button';
import { CreateCommissionTypeComponent } from './modals/create-commission-type/create-commission-type.component';
import { DeleteCommissionTypeComponent } from './modals/delete-commission-type/delete-commission-type.component';
import { EditCommissionTypeComponent } from './modals/edit-commission-type/edit-commission-type.component';

@Component({
  selector: 'app-commission-types',
  standalone: true,
  imports: [TranslocoModule, MatInputModule, MatTableModule, MatMenuModule, MatIconModule, MatDialogModule, MatButtonModule],
  providers: [provideTranslocoScope({ scope: 'control-panel/commission-types', alias: 'commissionTypes' })],
  templateUrl: './commission-types.component.html'
})
export class CommissionTypesComponent implements OnInit {
  private readonly _service = inject(CommissionTypesService);
  private readonly _dialog = inject(MatDialog);
  public displayedColumns = ['descricao', 'actions'];
  public commissionTypes: TipoComissao[] = [];

  ngOnInit(): void {
    this._service.commissionTypes$.subscribe(response => this.commissionTypes = response);
  }

  public search(description: string) {
    if (description.trim() === '') {
      this._service.commissionTypes$.subscribe(response => this.commissionTypes = response);
    } else {
      this._service.commissionTypes$.subscribe(response => {
        this.commissionTypes = response.filter(commissionType =>
          commissionType.descricao.toLowerCase().includes(description.toLowerCase())
        );
      });
    }
  }

  public openDeleteModal(id: string, description: string) {
    this._dialog.open(DeleteCommissionTypeComponent, {
      data: {
        id,
        description
      },
      width: '300px'
    })
  }

  public openCreateModal() {
    this._dialog.open(CreateCommissionTypeComponent);
  }

  public openEditModal(id: string, description: string) {
    this._dialog.open(EditCommissionTypeComponent, {
      data: {
        id,
        description
      }
    })
  }
}
