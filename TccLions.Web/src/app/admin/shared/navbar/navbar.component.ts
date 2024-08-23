import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { TranslocoModule, provideTranslocoScope } from '@jsverse/transloco';
import { RouterLink } from "@angular/router";
import { TranslocoButtonComponent } from "./transloco-button/transloco-button.component";
import { UserMenuComponent } from './user-menu/user-menu.component';
import { MatMenuModule } from '@angular/material/menu';
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
export class NavbarComponent {
}
