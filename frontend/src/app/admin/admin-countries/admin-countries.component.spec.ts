import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminCountriesComponent } from './admin-countries.component';

describe('AdminCountriesComponent', () => {
  let component: AdminCountriesComponent;
  let fixture: ComponentFixture<AdminCountriesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminCountriesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminCountriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
