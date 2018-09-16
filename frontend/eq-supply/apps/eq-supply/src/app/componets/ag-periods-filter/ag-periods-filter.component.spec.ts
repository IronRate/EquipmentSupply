import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AgPeriodsFilterComponent } from './ag-periods-filter.component';

describe('AgPeriodsFilterComponent', () => {
  let component: AgPeriodsFilterComponent;
  let fixture: ComponentFixture<AgPeriodsFilterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AgPeriodsFilterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AgPeriodsFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
