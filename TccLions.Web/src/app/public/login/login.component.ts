import { Component, inject, OnInit } from '@angular/core';
import { AuthService } from '../../core/auth/auth.service';
import { MatInputModule } from '@angular/material/input';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { provideTranslocoScope, TranslocoModule } from '@jsverse/transloco';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [MatInputModule, FormsModule, ReactiveFormsModule, MatButtonModule, CommonModule, TranslocoModule],
  providers: [
    provideTranslocoScope({ scope: 'login', alias: 'login' })
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {
  private _authService = inject(AuthService)
  private _router = inject(Router);
  private _snackBar = inject(MatSnackBar);

  loginFormGroup: FormGroup = new FormGroup({
    userOrEmail: new FormControl<string>('', [Validators.required]),
    password: new FormControl<string>('', [Validators.required])
  });

  ngOnInit(): void {
  }

  login() {
    if (this.loginFormGroup.invalid) return

    const userOrEmail = this.loginFormGroup.get('userOrEmail')?.value;
    const password = this.loginFormGroup.get('password')?.value;

    this._authService.login(userOrEmail, password).subscribe({
      next: () => {
        console.log('Logged in successfully');
        this._router.navigate(['/']);
      }, error: (err) => {
        if (err?.error?.errors?.DomainValidations)
          this._snackBar.open(err.error.errors.DomainValidations[0], undefined, {
            duration: 2000
          });

        console.error(err);
      }
    });
  }
}
