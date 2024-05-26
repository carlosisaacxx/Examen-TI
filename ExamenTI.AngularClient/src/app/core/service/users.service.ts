import { HttpClient } from "@angular/common/http";
import { Injectable, inject } from "@angular/core";
import { appsettings } from "../settings/appsettings";
import { CreateUser } from "../models/users.interface";

@Injectable({
    providedIn: 'root'
})

export class UsersService{
    private http = inject(HttpClient);
    private apiUrl:string = appsettings.apiUrl + "users"

    constructor(){}

    CreateUser(user: CreateUser) {
        return this.http.post<CreateUser>(`${this.apiUrl}/create/`, user);
      }
}