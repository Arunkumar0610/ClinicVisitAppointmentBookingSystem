import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ScheduleService } from '../services/schedule.service';

@Component({
  selector: 'app-clinicslist',
  templateUrl: './clinicslist.component.html',
  styleUrls: ['./clinicslist.component.css']
})
export class ClinicslistComponent implements OnInit {

  Service!:string;
  clinics!:any;
  cliniclist:any[]=[];
  constructor(private route:ActivatedRoute,private services:ScheduleService,private router:Router)
  { }
  ngOnInit(): void
  { 
    this.route.paramMap.subscribe(params=>
      {
        this.Service=String(params.get('service'));
        console.log(this.Service)
    
      });
      this.services.GetClinicByServices(this.Service).subscribe( response=>{
        console.log(response)
        this.clinics=response;
       
      });
  }
}
