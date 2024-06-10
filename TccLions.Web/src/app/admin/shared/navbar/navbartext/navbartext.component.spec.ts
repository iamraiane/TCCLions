import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NavbarTextComponent } from './navbartext.component';

describe('NavbarTextComponent', () => {
  let component: NavbarTextComponent;
  let fixture: ComponentFixture<NavbarTextComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NavbarTextComponent]
    })
      .compileComponents();

    fixture = TestBed.createComponent(NavbarTextComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
