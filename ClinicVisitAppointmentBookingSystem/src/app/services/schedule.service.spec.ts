import { HttpErrorResponse } from '@angular/common/http';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { Router } from '@angular/router';
import { ClinicAndServices, ScheduleAppointment } from './Patient';

import { ScheduleService } from './schedule.service';

describe('ScheduleserviceService', () => {
  let service: ScheduleService,
  httpTestingController:HttpTestingController,
  routerSpy:any;

  beforeEach(() => {
    routerSpy=jasmine.createSpyObj('Router',["navigate"]);
    TestBed.configureTestingModule({
      imports:[HttpClientTestingModule],
      providers:[ScheduleService,{provide:Router,useValue:routerSpy}]
    });
    service = TestBed.inject(ScheduleService);
    httpTestingController=TestBed.get(HttpTestingController);
  });
  it('GetClinicById returns Clinic by Id', () => {
    expect(service).toBeTruthy();
    let Id="e234528757f"
    let url="https://localhost:7176/api/Schedules/GetClincById?Id="+Id;
    let clinic=new ClinicAndServices();
    service.GetClinicById(Id).subscribe(data=>{
      expect(data).toBeTruthy("Returns Clinic");
      expect(data).toEqual({
        "id":"e234528757f",
        "clinicName":"Clinic 1",
        "clinic Address":"Main street, New York",
        "services":["Vaccination","Wound care","General Visit","Lab tests"]
       });
    });
    const req=httpTestingController.expectOne(url);
    expect(req.request.method).toEqual("GET");
    req.flush({
     "id":"e234528757f",
     "clinicName":"Clinic 1",
     "clinic Address":"Main street, New York",
     "services":["Vaccination","Wound care","General Visit","Lab tests"]
    })

  });
  it('GetClinicById returns No clinic Found', () => {
    expect(service).toBeTruthy();
    let Id="e234528757f"
    let url="https://localhost:7176/api/Schedules/GetClincById?Id="+Id;
    let clinic=new ClinicAndServices();
    service.GetClinicById(Id).subscribe(()=>fail(),
    (error:HttpErrorResponse)=>{
      expect(error).toBeTruthy();
    });
    const req=httpTestingController.expectOne(url);
    expect(req.request.method).toEqual("GET");
    req.flush('No clinic Found',{status:404,statusText:"NotFound"});
  });
  it('GetClinicsByService returns Clinic by Service', () => {
    expect(service).toBeTruthy();
    let Service="Vaccination"
    let url="https://localhost:7176/api/Schedules/clinics/GetClinicsByService?service="+Service;
    let clinic=new ClinicAndServices();
    service.GetClinicByServices(Service).subscribe(data=>{
      expect(data).toBeTruthy("Returns Clinics By Service");
      expect(data).toEqual([{
        "id":"e234528757f",
        "clinicName":"Clinic 1",
        "clinic Address":"Main street, New York",
        "services":["Vaccination","Wound care","General Visit","Lab tests"]
       },
      {
        "id":"e234528757g",
        "clinicName":"Clinic 2",
        "clinic Address":"Main street -1, New York",
        "services":["Vaccination","Wound care","General Visit","Lab tests"]
      }]);
    });
    const req=httpTestingController.expectOne(url);
    expect(req.request.method).toEqual("GET");
    req.flush([{
     "id":"e234528757f",
     "clinicName":"Clinic 1",
     "clinic Address":"Main street, New York",
     "services":["Vaccination","Wound care","General Visit","Lab tests"]
    },
     {
      "id":"e234528757g",
      "clinicName":"Clinic 2",
      "clinic Address":"Main street -1, New York",
      "services":["Vaccination","Wound care","General Visit","Lab tests"]
    }])

  });
  it('GetClinicsByService returns No clinics Found', () => {
    expect(service).toBeTruthy();
    let Service="Trauma"
    let url="https://localhost:7176/api/Schedules/clinics/GetClinicsByService?service="+Service;
    let clinic=new ClinicAndServices();
    service.GetClinicByServices(Service).subscribe(()=>fail(),
    (error:HttpErrorResponse)=>{
      expect(error).toBeTruthy();
    });
    const req=httpTestingController.expectOne(url);
    expect(req.request.method).toEqual("GET");
    req.flush('No clinics Found',{status:404,statusText:"NotFound"});
  });
  it('GetById returns ScheduleAppointment by Id', () => {
    expect(service).toBeTruthy();
    let Id="e234528757f"
    let url="https://localhost:7176/api/Schedules/GetById?Id="+Id;
    let clinic=new ScheduleAppointment();
    const date=Date.now();
    service.GetById(Id).subscribe(data=>{
      expect(data).toBeTruthy("Returns ScheduleAppointment");
      expect(JSON.parse(data)).toEqual({
        "id":"e234528757f",
        "patientuserName":"Arun123",
        "clinicName":"Clinic 1",
        "clinicAddress":"Main street, New York",
        "service":"Vaccination",
        "dateTimeOfVisit":date
       });
    });
    const req=httpTestingController.expectOne(url);
    expect(req.request.method).toEqual("GET");
    req.flush({
      "id":"e234528757f",
      "patientuserName":"Arun123",
      "clinicName":"Clinic 1",
      "clinicAddress":"Main street, New York",
      "service":"Vaccination",
      "dateTimeOfVisit":date
    })

  });
  it('GetById returns No Schedule Appointment Found', () => {
    expect(service).toBeTruthy();
    let Id="e234528757f"
    let url="https://localhost:7176/api/Schedules/GetById?Id="+Id;
    let clinic=new ScheduleAppointment();
    service.GetById(Id).subscribe(()=>fail(),
    (error:HttpErrorResponse)=>{
      expect(error).toBeTruthy();
    });
    const req=httpTestingController.expectOne(url);
    expect(req.request.method).toEqual("GET");
    req.flush('No appointment Found',{status:404,statusText:"NotFound"});
  });
  it('Add ScheduleAppointment returns ScheduleAppointment', () => {
    expect(service).toBeTruthy();
    let Id="e234528757f"
    let url="https://localhost:7176/api/Schedules/ScheduleAppointment";
    let clinic=new ScheduleAppointment();
    const date=Date.now();
    service.ScheduleAppointment(clinic).subscribe(data=>{
      expect(data).toBeTruthy("Returns ScheduleAppointment");
      expect(JSON.parse(data)).toEqual({
        "id":"e234528757f",
        "patientuserName":"Arun123",
        "clinicName":"Clinic 1",
        "clinicAddress":"Main street, New York",
        "service":"Vaccination",
        "dateTimeOfVisit":date
       });
    });
    const req=httpTestingController.expectOne(url);
    expect(req.request.method).toEqual("POST");
    req.flush({
      "id":"e234528757f",
      "patientuserName":"Arun123",
      "clinicName":"Clinic 1",
      "clinicAddress":"Main street, New York",
      "service":"Vaccination",
      "dateTimeOfVisit":date
    })


  });
  it('Add ScheduleAppointment returns BadRequest', () => {
    expect(service).toBeTruthy();
    let Id="e234528757f"
    let url="https://localhost:7176/api/Schedules/ScheduleAppointment";
    let clinic=new ScheduleAppointment();
    service.ScheduleAppointment(clinic).subscribe(()=>fail(),
    (error:HttpErrorResponse)=>{
      expect(error).toBeTruthy();
    });
    const req=httpTestingController.expectOne(url);
    expect(req.request.method).toEqual("POST");
    req.flush('Selected Date & Time should be more than Current Date & Time',{status:400,statusText:"BadRequest"});
  });

  
});
