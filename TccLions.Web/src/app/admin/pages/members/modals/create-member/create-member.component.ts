import { Component } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { provideTranslocoScope, TranslocoModule } from '@jsverse/transloco';

@Component({
  selector: 'app-create-member',
  standalone: true,
  imports: [MatDialogModule, MatIconModule, TranslocoModule, FormsModule, ReactiveFormsModule, MatFormFieldModule, MatInputModule],
  providers: [
    provideTranslocoScope({ scope: 'control-panel/members/modals/create-member', alias: 'createMember' }),
  ],
  templateUrl: './create-member.component.html'
})
export class CreateMemberComponent {

}
