import { HttpClientModule } from '@angular/common/http';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';

import { SignupComponent } from './signup.component';

describe('SignupComponent', () => {
  let component: SignupComponent;
  let fixture: ComponentFixture<SignupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports:[HttpClientModule,HttpClientTestingModule,RouterTestingModule],
      declarations: [ SignupComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SignupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('Valid Firstname', () => {

    let fname = component.form.controls['firstname']

    fname.setValue('firstname')

    expect(fname.value).toEqual('firstname');

  });

  it('Invalid Firstname', () => {

    let fname = component.form.controls['firstname']

    expect(fname.valid).toBeFalse();

    expect(fname.errors).toBeTruthy();

  });

  it('Valid Lastname', () => {

    let lname = component.form.controls['lastname']

    lname.setValue('firstname')

    expect(lname.value).toEqual('firstname');

  });

  it('Invalid Lastname', () => {

    let lname = component.form.controls['lastname']

    expect(lname.valid).toBeFalse();

    expect(lname.errors).toBeTruthy();

  });

  it('Valid Password', () => {

    let password = component.form.controls['password']

    password.setValue('password')

    expect(password.value).toEqual('password');

  });

  it('Invalid Password', () => {

    let password = component.form.controls['password']

    expect(password.valid).toBeFalse();

    expect(password.errors).toBeTruthy();

  });

  it('Valid Username', () => {

    let username = component.form.controls['username']

    username.setValue('username')

    expect(username.value).toEqual('username');

  });

  it('Invalid Username', () => {

    let username = component.form.controls['username']

    expect(username.valid).toBeFalse();

    expect(username.errors).toBeTruthy();

  });

  it('Valid ConfirmPassword', () => {

    let cp = component.form.controls['confirmpassword']

    cp.setValue('confirmpassword')

    expect(cp.value).toEqual('confirmpassword');

  });

  it('Invalid ConfirmPassword', () => {

    let cp = component.form.controls['confirmpassword']

    expect(cp.valid).toBeFalse();

    expect(cp.errors).toBeTruthy();

  });

  it('Valid Email', () => {

    let email = component.form.controls['email']

    email.setValue('email')

    expect(email.value).toEqual('email');

  });

  it('Invalid Email', () => {

    let email = component.form.controls['email']

    expect(email.valid).toBeFalse();

    expect(email.errors).toBeTruthy();

  });

  it('Valid Mobile', () => {

    let mobile = component.form.controls['phoneNumber']

    mobile.setValue('phoneNumber');

    expect(mobile.value).toEqual('phoneNumber');

  });

  it('Invalid Mobile', () => {

    let mobile = component.form.controls['phoneNumber']

    expect(mobile.valid).toBeFalse();

    expect(mobile.errors).toBeTruthy();

  });

  it('Valid DOB',()=>{

    let dob=component.form.controls['dateOfBirth']

    dob.setValue(new Date('09/21/2023'));

    expect(dob.value).toEqual(new Date('09/21/2023'));

  });

  it('Invalid DOB', () => {

    let dob = component.form.controls['dateOfBirth']

    expect(dob.valid).toBeTruthy();

    expect(dob.errors).toBeNull();

  });

  it('Valid Gender',()=>{

    let gender=component.form.controls['gender']

    gender.setValue('gender')

    expect(gender.value).toEqual('gender')

  });

  it('Invalid Gender', () => {

    let gender = component.form.controls['gender']

    expect(gender.valid).toBeFalse();

    expect(gender.errors).toBeTruthy();

  });
});
