import { Result } from "./ResultModels"

export interface AuditLog{
    userName: string,
    recordedDateUTC: Date,
    data: string
}

export interface AuditTrailResponse{
    auditLogs: AuditLog[]
}

export interface AuditTrailResponseResult extends Result {
    value: AuditTrailResponse
}