import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-navbartext',
  standalone: true,
  imports: [],
  templateUrl: './navbartext.component.html'
})
export class NavbarTextComponent {
  @Input() topText: string = ''
  @Input() bottomText: string = ''
  @Input() route: string = ''

  constructor(private _router: Router) { }

  redirectToPage() {
    this._router.navigate([`/${this.route}`])
  }
}
