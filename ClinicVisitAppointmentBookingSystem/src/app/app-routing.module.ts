import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppointmentstatusComponent } from './appointmentstatus/appointmentstatus.component';
import { ClinicslistComponent } from './clinicslist/clinicslist.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { SchedulevisitComponent } from './schedulevisit/schedulevisit.component';
import { AuthGuard } from './services/auth.guard';
import { ServicetypesComponent } from './servicetypes/servicetypes.component';
import { SignupComponent } from './signup/signup.component';

const routes: Routes = [{path:"",redirectTo:"/login",pathMatch:"full"},
{path:"login",component:LoginComponent},
{path:"signup",component:SignupComponent},
{path:"home",component:HomeComponent,canActivate:[AuthGuard]},
{path:"scheduleappointment",component:ServicetypesComponent,canActivate:[AuthGuard]},
{path:"clinics/:service",component:ClinicslistComponent,canActivate:[AuthGuard]},
{path:"schedulevisit/:id/:service",component:SchedulevisitComponent,canActivate:[AuthGuard]},
{path:"appointmentstatus/:id",component:AppointmentstatusComponent,canActivate:[AuthGuard]}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
