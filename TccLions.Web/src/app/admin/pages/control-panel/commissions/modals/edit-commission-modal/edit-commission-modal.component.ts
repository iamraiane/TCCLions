import { CommonModule } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { provideTranslocoScope, TranslocoModule } from '@jsverse/transloco';
import { MembersService } from '../../../members/service/members.service';
import { Member } from '../../../members/members.models';
import { MatSelectModule } from '@angular/material/select';
import { CommissionTypesService } from '../../../commission-types/commission-types.service';
import { TipoComissao } from '../../../commission-types/commission-types.models';
import { CreateCommission } from '../../comissions.models';
import { ComissionsService } from '../../service/comissions.service';

@Component({
  selector: 'app-edit-commission-modal',
  standalone: true,
  imports: [MatDialogModule, MatButtonModule, TranslocoModule, ReactiveFormsModule, FormsModule, CommonModule, MatSelectModule],
  providers: [
    provideTranslocoScope({ scope: 'control-panel/comissions/edit-modal', alias: 'editCommission' })
  ],
  templateUrl: './edit-commission-modal.component.html'
})
export class EditCommissionModalComponent implements OnInit {
  members: Member[] = [];
  commissionTypes: TipoComissao[] = [];
  commissionForm: FormGroup = new FormGroup({
    commissionTypeId: new FormControl<string>('', [Validators.required])
  });

  constructor(@Inject(MAT_DIALOG_DATA) public data: { commissionTypeId: string }, public memberService: MembersService, public commissionTypeService: CommissionTypesService, public commissionService: ComissionsService, public dialogRef: MatDialogRef<EditCommissionModalComponent>) {
    this.memberService.get('', false, 1000000, 0).subscribe();
    this.commissionTypeService.getAll().subscribe();
  }

  ngOnInit(): void {
    this.commissionForm.controls['commissionTypeId'].setValue(this.data.commissionTypeId);
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
