import { DatePipe } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { NgbDate } from '@ng-bootstrap/ng-bootstrap';

import { SchedulevisitComponent } from './schedulevisit.component';

describe('SchedulevisitComponent', () => {
  let component: SchedulevisitComponent;
  let fixture: ComponentFixture<SchedulevisitComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports:[HttpClientModule,HttpClientTestingModule,RouterTestingModule],
      providers:[DatePipe],
      declarations: [ SchedulevisitComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SchedulevisitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('Valid PatientUsername',()=>{

    let puname=component.form.controls['patientuserName']

    puname.setValue('pusername')

    expect(puname.value).toEqual('pusername')

  });

  it('Invalid PatientUsername', () => {

    let puname = component.form.controls['patientuserName']

    expect(puname.valid).toBeFalse();

    expect(puname.errors).toBeNull();

  });

  it('Valid ClinicName',()=>{

    let cname=component.form.controls['clinicName']

    cname.setValue('clinicname')

    expect(cname.value).toEqual('clinicname')

  });

  it('Invalid ClinicName', () => {

    let cname = component.form.controls['clinicName']

    expect(cname.valid).toBeFalse();

    expect(cname.errors).toBeNull();

  });

  it('Valid Service',()=>{

    let service=component.form.controls['service']

    service.setValue('service')

    expect(service.value).toEqual('service')

  });

  it('Invalid Service', () => {

    let service = component.form.controls['service']

    expect(service.valid).toBeFalse();

    expect(service.errors).toBeNull();

  });

  it('Valid SelectedDate',()=>{

    let sdate=component.form.controls['selectedDate']

    sdate.setValue(new NgbDate(2023,1,1));

    expect(sdate.value).toEqual(new NgbDate(2023,1,1))

  });

  it('Invalid SelectedDate', () => {

    let sdate = component.form.controls['selectedDate']

    expect(sdate.valid).toBeTruthy();

    expect(sdate.errors).toBeNull();

  });

  it('Valid SelectedTime',()=>{

    let time=component.form.controls['selectedTimeSlot']

    time.setValue(new Date(2023,1,1));

    expect(time.value).toEqual(new Date(2023,1,1))

  });

  it('Invalid SelectedTime', () => {

    let sdate = component.form.controls['selectedTimeSlot']

    expect(sdate.valid).toBeTruthy();

    expect(sdate.errors).toBeNull();

  });
});
