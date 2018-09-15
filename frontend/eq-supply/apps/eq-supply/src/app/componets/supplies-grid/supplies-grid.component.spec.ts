import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SuppliesGridComponent } from './supplies-grid.component';

describe('SuppliesGridComponent', () => {
  let component: SuppliesGridComponent;
  let fixture: ComponentFixture<SuppliesGridComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SuppliesGridComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SuppliesGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
