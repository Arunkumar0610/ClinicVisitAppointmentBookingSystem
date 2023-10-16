import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { HomeComponent } from './home/home.component';
import { JwtHelperService, JwtModule } from '@auth0/angular-jwt';
import { ServicetypesComponent } from './servicetypes/servicetypes.component';
import { NavbarComponent } from './navbar/navbar.component';
import { ClinicslistComponent } from './clinicslist/clinicslist.component';
import { SchedulevisitComponent } from './schedulevisit/schedulevisit.component';
import { DatePipe } from '@angular/common';
import { AppointmentstatusComponent } from './appointmentstatus/appointmentstatus.component';
import { FontAwesomeModule,FaIconLibrary } from '@fortawesome/angular-fontawesome'
import { fas } from '@fortawesome/free-solid-svg-icons';
import { far } from '@fortawesome/free-regular-svg-icons';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
export function tokenGetter(){
  return localStorage.getItem("jwt");
}

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    SignupComponent,
    HomeComponent,
    ServicetypesComponent,
    NavbarComponent,
    ClinicslistComponent,
    SchedulevisitComponent,
    AppointmentstatusComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    FontAwesomeModule,
    JwtModule.forRoot({
      config:{
        tokenGetter:tokenGetter,
        allowedDomains:["http://localhost:7105"],
        disallowedRoutes:[]
      }
    }),
    NgbModule

  ],
  providers: [JwtHelperService,DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor(library: FaIconLibrary) {
    library.addIconPacks(fas, far);}
 }
