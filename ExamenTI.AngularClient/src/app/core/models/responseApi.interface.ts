import { HttpStatusCode } from "@angular/common/http";

export interface ResponseApi {
    IsSuccess: boolean,
    results: object,
    statusCode: HttpStatusCode,
    ErrorMessages: []
}