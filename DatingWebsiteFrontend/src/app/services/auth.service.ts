import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseUrl = 'http';

  constructor(private http: HttpClient) { 

    // logIn(user: User) {
    //   return this.http.post(this.baseUrl);
    // }

  }
}
