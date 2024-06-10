import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeComponent } from './home.component';
import {TranslocoConfig, TranslocoTestingModule, TranslocoTestingOptions} from "@jsverse/transloco";

describe('HomeComponent', () => {
  let component: HomeComponent;
  let fixture: ComponentFixture<HomeComponent>;
  const translocoServicesTests: Partial<TranslocoConfig> = {
    defaultLang: 'us',
    availableLangs: ['us'],
    reRenderOnLangChange: false
  }
  const transloco: TranslocoTestingOptions = {translocoConfig: translocoServicesTests}

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HomeComponent, TranslocoTestingModule.forRoot(transloco)]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
