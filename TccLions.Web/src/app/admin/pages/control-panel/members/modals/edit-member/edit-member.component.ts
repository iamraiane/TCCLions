import { CommonModule } from '@angular/common';
import { Component, Inject } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { provideTranslocoScope, TranslocoModule } from '@jsverse/transloco';
import { CreateMember, Member, MemberDetails } from '../../members.models';
import { MembersService } from '../../service/members.service';

@Component({
  selector: 'app-edit-member',
  standalone: true,
  imports: [MatDialogModule, MatButtonModule, MatSelectModule, CommonModule, MatIconModule, TranslocoModule, FormsModule, ReactiveFormsModule, MatFormFieldModule, MatInputModule],
  providers: [
    provideTranslocoScope({ scope: 'control-panel/members/modals/create-member', alias: 'createMember' }),
  ],
  templateUrl: './edit-member.component.html'
})
export class EditMemberComponent {
  readonly maritalStatus: { [key: string]: number } = {
    'Solteiro': 1,
    'Casado': 2,
    'Separado': 3,
    'Divorciado': 4,
    'Viuvo': 5
  }

  constructor(private _service: MembersService, @Inject(MAT_DIALOG_DATA) private data: { id: string }, private dialogRef: MatDialogRef<EditMemberComponent>) {
    this._service.getDetails(data.id).subscribe((member) => {
      this.memberInfo.controls['name'].setValue(member.nome);
      this.memberInfo.controls['cpf'].setValue(member.cpf);
      this.memberInfo.controls['maritalStatus'].setValue(this.maritalStatus[member.estadoCivil ?? ""]);
      this.memberInfo.controls['email'].setValue(member.email);
    })
  }

  readonly memberInfo: FormGroup = new FormGroup({
    name: new FormControl<string>('', [Validators.required, Validators.maxLength(255)]),
    cpf: new FormControl<string>('', [Validators.required, Validators.maxLength(11), Validators.minLength(11)]),
    maritalStatus: new FormControl<string>('', [Validators.required]),
    email: new FormControl<string>('', [Validators.required, Validators.email, Validators.maxLength(255)]),
  })

  delete() {
    this._service.delete(this.data.id).subscribe(() => this.dialogRef.close("deleted"))
  }

  save() {
    if (this.memberInfo.invalid) return

    const membro: MemberDetails = {
      nome: this.memberInfo.get('name')?.value,
      cpf: this.memberInfo.get('cpf')?.value,
      estadoCivilId: this.memberInfo.get('maritalStatus')?.value,
      email: this.memberInfo.get('email')?.value,
    }

    this.dialogRef.close(membro)
  }
}
