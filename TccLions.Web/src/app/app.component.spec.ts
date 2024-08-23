import { TestBed } from '@angular/core/testing';
import { AppComponent } from './app.component';
import {TranslocoConfig, TranslocoService, TranslocoTestingModule, TranslocoTestingOptions} from "@jsverse/transloco";
const translocoServicesTests: Partial<TranslocoConfig> = {
  defaultLang: 'us',
  availableLangs: ['us'],
  reRenderOnLangChange: false
}
const transloco: TranslocoTestingOptions = {translocoConfig: translocoServicesTests}

describe('AppComponent', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AppComponent, TranslocoTestingModule.forRoot(transloco)],
      providers: [
        {provide: TranslocoService, useClass: TranslocoService},
      ]
    }).compileComponents();
  });

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });

});
