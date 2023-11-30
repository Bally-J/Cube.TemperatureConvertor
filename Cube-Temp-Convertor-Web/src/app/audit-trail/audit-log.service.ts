import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { AuditTrailResponseResult } from '../models/AuditModels';

@Injectable({
  providedIn: 'root'
})
export class AuditLogService {
  private apiUrl: string = "https://localhost:7186";

  constructor(private httpClient:HttpClient) { }

  readAuditLogs(): Observable<AuditTrailResponseResult>{
    return this.httpClient.get<AuditTrailResponseResult>(this.apiUrl + "/read-audit-logs");
  }
}
