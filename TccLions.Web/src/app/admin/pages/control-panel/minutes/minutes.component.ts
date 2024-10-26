import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatMenuModule } from '@angular/material/menu';
import { MatTableModule } from '@angular/material/table';
import { TranslocoModule, provideTranslocoScope } from '@jsverse/transloco';
import { CreateCommissionModalComponent } from '../commissions/modals/create-commission-modal/create-commission-modal.component';
import { DeleteComissaoModalComponent } from '../commissions/modals/delete-commission-modal/delete-comissao-modal.component';
import { EditCommissionModalComponent } from '../commissions/modals/edit-commission-modal/edit-commission-modal.component';
import { Minute } from './minutes.models';
import { MinutesService } from './service/minutes.service';
import { CreateMinuteComponent } from './modals/create-minute/create-minute.component';

@Component({
  selector: 'app-minutes',
  standalone: true,
  imports: [TranslocoModule, MatInputModule, MatTableModule, MatMenuModule, MatIconModule, MatDialogModule, MatButtonModule],
  providers: [provideTranslocoScope({ scope: 'control-panel/minutes', alias: 'minutes' })],
  templateUrl: './minutes.component.html'
})
export class MinutesComponent {
  minutes: Minute[] = [];
  displayedColumns = ['titulo', 'escritaEm', 'acoes'];

  constructor(private _service: MinutesService, private _dialog: MatDialog) { }

  ngOnInit(): void {
    this._service.minutes$.subscribe(minutes => this.minutes = minutes);
  }

  // search(value: string): void {
  //   this.filters.memberName.next(value);
  // }

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
    this._dialog.open(CreateMinuteComponent, {
      width: '400px'
    })
  }

  openEditModal(commissionTypeDescription: string) {
    this._dialog.open(EditCommissionModalComponent, {
      width: '400px',
      data: {
        // commissionTypeId: this.commissionTypes.find(commissionType => commissionType.descricao === commissionTypeDescription)!.id
      }
    })
  }
}
