import {async, TestBed} from '@angular/core/testing';
import {FooterComponent} from './footer.component';

describe('FooterComponent', () => {
  let fixture;
  let component;

  beforeEach(async(() => {
    fixture = TestBed.createComponent(FooterComponent);
    fixture.detectChanges();
    component = fixture.debugElement.componentInstance;
  }));

  it('should create footer component', (() => {
    expect(component).toBeTruthy();
  }));
});
