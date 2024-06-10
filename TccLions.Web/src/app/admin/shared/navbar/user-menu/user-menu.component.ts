import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-user-menu',
  standalone: true,
  imports: [MatIconModule, MatMenuModule, CommonModule, RouterLink],
  templateUrl: './user-menu.component.html',
  styleUrl: './user-menu.component.css'
})
export class UserMenuComponent {
  isLogged: boolean = false;
  isAdmin: boolean = true;

  constructor(private router: Router) {

  }

  redirectToLogin() {
    this.router.navigate(['/login'])
  }

  redirectToAdminPage() {
    this.router.navigate(['/admin'])
  }
}
