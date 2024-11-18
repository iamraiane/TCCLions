import { Component, OnInit } from '@angular/core';
import { provideTranslocoScope, TranslocoModule } from '@jsverse/transloco';
import { MatInputModule } from '@angular/material/input';
import { ComissionsService } from './service/comissions.service';
import { MatTableModule } from '@angular/material/table';
import { BehaviorSubject } from 'rxjs';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { Comission } from './comissions.models';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { DeleteComissaoModalComponent } from './modals/delete-commission-modal/delete-comissao-modal.component';
import { CreateCommissionModalComponent } from './modals/create-commission-modal/create-commission-modal.component';
import { EditCommissionModalComponent } from './modals/edit-commission-modal/edit-commission-modal.component';
import { CommissionTypesService } from '../commission-types/commission-types.service';
import { TipoComissao } from '../commission-types/commission-types.models';
@Component({
  selector: 'app-comissions',
  standalone: true,
  imports: [TranslocoModule, MatInputModule, MatTableModule, MatMenuModule, MatIconModule, MatDialogModule, MatButtonModule],
  providers: [provideTranslocoScope({ scope: 'control-panel/comissions', alias: 'comissions' })],
  templateUrl: './comissions.component.html'
})
export class ComissionsComponent implements OnInit {
  comissions: Comission[] = [];
  displayedColumns = ['membro', 'tipoComissao', 'actions'];
  filters = {
    memberName: new BehaviorSubject<string>('')
  }
  commissionTypes: TipoComissao[] = [];

  constructor(private _service: ComissionsService, private _dialog: MatDialog, public commissionTypeService: CommissionTypesService) { }

  ngOnInit(): void {
    this._service.comissions$.subscribe(comissions => this.comissions = comissions);
    this.commissionTypeService.getAll().subscribe();
    this.commissionTypeService.commissionTypes$.subscribe(commissionTypes => this.commissionTypes = commissionTypes);

    this.filters.memberName.subscribe(memberName => {
      this._service.get(memberName).subscribe();
    })
  }

  search(value: string): void {
    this.filters.memberName.next(value);
  }

  openDeleteModal(id: string, memberName: string) {
    let result = this._dialog.open(DeleteComissaoModalComponent, {
      data: memberName
    })

    result.afterClosed().subscribe(result => {
      if (!result) return

      this._service.delete(id).subscribe()
    })
  }

  openCreateModal() {
    this._dialog.open(CreateCommissionModalComponent, {
      width: '400px'
    })
  }

  openEditModal(commissionTypeDescription: string, id: string) {
    this._dialog.open(EditCommissionModalComponent, {
      width: '400px',
      data: {
        commissionTypeId: this.commissionTypes.find(commissionType => commissionType.descricao === commissionTypeDescription)!.id,
        commissionId: id
      }
    })
  }
}
