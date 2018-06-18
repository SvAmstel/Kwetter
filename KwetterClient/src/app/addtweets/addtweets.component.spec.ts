import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddtweetsComponent } from './addtweets.component';

describe('AddtweetsComponent', () => {
  let component: AddtweetsComponent;
  let fixture: ComponentFixture<AddtweetsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddtweetsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddtweetsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
