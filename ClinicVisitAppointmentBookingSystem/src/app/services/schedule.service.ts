import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ScheduleAppointment } from './Patient';

@Injectable({
  providedIn: 'root'
})
export class ScheduleService {
  private basePath="https://localhost:7176/api/Schedules"
  constructor(private http :HttpClient) { }
  
  public GetClinicByServices(service:string):Observable<any>{
    return this.http.get(this.basePath+"/clinics/GetClinicsByService?service="+service,{responseType:"json"});
  }
  public ScheduleAppointment(user:ScheduleAppointment):Observable<any>{
     return this.http.post(this.basePath+"/ScheduleAppointment",user,{responseType:"text"});
   }
   public GetById(id:string)
   {
    return this.http.get(this.basePath+"/GetById?Id="+id,{responseType:"text"});
   }
   public GetClinicById(id:string)
   {
    return this.http.get(this.basePath+"/GetClincById?Id="+id,{responseType:"json"});
   }
}
