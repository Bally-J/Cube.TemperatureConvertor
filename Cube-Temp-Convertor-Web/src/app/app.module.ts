import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeModule } from './home/home.module';
import { AuditTrailModule } from './audit-trail/audit-trail.module';
import { ConversionToolModule } from './conversion-tool/conversion-tool.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HomeModule,
    AuditTrailModule,
    ConversionToolModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
