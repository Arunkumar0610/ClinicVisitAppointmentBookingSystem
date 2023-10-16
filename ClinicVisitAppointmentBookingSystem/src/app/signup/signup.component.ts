
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import {  PatientRegister } from '../services/Patient';
import { UserserviceService } from '../services/userservice.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  form=new FormGroup({
    firstname:new FormControl('',[Validators.required,Validators.minLength(5),Validators.maxLength(20)]),
    lastname:new FormControl('',[Validators.required,Validators.minLength(5),Validators.maxLength(20)]),
    username:new FormControl('',[Validators.required]),
    password:new FormControl('',[Validators.required,
      Validators.pattern("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[!@#$%^&*()_+=;:<>|./?,-]).{8,15}$")]),
    confirmpassword:new FormControl('',[Validators.required]),
    email:new FormControl('',[Validators.required,Validators.email]),
    phoneNumber:new FormControl('',[Validators.required,Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")]), 
    dateOfBirth:new FormControl(new Date(),[Validators.required]),
    gender:new FormControl('',[Validators.required])
  }); 
  Users!:PatientRegister
  adddetails!:Boolean
  success!:Boolean
  compare!:Boolean
  constructor(private route:ActivatedRoute,private services:UserserviceService,private router:Router) { }
  ngOnInit(): void {
    this.adddetails=false;
    this.success=false;
    this.form.valueChanges.subscribe(frm=>{
      const pass=frm.password;
      const conpass=frm.confirmpassword;
      if(pass!==conpass)
      {
        this.form.get('confirmpassword')?.setErrors({noMatched:true});
      }
      else{
        this.form.get('confirmpassword')?.setErrors(null);
      }
    });
  }
  get firstname(){return this.form.get('firstname')}
  get lastname(){return this.form.get('lastname')}
  get username(){return this.form.get('username')}
  get password(){return this.form.get('password')}
  get confirmpassword(){return this.form.get('confirmpassword')}
  get email(){return this.form.get('email')}
  get phoneNumber(){return this.form.get('phoneNumber')}
  get dateOfBirth(){return this.form.get('dateOfBirth')}
  get gender(){return this.form.get('gender')}
  close()
  {
    this.adddetails=false
  }
  closesuccess()
  {
    this.success=false;
  }
  UserRegistration():void
  {
     this.Users={
      firstName:this.firstname!.value as string,
      lastName:this.lastname!.value as string,
      userName:this.username!.value as string,
      password:this.password!.value as string,
      confirm_Password:this.confirmpassword!.value as string,
      email:this.email!.value as string,
      phoneNumber:this.phoneNumber!.value as string,
      dateOfBirth:this.dateOfBirth!.value as Date,
      gender:this.gender!.value as string
    }  
    this.services.RegisterUser(this.Users).subscribe(response=>{
        this.adddetails=false; 
        this.success=true;
        console.log(this.Users)
        setTimeout(()=>{
          this.success=false
          this.router.navigate(['/login'])
        },5000);
      },err=>{
        this.adddetails=true;
      }
      )
  } 

}
