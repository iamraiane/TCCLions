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
import { CreateMember } from '../../members.models';
import { ApplicationConstants } from '../../../../../../core/settings/application-constants';

@Component({
  selector: 'app-create-member',
  standalone: true,
  imports: [MatDialogModule, MatButtonModule, MatSelectModule, CommonModule, MatIconModule, TranslocoModule, FormsModule, ReactiveFormsModule, MatFormFieldModule, MatInputModule],
  providers: [
    provideTranslocoScope({ scope: 'control-panel/members/modals/create-member', alias: 'createMember' }),
  ],
  templateUrl: './create-member.component.html'
})
export class CreateMemberComponent {
  protected isPasswordVisible: boolean = false;
  readonly maritalStatuses = ApplicationConstants.maritalStatuses;

  readonly memberInfo: FormGroup = new FormGroup({
    name: new FormControl<string>('', [Validators.required, Validators.maxLength(255)]),
    cpf: new FormControl<string>('', [Validators.required, Validators.maxLength(11), Validators.minLength(11)]),
    maritalStatus: new FormControl<string>('', [Validators.required]),
    email: new FormControl<string>('', [Validators.required, Validators.email, Validators.maxLength(255)]),
    password: new FormControl<string>('', [Validators.required, Validators.maxLength(255)]),
  })

  constructor(private dialogRef: MatDialogRef<CreateMemberComponent>) { }

  submit() {
    if (this.memberInfo.invalid) return

    const membro: CreateMember = {
      nome: this.memberInfo.get('name')?.value,
      cpf: this.memberInfo.get('cpf')?.value,
      estadoCivilId: this.memberInfo.get('maritalStatus')?.value,
      email: this.memberInfo.get('email')?.value,
      senha: this.memberInfo.get('password')?.value
    }

    this.dialogRef.close(membro)
  }

  togglePasswordVisible() {
    this.isPasswordVisible = !this.isPasswordVisible;
  }
}
