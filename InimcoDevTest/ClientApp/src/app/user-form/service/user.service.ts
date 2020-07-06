import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/user';
import { UserObjectResult } from '../models/user-object-result';

@Injectable({
    providedIn: 'root'
})
export class UserService {
    private apiUrl = "api/users"

    constructor(private httpClient: HttpClient) { }

    getAll(): Observable<User[]> {
        // return this.httpClient.get<Proxy[]>(`test`);
        return this.httpClient.get<User[]>(`${this.apiUrl}`);
    }

    analyseUserData(user: User):  Observable<UserObjectResult> {
        // return this.httpClient.get<Proxy[]>(`test`);
        return this.httpClient.post<UserObjectResult>(`${this.apiUrl}`,user);
    }
}
