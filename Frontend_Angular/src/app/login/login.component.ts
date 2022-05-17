import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Auth } from '../_models/hepsi';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  jwtHelper = new JwtHelperService();
  auth: Auth = {
    kullaniciadi: '',
    sifre: ''
  }
  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit(): void {
    /* BU YAPI İLE OLUŞTURULAN TOKEN BİLGİSİNİ DECODE EDEBİLİYORUZ.
    const token = localStorage.getItem("token");
    if(token){
      this.authService.decodedToken = this.jwtHelper.decodeToken(token);
      console.log(this.authService.decodedToken);
    }*/
  }

  login(){
    if(this.auth.kullaniciadi != null && this.auth.sifre != null && this.auth.kullaniciadi != "" && this.auth.sifre != ""){
      this.authService.login(this.auth).subscribe(x => {
        const token = localStorage.getItem("token");
        if(token){
          this.authService.decodedToken = this.jwtHelper.decodeToken(token);
          if(this.authService.decodedToken.role == "ogrenci"){
            this.router.navigate(['/ogrenci']);
            window.location.reload();
          }
          else if(this.authService.decodedToken.role == "ogretmen"){
            this.router.navigate(['/ogretmen']);
            window.location.reload();
          }
          else{
            this.router.navigate(['/admin']);
            window.location.reload();
          }
        }
      },error => {})
    }
  }
}
