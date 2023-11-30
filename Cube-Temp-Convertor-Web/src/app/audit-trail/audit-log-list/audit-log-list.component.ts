import { Component, OnInit } from '@angular/core';
import { AuditLogService } from '../audit-log.service';
import { AuditTrailResponse } from 'src/app/models/AuditModels';

@Component({
  selector: 'app-audit-log-list',
  templateUrl: './audit-log-list.component.html',
  styleUrls: ['./audit-log-list.component.scss']
})
export class AuditLogListComponent implements OnInit {
  public AuditTrailData: AuditTrailResponse | undefined;

  constructor(private auditLogService: AuditLogService){}
  
  ngOnInit(): void {
    this.loadAuditLogs();
  }

  loadAuditLogs(): void{
    this.auditLogService.readAuditLogs().subscribe( res => {
      if(!res.isSuccess){
        console.error(res.error);
      }

      this.AuditTrailData = res.value;
    })
  }
}
