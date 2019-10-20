import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  baseUrl = 'http://localhost:5000/api/users';

  constructor(private httpClient: HttpClient) { }


}
