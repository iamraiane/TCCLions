import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { TRANSLOCO_SCOPE, TranslocoModule } from '@jsverse/transloco';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [MatFormFieldModule, FormsModule, MatCardModule, MatIconModule, MatDividerModule, MatInputModule, MatButtonModule, TranslocoModule, CommonModule, ReactiveFormsModule],
  providers: [
    {
      provide: TRANSLOCO_SCOPE,
      useValue: { scope: 'register', alias: 'register' }
    }
  ],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  emailFormControl = new FormControl('', [Validators.required, Validators.email, Validators.minLength(0)])
  passwordFormControl = new FormControl('', [Validators.required, Validators.minLength(8), Validators.maxLength(100)])
  fullNameFormControl = new FormControl('', [Validators.required])
  cpfFormControl = new FormControl('', [Validators.required, Validators.pattern("[0-9]{3}[\.][0-9]{3}[\.][0-9]{3}[\-][0-9]{2}")])

  register(): boolean{
    if (this.emailFormControl.invalid || this.passwordFormControl.invalid) return false

    alert('Login')
    return true
  }
}
