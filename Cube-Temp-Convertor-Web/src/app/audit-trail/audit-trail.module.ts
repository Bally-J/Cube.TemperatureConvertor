import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuditLogListComponent } from './audit-log-list/audit-log-list.component';
import { HomeModule } from '../home/home.module';
import { HttpClientModule } from '@angular/common/http';



@NgModule({
  declarations: [
    AuditLogListComponent,
  ],
  imports: [
    CommonModule,
    HomeModule,
    HttpClientModule,
  ]
})
export class AuditTrailModule { }
