export interface Result {
    isSuccess: boolean,
    error: Error
}

export interface Error {
    code:string,
    message:string
}