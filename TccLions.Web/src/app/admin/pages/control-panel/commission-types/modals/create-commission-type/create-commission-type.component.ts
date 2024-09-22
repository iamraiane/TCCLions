import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { provideTranslocoScope, TranslocoModule } from '@jsverse/transloco';
import { CreateCommissionType } from '../../commission-types.models';
import { CommissionTypesService } from '../../commission-types.service';

@Component({
  selector: 'app-create-commission-type',
  standalone: true,
  imports: [MatDialogModule, MatButtonModule, MatSelectModule, CommonModule, MatIconModule, TranslocoModule, FormsModule, ReactiveFormsModule, MatFormFieldModule, MatInputModule],
  providers: [
    provideTranslocoScope({ scope: 'control-panel/commission-types/create-commission-type', alias: 'createCommissionType' }),
  ],
  templateUrl: './create-commission-type.component.html'
})
export class CreateCommissionTypeComponent {
  readonly commissionTypeForm: FormGroup = new FormGroup({
    description: new FormControl<string>('', [Validators.required, Validators.maxLength(255)]),
  })

  constructor(private dialogRef: MatDialogRef<CreateCommissionTypeComponent>, private _service: CommissionTypesService) { }

  submit() {
    if (this.commissionTypeForm.invalid) return

    const commissionType: CreateCommissionType = {
      descricao: this.commissionTypeForm.get('description')?.value ?? ''
    }

    this._service.create(commissionType).subscribe(() => {
      this.dialogRef.close();
    });
  }
}
