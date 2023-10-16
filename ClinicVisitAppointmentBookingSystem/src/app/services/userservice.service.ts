import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { LoginRequest, PatientRegister } from './Patient';

@Injectable({
  providedIn: 'root'
})
export class UserserviceService {

  private basePath="https://localhost:7105/api/Users"
  constructor(private http :HttpClient) { }
  
  public LoginUser(user:LoginRequest):Observable<any>{
    return this.http.post(this.basePath+"/login",user,{responseType:"text"});
  }
  public RegisterUser(user:PatientRegister):Observable<any>{
    return this.http.post(this.basePath+"/register",user,{responseType:"text"});
  }
  // public Get():Observable<any>{
  //   return this.http.get(this.basePath+"/all");
  // }
  // public GetById(id:Number):Observable<any>{
  //   return this.http.get(this.basePath+"/"+id);
  // }
  // public GetByUserName(Users:string):Observable<any>{
  //   return this.http.get(this.basePath+"/search/"+Users);
  // }
}
