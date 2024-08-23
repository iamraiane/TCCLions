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
import { DeleteComissaoModalComponent } from './modals/delete-comissao-modal/delete-comissao-modal.component';
@Component({
  selector: 'app-comissions',
  standalone: true,
  imports: [TranslocoModule, MatInputModule, MatTableModule, MatMenuModule, MatIconModule, MatDialogModule],
  providers: [provideTranslocoScope({ scope: 'control-panel/comissions', alias: 'comissions' })],
  templateUrl: './comissions.component.html',
  styleUrl: './comissions.component.css'
})
export class ComissionsComponent implements OnInit {
  comissions: Comission[] = [];
  displayedColumns = ['membro', 'tipoComissao', 'actions'];
  filters = {
    memberName: new BehaviorSubject<string>('')
  }

  constructor(private _service: ComissionsService, private _dialog: MatDialog) { }

  ngOnInit(): void {
    this._service.comissions$.subscribe(comissions => this.comissions = comissions);

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
}
