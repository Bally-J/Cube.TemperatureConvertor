import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ConvertTemperatureFormComponent } from './conversion-tool/convert-temperature-form/convert-temperature-form.component';
import { AuditLogListComponent } from './audit-trail/audit-log-list/audit-log-list.component';

const routes: Routes = [
  {path: "", component:HomeComponent},
  {path: "temperature-convertor", component:ConvertTemperatureFormComponent},
  {path: "audit-logs", component: AuditLogListComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }