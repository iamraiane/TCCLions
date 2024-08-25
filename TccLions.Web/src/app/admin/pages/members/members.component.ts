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
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { BehaviorSubject, combineLatest } from 'rxjs';

@Component({
  selector: 'app-members',
  standalone: true,
  imports: [MatInputModule, FormsModule, MatSlideToggleModule, ReactiveFormsModule, TranslocoModule, MatButtonModule, MatIconModule, MatMenuModule, MatTableModule],
  templateUrl: './members.component.html',
  providers: [
    provideTranslocoScope({ scope: 'control-panel/members', alias: 'member' }),
  ]
})
export class MembersComponent implements OnInit {
  members: Member[] = []
  displayedColumns: string[] = ['name', 'email', 'actions'];
  filters: {
    search: BehaviorSubject<string>,
    showDisabled: BehaviorSubject<boolean>
  } = {
      search: new BehaviorSubject(''),
      showDisabled: new BehaviorSubject(false)
    }

  constructor(private _service: MembersService, private _dialog: MatDialog) { }

  ngOnInit(): void {
    combineLatest([this.filters.search, this.filters.showDisabled]).subscribe(([search, showDisabled]) => {
      this._service.get(search, showDisabled).subscribe();
    })

    this._service.members$.subscribe((members: Member[]) => {
      this.members = members;
    })
  }

  search(value: string) {
    this.filters.search.next(value.trim());
  }

  toggleDisabled(value: boolean) {
    this.filters.showDisabled.next(!value);
  }

  openCreateModal() {
    this._dialog.open(CreateMemberComponent)
  }
}
