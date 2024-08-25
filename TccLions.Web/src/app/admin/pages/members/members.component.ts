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
import { MatPaginatorModule } from '@angular/material/paginator';
import { CommonModule } from '@angular/common';
import { EditMemberComponent } from './modals/edit-member/edit-member.component';

@Component({
  selector: 'app-members',
  standalone: true,
  imports: [MatInputModule, CommonModule, MatPaginatorModule, FormsModule, MatSlideToggleModule, ReactiveFormsModule, TranslocoModule, MatButtonModule, MatIconModule, MatMenuModule, MatTableModule],
  templateUrl: './members.component.html',
  providers: [
    provideTranslocoScope({ scope: 'control-panel/members', alias: 'member' }),
  ]
})
export class MembersComponent implements OnInit {
  members: Member[] = []
  pagination: { count: number, pageIndex: number, pageSize: number } = { count: 0, pageIndex: 0, pageSize: 0 }
  displayedColumns: string[] = ['name', 'email', 'actions'];
  filters: {
    search: BehaviorSubject<string>,
    showDisabled: BehaviorSubject<boolean>,
    pageIndex: BehaviorSubject<number>,
    pageSize: BehaviorSubject<number>
  } = {
      search: new BehaviorSubject(''),
      showDisabled: new BehaviorSubject(false),
      pageIndex: new BehaviorSubject(0),
      pageSize: new BehaviorSubject(50)
    }

  constructor(private _service: MembersService, private _dialog: MatDialog) { }

  ngOnInit(): void {
    combineLatest([this.filters.search, this.filters.showDisabled, this.filters.pageIndex, this.filters.pageSize]).subscribe(([search, showDisabled, pageIndex, pageSize]) => {
      this._service.get(search, showDisabled, pageSize, pageIndex).subscribe();
    })

    this._service.members$.subscribe((members: Member[]) => {
      this.members = members;
    })

    this._service.pagination$.subscribe((pagination: { count: number, pageIndex: number, pageSize: number }) => {
      this.pagination = pagination;
    })
  }

  search(value: string) {
    this.filters.search.next(value.trim());
  }

  toggleDisabled(value: boolean) {
    this.filters.showDisabled.next(!value);
  }

  openCreateModal() {
    let dialog = this._dialog.open(CreateMemberComponent)

    dialog.afterClosed().subscribe((member) => {
      this._service.create(member).subscribe({
        next: () => {
          this._service.get(this.filters.search.value, this.filters.showDisabled.value, this.filters.pageSize.value, this.filters.pageIndex.value).subscribe();
        }
      });
    })
  }

  openEditModal(id: string) {
    let dialog = this._dialog.open(EditMemberComponent, {
      data: { id: id }
    })

    dialog.afterClosed().subscribe((member) => {
      if (member === 'deleted') {
        this._service.get(this.filters.search.value, this.filters.showDisabled.value, this.filters.pageSize.value, this.filters.pageIndex.value).subscribe();
        return;
      }

      this._service.update(id, member).subscribe({
        next: () => {
          this._service.get(this.filters.search.value, this.filters.showDisabled.value, this.filters.pageSize.value, this.filters.pageIndex.value).subscribe();
        }
      });
    })
  }

  pageChanged(event: any) {
    this.filters.pageIndex.next(event.pageIndex);
    this.filters.pageSize.next(event.pageSize);
  }

  disable(id: string) {
    this._service.disable(id).subscribe({
      next: () => {
        this._service.get(this.filters.search.value, this.filters.showDisabled.value, this.filters.pageSize.value, this.filters.pageIndex.value).subscribe();
      }
    });
  }

  enable(id: string) {
    this._service.enable(id).subscribe({
      next: () => {
        this._service.get(this.filters.search.value, this.filters.showDisabled.value, this.filters.pageSize.value, this.filters.pageIndex.value).subscribe();
      }
    });
  }
}
