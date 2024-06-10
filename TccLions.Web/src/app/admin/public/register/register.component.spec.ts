import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterComponent } from './register.component';
import {TranslocoConfig, TranslocoTestingModule, TranslocoTestingOptions} from "@jsverse/transloco";

describe('RegisterComponent', () => {
  let component: RegisterComponent;
  let fixture: ComponentFixture<RegisterComponent>;
  const translocoServicesTests: Partial<TranslocoConfig> = {
    defaultLang: 'us',
    availableLangs: ['us'],
    reRenderOnLangChange: false
  }
  const transloco: TranslocoTestingOptions = {translocoConfig: translocoServicesTests}

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RegisterComponent, TranslocoTestingModule.forRoot(transloco)]
    })
      .compileComponents();

    fixture = TestBed.createComponent(RegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should register return false when register is called with invalid email input', () => {
    component.emailFormControl.setValue('email')
    component.passwordFormControl.setValue('123123')

    let result = component.register()
    expect(result).toBeFalse();
  })

  it('should register return false when register is called with invalid password input', () => {
    component.emailFormControl.setValue('email@gmail.com')
    component.passwordFormControl.setValue('123123')

    let result = component.register()
    expect(result).toBeFalse();
  })

  it('should register return true when register is called with valid password inputs', () => {
    component.emailFormControl.setValue('email@gmail.com')
    component.passwordFormControl.setValue('123123123')

    let result = component.register()
    expect(result).toBeTrue();
  })
});
