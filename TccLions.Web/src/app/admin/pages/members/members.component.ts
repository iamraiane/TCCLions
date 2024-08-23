import { Component, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatMenuModule } from '@angular/material/menu';
import { MatTableModule } from '@angular/material/table';
import { provideTranslocoScope, TranslocoModule } from '@jsverse/transloco';
import { Member } from './members.models';
import { MembersService } from './service/members.service';
import { MatDialog } from '@angular/material/dialog';
import { CreateMemberComponent } from './modals/create-member/create-member.component';

@Component({
  selector: 'app-members',
  standalone: true,
  imports: [MatInputModule, FormsModule, ReactiveFormsModule, TranslocoModule, MatButtonModule, MatIconModule, MatMenuModule, MatTableModule],
  templateUrl: './members.component.html',
  providers: [
    provideTranslocoScope({ scope: 'control-panel/members', alias: 'member' }),
  ]
})
export class MembersComponent implements OnInit {
  members: Member[] = []
  displayedColumns: string[] = ['name', 'email', 'actions'];

  constructor(private _service: MembersService, private _dialog: MatDialog) { }

  ngOnInit(): void {
    this._service.members$.subscribe((members: Member[]) => {
      this.members = members;
    })
  }

  search() {

  }

  openCreateModal() {
    this._dialog.open(CreateMemberComponent, {
      width: '100px',
      height: '100px'
    })
  }
}
