import { Component, inject, OnInit } from '@angular/core';
import { AuthService } from '../../core/auth/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {
  authService = inject(AuthService)

  ngOnInit(): void {
    this.authService.login('string', 'string').subscribe();

    console.log(this.authService.isAdmin());
  }
}
