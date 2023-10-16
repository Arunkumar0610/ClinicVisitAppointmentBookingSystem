import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbDate } from '@ng-bootstrap/ng-bootstrap';
import { AppointmentStatus, ClinicAndServices, ScheduleAppointment } from '../services/Patient';
import { ScheduleService } from '../services/schedule.service';

@Component({
  selector: 'app-schedulevisit',
  templateUrl: './schedulevisit.component.html',
  styleUrls: ['./schedulevisit.component.css']
})
export class SchedulevisitComponent implements OnInit {
  
  form=new FormGroup({
    patientuserName:new FormControl({value:localStorage.getItem('userName'),disabled:true}),
    clinicName:new FormControl({value:'',disabled:true}),
    clinicAddress:new FormControl({value:'',disabled:true}),
    service:new FormControl({value:'',disabled:true}),
    selectedDate:new FormControl(new NgbDate(2023,1,1)),
    selectedTimeSlot:new FormControl(new Date())
  }); 
  Users!:ScheduleAppointment
  clinicdetails!:ClinicAndServices
  id!:string
  Service!:string
  adddetails!:Boolean
  success!:Boolean
  compare!:Boolean
  datestring!:string
  datetimestring!:string
  result!:AppointmentStatus
  timeSlots: string[] = [];
  confirmedSelection: boolean = false;
  constructor(private route:ActivatedRoute,private services:ScheduleService,private router:Router,private datepipe:DatePipe) { 
    this.updateTimeSlots();
  }
  ngOnInit(): void {
    this.route.paramMap.subscribe(params=>
      {
        this.Service=String(params.get('service'));
        this.id=String(params.get('id'));
        console.log(this.Service+" "+this.id)
    
      });
      
    this.adddetails=false;
    this.success=false;
    this.getclinicdetails();
  }
  get patientuserName(){return this.form.get('patientuserName')}
  get clinicName(){return this.form.get('clinicName')}
  get clinicAddress(){return this.form.get('clinicAddress')}
  get service(){return this.form.get('service')}
  get confirmpassword(){return this.form.get('confirmpassword')}
  get selectedDate(){return this.form.get('selectedDate')}
   get selectedTimeSlot(){return this.form.get('selectedTimeSlot')}

  updateTimeSlots() {
    // Implement your logic to generate time slots based on the selected date.

    // For this example, I'll generate a simple list of time slots.

    const hours = 24;

    const interval = 60; // Minutes

    const timeFormat = 'HH:mm'; // Adjust the format as needed.

    this.timeSlots = [];

    for (let i = 0; i < hours * 60; i += interval) {

      const time = new Date();

      time.setHours(Math.floor(i / 60));

      time.setMinutes(i % 60);

      this.timeSlots.push(time.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' }));

    }

  }

  close()
  {
    this.adddetails=false
  }
  closesuccess()
  {
    this.success=false;
  }
  getclinicdetails(){
    this.services.GetClinicById(this.id).subscribe(response=>{
      this.clinicdetails=response as ClinicAndServices;
      console.log(response)
      this.form.controls['clinicName'].patchValue(this.clinicdetails.clinicName)
      this.form.controls['clinicAddress'].patchValue(this.clinicdetails.clinicAddress)
      this.form.controls['service'].patchValue(this.Service)
      this.form.controls['selectedDate'].patchValue(new NgbDate(2023,1,1))
    })
  }
  ScheduleAppointment():void
  {   
    let hours,minutes,AmorPm;
    console.log(this.selectedDate!.value)
    if(this.selectedDate!.value!.month>9){
      if(this.selectedDate!.value!.day>9)
      {
        this.datestring=String(this.selectedDate!.value!.year+"-"+this.selectedDate!.value!.month+"-"+this.selectedDate!.value!.day)
        hours=String(this.selectedTimeSlot!.value).substring(0,2);
        minutes=String(this.selectedTimeSlot!.value).substring(3,5)
        AmorPm=String(this.selectedTimeSlot!.value).substring(6,8)
      }
      else{
        this.datestring=String(this.selectedDate!.value!.year+"-"+this.selectedDate!.value!.month+"-0"+this.selectedDate!.value!.day)
        hours=String(this.selectedTimeSlot!.value).substring(0,2);
        minutes=String(this.selectedTimeSlot!.value).substring(3,5)
        AmorPm=String(this.selectedTimeSlot!.value).substring(6,8)
      }
    }
    else{
      if(this.selectedDate!.value!.day>9)
      {
        this.datestring=String(this.selectedDate!.value!.year+"-0"+this.selectedDate!.value!.month+"-"+this.selectedDate!.value!.day)
        hours=String(this.selectedTimeSlot!.value).substring(0,2);
        minutes=String(this.selectedTimeSlot!.value).substring(3,5)
        AmorPm=String(this.selectedTimeSlot!.value).substring(6,8)
      }
      else{
        this.datestring=String(this.selectedDate!.value!.year+"-0"+this.selectedDate!.value!.month+"-0"+this.selectedDate!.value!.day)
        hours=String(this.selectedTimeSlot!.value).substring(0,2);
        minutes=String(this.selectedTimeSlot!.value).substring(3,5)
        AmorPm=String(this.selectedTimeSlot!.value).substring(6,8)
      }
    }
     
      console.log(this.datestring)
     console.log(hours + " "+minutes+" "+AmorPm)
    if(AmorPm=="PM"){
       hours=String(Number(hours)+12)
        this.datetimestring=this.datestring+"T"+hours+":"+minutes+":00.000Z"
      }
    else{
        this.datetimestring=this.datestring+"T"+hours+":"+minutes+":00.000Z"
    }
     
     console.log(this.datetimestring)
     this.Users={
      patientuserName:this.patientuserName!.value as string,
      clinicName:this.clinicName!.value as string,
      clinicAddress:this.clinicAddress!.value as string,
      service:this.service!.value as string,
      dateTimeOfVisit:new Date(this.datetimestring)
    }  
    console.log(this.Users)
    this.services.ScheduleAppointment(this.Users).subscribe(response=>{
        this.adddetails=false; 
        this.success=true;
        
        this.result=JSON.parse(response) as AppointmentStatus
        console.log(this.result)
       this.router.navigate(['/appointmentstatus',this.result.id as string]);
      },err=>{
        this.adddetails=true;
      }
     )
  } 

}
