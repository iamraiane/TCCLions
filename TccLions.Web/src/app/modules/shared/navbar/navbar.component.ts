import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MatSelectModule } from '@angular/material/select';
import { TranslocoModule } from '@jsverse/transloco';
import { MatTooltipModule } from '@angular/material/tooltip';
import {RouterLink} from "@angular/router";
import {TranslocoButtonComponent} from "./transloco-button/transloco-button.component";

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [MatIconModule, MatSelectModule, TranslocoModule, CommonModule, MatTooltipModule, RouterLink, TranslocoButtonComponent],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css',

})
export class NavbarComponent {
}
