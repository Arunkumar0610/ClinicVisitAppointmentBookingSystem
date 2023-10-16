import { HttpEvent, HttpHandler, HttpRequest } from '@angular/common/http';
import { Injectable, Injector } from '@angular/core';
import { Observable } from 'rxjs';
import { ScheduleService } from './schedule.service';

@Injectable({
  providedIn: 'root'
})
export class TokenInterceptorService {

  constructor(private inject:Injector) { }
  intercept(req:HttpRequest<any>,next:HttpHandler):Observable<HttpEvent<any>>{
    let service=this.inject.get(ScheduleService);
    let jwtToken=req.clone({
      setHeaders:{
        Authorization: 'Bearer '+localStorage.getItem('jwt')||''
      }
    });
    return next.handle(jwtToken);
}
}
