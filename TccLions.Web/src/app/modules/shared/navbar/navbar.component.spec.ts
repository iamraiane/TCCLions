import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NavbarComponent } from './navbar.component';
import {TranslocoConfig, TranslocoService, TranslocoTestingModule, TranslocoTestingOptions} from "@jsverse/transloco";

describe('NavbarComponent', () => {
  let component: NavbarComponent;
  let fixture: ComponentFixture<NavbarComponent>;
  const translocoServicesTests: Partial<TranslocoConfig> = {
    defaultLang: 'us',
    availableLangs: ['us'],
    reRenderOnLangChange: false
  }
  const transloco: TranslocoTestingOptions = {translocoConfig: translocoServicesTests}

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NavbarComponent, TranslocoTestingModule.forRoot(transloco)],
      providers: [
        {
          provide: TranslocoService,
          useClass: TranslocoService
        }
      ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NavbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
