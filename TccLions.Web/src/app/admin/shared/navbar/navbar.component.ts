import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MatSelectModule } from '@angular/material/select';
import { TRANSLOCO_SCOPE, TranslocoModule, provideTranslocoScope } from '@jsverse/transloco';
import { RouterLink } from "@angular/router";
import { TranslocoButtonComponent } from "./transloco-button/transloco-button.component";
import { NavbarTextComponent } from './navbartext/navbartext.component';
import { UserMenuComponent } from './user-menu/user-menu.component';
@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [MatIconModule, TranslocoModule, MatSelectModule, CommonModule, RouterLink, TranslocoButtonComponent, NavbarTextComponent, UserMenuComponent],
  providers: [
    provideTranslocoScope({ scope: 'navigation', alias: 'navigation' })
  ],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css',

})
export class NavbarComponent {
}
