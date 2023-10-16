import { HttpClientModule } from '@angular/common/http';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';

import { AppointmentstatusComponent } from './appointmentstatus.component';

describe('AppointmentstatusComponent', () => {
  let component: AppointmentstatusComponent;
  let fixture: ComponentFixture<AppointmentstatusComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports:[HttpClientModule,HttpClientTestingModule,RouterTestingModule],
      declarations: [ AppointmentstatusComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AppointmentstatusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
