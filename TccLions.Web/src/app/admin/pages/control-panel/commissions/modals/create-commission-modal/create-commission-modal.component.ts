import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { provideTranslocoScope, TranslocoModule } from '@jsverse/transloco';
import { MembersService } from '../../../members/service/members.service';
import { Member } from '../../../members/members.models';
import { MatSelectModule } from '@angular/material/select';
import { CommissionTypesService } from '../../../commission-types/commission-types.service';
import { TipoComissao } from '../../../commission-types/commission-types.models';
import { CreateCommission } from '../../comissions.models';
import { ComissionsService } from '../../service/comissions.service';

@Component({
  selector: 'app-create-commission-modal',
  standalone: true,
  imports: [MatDialogModule, MatButtonModule, TranslocoModule, ReactiveFormsModule, FormsModule, CommonModule, MatSelectModule],
  providers: [
    provideTranslocoScope({ scope: 'control-panel/comissions/create-modal', alias: 'createCommission' })
  ],
  templateUrl: './create-commission-modal.component.html'
})
export class CreateCommissionModalComponent implements OnInit {
  members: Member[] = [];
  commissionTypes: TipoComissao[] = [];
  commissionForm: FormGroup = new FormGroup({
    memberId: new FormControl<string>('', [Validators.required]),
    commissionTypeId: new FormControl<string>('', [Validators.required]),
  });

  constructor(public memberService: MembersService, public commissionTypeService: CommissionTypesService, public commissionService: ComissionsService, public dialogRef: MatDialogRef<CreateCommissionModalComponent>) {
    this.memberService.get('', false, 1000000, 0).subscribe();
    this.commissionTypeService.getAll().subscribe();
  }

  ngOnInit(): void {
    this.memberService.members$.subscribe(members => this.members = members);
    this.commissionTypeService.commissionTypes$.subscribe(commissionTypes => this.commissionTypes = commissionTypes);
  }

  create() {
    if (this.commissionForm.invalid) return;

    let createCommissionInfo: CreateCommission = {
      membroId: this.commissionForm.get('memberId')!.value,
      tipoComissaoId: this.commissionForm.get('commissionTypeId')!.value
    }

    this.commissionService.create(createCommissionInfo).subscribe({
      next: () => {
        this.dialogRef.close();
      }
    });
  }
}
