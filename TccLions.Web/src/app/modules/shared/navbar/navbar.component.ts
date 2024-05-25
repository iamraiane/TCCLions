import { Component, inject } from '@angular/core';
import {MatIconModule} from '@angular/material/icon';
import {MatSelectModule} from '@angular/material/select';
import { TRANSLOCO_SCOPE, TranslocoModule, TranslocoService } from '@jsverse/transloco';


@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [MatIconModule, MatSelectModule, TranslocoModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css',
})
export class NavbarComponent {
  private _translocoService = inject(TranslocoService)

  translate() {
    this._translocoService.setActiveLang(this._translocoService.getActiveLang() === 'en' ? 'pt' : 'en');
  }
}
