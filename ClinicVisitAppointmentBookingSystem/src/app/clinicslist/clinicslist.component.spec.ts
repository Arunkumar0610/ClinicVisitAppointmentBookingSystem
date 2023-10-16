import { HttpClientModule } from '@angular/common/http';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';

import { ClinicslistComponent } from './clinicslist.component';

describe('ClinicslistComponent', () => {
  let component: ClinicslistComponent;
  let fixture: ComponentFixture<ClinicslistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports:[HttpClientModule,HttpClientTestingModule,RouterTestingModule],
      declarations: [ ClinicslistComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClinicslistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
