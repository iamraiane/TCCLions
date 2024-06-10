import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginComponent } from './login.component';
import {TranslocoConfig, TranslocoTestingModule, TranslocoTestingOptions} from "@jsverse/transloco";

describe('LoginComponent', () => {
  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;
  const translocoServicesTests: Partial<TranslocoConfig> = {
    defaultLang: 'us',
    availableLangs: ['us'],
    reRenderOnLangChange: false
  }
  const transloco: TranslocoTestingOptions = {translocoConfig: translocoServicesTests}

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LoginComponent, TranslocoTestingModule.forRoot(transloco)]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should login return false when login is called with invalid email input', () => {
    component.emailFormControl.setValue('email')
    component.passwordFormControl.setValue('123123')

    let result = component.login()
    expect(result).toBeFalse();
  })

  it('should login return false when login is called with invalid password input', () => {
    component.emailFormControl.setValue('email@gmail.com')
    component.passwordFormControl.setValue('123123')

    let result = component.login()
    expect(result).toBeFalse();
  })

  it('should login return true when login is called with valid password inputs', () => {
    component.emailFormControl.setValue('email@gmail.com')
    component.passwordFormControl.setValue('123123123')

    let result = component.login()
    expect(result).toBeTrue();
  })
});
