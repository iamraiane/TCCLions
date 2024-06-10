import { Component } from '@angular/core';
import {FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators} from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatDividerModule } from '@angular/material/divider';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { TRANSLOCO_SCOPE, TranslocoModule } from '@jsverse/transloco';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-login',
  standalone: true,
  imports: [MatFormFieldModule, FormsModule, MatCardModule, MatIconModule, MatDividerModule, MatInputModule, MatButtonModule, TranslocoModule, CommonModule, ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
  providers: [
    {
      provide: TRANSLOCO_SCOPE,
      useValue: { scope: 'login', alias: 'login' }
    }
  ]
})
export class LoginComponent {
  emailFormControl = new FormControl('', [Validators.required, Validators.minLength(8), Validators.maxLength(100)])
  passwordFormControl = new FormControl('', [Validators.required, Validators.minLength(8), Validators.maxLength(100)])

  login(): boolean{
    if (this.emailFormControl.invalid || this.passwordFormControl.invalid) return false

    alert('Login')
    return true
  }
}
