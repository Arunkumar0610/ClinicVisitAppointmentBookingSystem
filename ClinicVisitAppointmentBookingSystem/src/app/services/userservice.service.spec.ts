import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { UserserviceService } from './userservice.service';
import { Router } from '@angular/router';
import { LoginRequest, PatientRegister } from './Patient';
import { HttpErrorResponse } from '@angular/common/http';

describe('UserserviceService', () => {
  let service: UserserviceService,
  httpTestingController:HttpTestingController,
  routerSpy:any;

  beforeEach(() => {
    routerSpy=jasmine.createSpyObj('Router',["navigate"]);
    TestBed.configureTestingModule({
      imports:[HttpClientTestingModule],
      providers:[UserserviceService,{provide:Router,useValue:routerSpy}]
    });
    service = TestBed.inject(UserserviceService);
    httpTestingController=TestBed.get(HttpTestingController);
  });

  it(('Login should return login response object'), () => {
    let url="https://localhost:7105/api/Users/login"
    let user:LoginRequest=new LoginRequest("Arun123","Arun123@");
    service.LoginUser(user).subscribe(data=>{
      let loginResponse=JSON.parse(data);
      expect(data).toBeTruthy("Login Object returned");
      expect(loginResponse.userName).toBe("Arun123");
      expect(loginResponse.id).toBe("qwea1234563545wafsd");
      expect(loginResponse.token).toBe("naslndajdnajdd");
      expect(loginResponse.email).toBe("arun@gmail.com");
    });
    const req=httpTestingController.expectOne(url);
    expect(req.request.method).toEqual("POST");
    req.flush({
      "id":"qwea1234563545wafsd",
      "email":"arun@gmail.com",
      "userName":"Arun123",
      "token":"naslndajdnajdd"
    })
  });
  it(('Login should return Username or password are incorrect'), () => {
    let url="https://localhost:7105/api/Users/login"
    let user:LoginRequest=new LoginRequest("Arun123","Arun111@");
    service.LoginUser(user).subscribe(data=>{
      let loginResponse=data;
      expect(data).toBeTruthy("No Login Object returned");
      expect(data as string).toBe("Username or password are incorrect");
    });
    const req=httpTestingController.expectOne(url);
    expect(req.request.method).toEqual("POST");
    req.flush('Username or password are incorrect')
  });
  it(('RegisterUser should return Patient Object'),()=>{
    let url="https://localhost:7105/api/Users/register"
     let user: PatientRegister;
    user=new PatientRegister(
      );
      service.RegisterUser(user).subscribe(data=>{
        expect(data).toBeTruthy("user is registered");
        expect(JSON.parse(data)).toEqual({"id":"qwrewtqtt",
        "firstName":"Arunkumar",
        "lastName":"yada1",
        "email":"arun@gmail.com",
        "userName":"Arun123",
        
        "dateOfBirth":"1999-10-06T00:00:00.000Z",
        "gender":"Male",
        "phoneNumber":"1234567890"});
        
      });
      const req=httpTestingController.expectOne(url);
      expect(req.request.method).toEqual("POST");
      req.flush({"id":"qwrewtqtt",
    "firstName":"Arunkumar",
    "lastName":"yada1",
    "email":"arun@gmail.com",
    "userName":"Arun123",
    
    "dateOfBirth":new Date("1999-10-06T00:00:00.000Z"),
    "gender":"Male",
    "phoneNumber":"1234567890"})
  });
  it(('RegisterUser should return Password format is incorrect'),()=>{
    let url="https://localhost:7105/api/Users/register"
     let user: PatientRegister;
    user=new PatientRegister(
      );
      service.RegisterUser(user).subscribe(()=>fail(),
      (error:HttpErrorResponse)=>{
        expect(error).toBeTruthy();
        
      });
      const req=httpTestingController.expectOne(url);
      expect(req.request.method).toEqual("POST");
      req.flush('Password must be between 8 and 15 characters and contain atleast one uppercase,lowercase,number and special character.',{status:400,statusText:"BadRequest"});
  });
  it(('RegisterUser should return User already exists'),()=>{
    let url="https://localhost:7105/api/Users/register"
     let user: PatientRegister;
    user=new PatientRegister(
      );
      service.RegisterUser(user).subscribe(()=>fail(),
      (error:HttpErrorResponse)=>{
        expect(error).toBeTruthy();
        
      });
      const req=httpTestingController.expectOne(url);
      expect(req.request.method).toEqual("POST");
      req.flush('UserName or Email already exists',{status:400,statusText:"BadRequest"});
  });
  it(('RegisterUser should return User already exists'),()=>{
    let url="https://localhost:7105/api/Users/register"
     let user: PatientRegister;
    user=new PatientRegister(
      );
      service.RegisterUser(user).subscribe(()=>fail(),
      (error:HttpErrorResponse)=>{
        expect(error).toBeTruthy();
        
      });
      const req=httpTestingController.expectOne(url);
      expect(req.request.method).toEqual("POST");
      req.flush('UserName or Email already exists',{status:400,statusText:"BadRequest"});
  });
});
