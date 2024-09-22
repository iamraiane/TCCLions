import { CommonModule } from '@angular/common';
import { Component, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { provideTranslocoScope, TranslocoModule } from '@jsverse/transloco';
import { EditCommissionType } from '../../commission-types.models';
import { CommissionTypesService } from '../../commission-types.service';

@Component({
  selector: 'app-edit-commission-type',
  standalone: true,
  imports: [MatDialogModule, MatButtonModule, MatInputModule, FormsModule, ReactiveFormsModule, CommonModule, TranslocoModule],
  providers: [
    provideTranslocoScope({ scope: 'control-panel/commission-types/edit-commission-type', alias: 'editCommissionType' }),
  ],
  templateUrl: './edit-commission-type.component.html'
})
export class EditCommissionTypeComponent {
  readonly commissionTypeForm: FormGroup = new FormGroup({
    description: new FormControl<string>('', [Validators.required, Validators.maxLength(255)]),
  })

  constructor(@Inject(MAT_DIALOG_DATA) public data: { id: string, description: string }, public service: CommissionTypesService, public dialogRef: MatDialogRef<EditCommissionTypeComponent>) {
    this.commissionTypeForm.get('description')?.setValue(data.description);
  }

  public edit() {
    if (this.commissionTypeForm.invalid) return

    const commissionType: EditCommissionType = {
      descricao: this.commissionTypeForm.get('description')?.value ?? ''
    }

    this.service.edit(this.data.id, commissionType).subscribe(() => {
      this.dialogRef.close();
    });
  }
}
