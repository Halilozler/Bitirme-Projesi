import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { map } from 'rxjs';
import { Auth, deCode } from '../_models/hepsi';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseUrl: string = "https://localhost:7152/api/Auth/"
  jwtHelper = new JwtHelperService(); //npm install @auth0/angular-jwt kurduk.
  decodedToken: any;

  constructor(private http: HttpClient) { }

  login(model: Auth){
    return this.http.post(this.baseUrl + "login",model).pipe(
      map((response: any) => {
        const result = response;
        if(result){
          //tokken bilgisini alıyoruz
          localStorage.setItem("token",result.token);

          this.decodedToken = this.jwtHelper.decodeToken(result.token);
        }
      })
    );
  }

  TokenDecode(){
    const token = localStorage.getItem("token");
    var result = new deCode();
    if(token){
      this.decodedToken = this.jwtHelper.decodeToken(token);
      result.id = parseInt(this.decodedToken.nameid); 
      result.rolu = this.decodedToken.role;
    }
    return result;
  }
}
