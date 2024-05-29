import {Component, inject} from '@angular/core';
import {MatTooltipModule} from "@angular/material/tooltip";
import {CommonModule, NgOptimizedImage} from "@angular/common";
import {TRANSLOCO_SCOPE, TranslocoModule, TranslocoService} from "@jsverse/transloco";
import {MatMenuModule} from "@angular/material/menu";
import {MatRipple} from "@angular/material/core";

@Component({
  selector: 'app-transloco-button',
  standalone: true,
  imports: [
    MatTooltipModule,
    CommonModule,
    TranslocoModule,
    MatMenuModule,
    NgOptimizedImage,
    MatRipple
  ],
  providers: [
    {
      provide: TRANSLOCO_SCOPE,
      useValue: { scope: 'navbar', alias: 'translocoButton' }
    }
  ],
  templateUrl: './transloco-button.component.html'
})
export class TranslocoButtonComponent {
  private _translocoService = inject(TranslocoService)

  translate(language: string) {
    this._translocoService.setActiveLang(language);
  }

  getActiveLanguage() {
    return this._translocoService.getActiveLang();
  }
}
