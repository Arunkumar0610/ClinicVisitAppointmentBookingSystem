import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import {  Router } from '@angular/router';
import { LoginRequest} from '../services/Patient';
import { UserserviceService } from '../services/userservice.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  invalidLogin!:boolean;
  invalidRole!:boolean;
  user!:LoginRequest
  loginresponse:any
  role!:string
  form=new FormGroup({
  username:new FormControl('',[Validators.required]),
  password:new FormControl('',[Validators.required])
  });
  constructor(private services:UserserviceService,private router:Router,private httpClient:HttpClient) { }

  ngOnInit(): void {
    this.invalidLogin=false;
  }
  get username(){return this.form.get('username');}
  get password(){return this.form.get('password');}
 
  closeinvalidLogin()
  {
    this.invalidLogin=false
  }
  Login()
  {    
    this.user=new LoginRequest(String(this.username!.value),String(this.password!.value));
    console.log(this.user);
    this.services.LoginUser(this.user).subscribe(
      response=>{
        console.log(response);
        this.loginresponse = JSON.parse(response);   
          localStorage.setItem("jwt",this.loginresponse.token);
          localStorage.setItem("email",this.loginresponse.email);
          localStorage.setItem("id",String(this.loginresponse.id));
          localStorage.setItem("userName",this.user.UserName);
          this.invalidLogin=false; 
          this.invalidRole=false;
          this.router.navigate(["/home"]);
        console.log(this.loginresponse.token);
        console.log(this.loginresponse.email);
        console.log(this.loginresponse.id);  
        console.log(this.loginresponse.userName);    
      },err=>{
        this.invalidLogin=true;
      }
    )
  }

}
