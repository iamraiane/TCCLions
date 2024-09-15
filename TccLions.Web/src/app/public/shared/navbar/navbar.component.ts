import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { TranslocoModule, provideTranslocoScope } from '@jsverse/transloco';
import { RouterLink } from "@angular/router";
import { TranslocoButtonComponent } from "./transloco-button/transloco-button.component";
import { UserMenuComponent } from './user-menu/user-menu.component';
import { MatMenuModule } from '@angular/material/menu';
import { AuthService } from '../../../core/auth/auth.service';
import { ApplicationConstants } from '../../../core/settings/application-constants';
@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [MatIconModule, TranslocoModule, MatMenuModule, CommonModule, RouterLink, TranslocoButtonComponent, UserMenuComponent],
  providers: [
    provideTranslocoScope({ scope: 'navigation', alias: 'navigation' })
  ],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css',

})
export class NavbarComponent implements OnInit {
  authService = inject(AuthService);
  isAdmin: boolean = false;
  isLogged: boolean = false;
  nomeDoMembro: string = '';

  ngOnInit(): void {
    this.authService.membro$.subscribe(membro => {
      this.isLogged = Boolean(membro);
      this.isAdmin = membro?.permissoes?.some(p => p == ApplicationConstants.permissions.admin) ?? false;
      this.nomeDoMembro = membro?.nome || '';
    })
  }
}
