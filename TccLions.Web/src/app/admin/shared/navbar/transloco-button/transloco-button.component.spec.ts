import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TranslocoButtonComponent } from './transloco-button.component';
import {TranslocoConfig, TranslocoService, TranslocoTestingModule, TranslocoTestingOptions} from "@jsverse/transloco";

describe('TranslocoButtonComponent',
  () => {
    let component: TranslocoButtonComponent;
    let fixture: ComponentFixture<TranslocoButtonComponent>;
    const translocoServicesTests: Partial<TranslocoConfig> = {
      defaultLang: 'en',
      availableLangs: ['en', 'pt'],
      reRenderOnLangChange: false
    }
    const transloco: TranslocoTestingOptions = {translocoConfig: translocoServicesTests}

    beforeEach(async () => {
      await TestBed.configureTestingModule({
        imports: [TranslocoButtonComponent, TranslocoTestingModule.forRoot(transloco)],
        providers: [
          {provide: TranslocoService, useClass: TranslocoService},
        ]
      }).compileComponents();

      fixture = TestBed.createComponent(TranslocoButtonComponent);
      component = fixture.componentInstance;
      fixture.detectChanges();
    });

    it('should create', () => {
      expect(component).toBeTruthy();
    });

    it('should get the current language when getActiveLanguage is called', () => {
      let result = component.getActiveLanguage();
      expect(result).toEqual('en');
    })

    it('should change the language when translate is called with some language', () => {
      component.translate('pt');
      expect(component['_translocoService'].getActiveLang()).toEqual('pt');
    })
  });
