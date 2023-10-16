import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ScheduleService } from '../services/schedule.service';
@Component({
  selector: 'app-appointmentstatus',
  templateUrl: './appointmentstatus.component.html',
  styleUrls: ['./appointmentstatus.component.css']
})
export class AppointmentstatusComponent implements OnInit {

  Id!:string;
  clinics!:any;
  cliniclist:any[]=[];
  userName!:string
  constructor(private route:ActivatedRoute,private services:ScheduleService,private router:Router)
  { }
  ngOnInit(): void
  { 
    this.route.paramMap.subscribe(params=>
      {
        this.Id=String(params.get('id'));
        console.log(this.Id)
    
      });
      this.userName=localStorage.getItem("userName") as string;
      this.getbyid()
  }
  getbyid()
  {
    this.services.GetById(this.Id).subscribe( response=>{
      console.log(response)
      this.clinics= JSON.parse(response);
     console.log(this.clinics)
    });
  }

}
