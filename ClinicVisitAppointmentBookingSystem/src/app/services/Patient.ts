export class Patient{
    Id!:string;
    FirstName!:string;
    LastName!:string;
    Email!:string;
    UserName!:string;
    DateOfBirth!:Date;
    Gender!:string;
    PhoneNumber!:string;
}
export class PatientRegister{
    firstName!:string;
    lastName!:string;
    email!:string;
    userName!:string;
    password!:string;
    confirm_Password!:string;
    dateOfBirth!:Date;
    gender!:string;
    phoneNumber!:string;
}
export class LoginRequest{
    UserName!:string;
    Password!:string;
    constructor(username:string, password:string){
        this.UserName=username;
        this.Password=password;
    }
}

export class ScheduleAppointment{
    patientuserName!: string;
    clinicName!: string;
    clinicAddress!: string;
    service!: string;
    dateTimeOfVisit!: Date;
}

export class ClinicAndServices{
    clinicName!:string;
    clinicAddress!:string;
    services!:Array<string>;
}
export class AppointmentStatus{
    id!:string;
    patientuserName!: string;
    clinicName!: string;
    clinicAddress!: string;
    service!: string;
    dateTimeOfVisit!: Date;
}