import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Childsample } from './childsample';

describe('Childsample', () => {
  let component: Childsample;
  let fixture: ComponentFixture<Childsample>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Childsample],
    }).compileComponents();

    fixture = TestBed.createComponent(Childsample);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
