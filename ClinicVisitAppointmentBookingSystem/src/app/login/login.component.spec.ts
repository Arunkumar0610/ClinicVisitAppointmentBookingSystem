import { HttpClient, HttpClientModule } from '@angular/common/http';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { NgModule } from '@angular/core';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ActivatedRoute } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';

import { LoginComponent } from './login.component';

describe('LoginComponent', () => {
  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports:[HttpClientModule,HttpClientTestingModule,RouterTestingModule],
      declarations: [ LoginComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
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
});
