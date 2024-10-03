import { CommonModule } from '@angular/common';
import { Component, inject, Input } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../../../core/auth/auth.service';

@Component({
  selector: 'app-user-menu',
  standalone: true,
  imports: [MatIconModule, MatMenuModule, CommonModule, RouterLink],
  templateUrl: './user-menu.component.html',
  styleUrl: './user-menu.component.css'
})
export class UserMenuComponent {
  private _authService = inject(AuthService);
  @Input() isLogged: boolean = false;

  constructor(private router: Router) {

  }

  redirectToLogin() {
    this.router.navigate(['/login'])
  }

  logout() {
    this._authService.logout();
    this.router.navigate(['/'])
  }
}
