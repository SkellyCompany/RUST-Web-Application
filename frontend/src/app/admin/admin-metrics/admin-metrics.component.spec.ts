import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminMetricsComponent } from './admin-metrics.component';

describe('AdminMetricsComponent', () => {
  let component: AdminMetricsComponent;
  let fixture: ComponentFixture<AdminMetricsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminMetricsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminMetricsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
