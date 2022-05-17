import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { DersSaatEkleComponent } from '../admin/ders-saat-ekle/ders-saat-ekle.component';
import { deCode } from '../_models/hepsi';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  jwtHelper = new JwtHelperService();
  token?: deCode;
  ogretmen: boolean = false;
  ogrenci: boolean = false;
  admin: boolean = false;
  constructor(private authService: AuthService, private modelServices: NgbModal) { 
    this.token = authService.TokenDecode();
  }

  ngOnInit(): void {
    if(this.token){
      if(this.token.rolu == "admin"){
        this.admin = true;
      }
      else if(this.token.rolu == "ogretmen"){
        this.ogretmen = true;
      }
      else if(this.token.rolu == "ogrenci"){
        this.ogrenci = true;
      }
    }

    /*
    const token = localStorage.getItem("token");
    if(token){
      this.authService.decodedToken = this.jwtHelper.decodeToken(token);
      if(this.authService.decodedToken.role == "admin"){
        this.admin = true;
      }
      else if(this.authService.decodedToken.role == "ogretmen"){
        this.ogretmen = true;
      }
      else{
        this.ogrenci = true;
      }
    }*/
  }

  cikis(){
    localStorage.removeItem("token");
    window.location.reload();
  }

  dersSaat(){
    if(this.token?.rolu == "admin"){
      const modalRef = this.modelServices.open(DersSaatEkleComponent);
    }
  }

}
