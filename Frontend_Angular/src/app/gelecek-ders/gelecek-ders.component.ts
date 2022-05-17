import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { GelecekDers } from '../_models/hepsi';
import { AuthService } from '../_services/auth.service';
import { OgrenciService } from '../_services/ogrenci.service';
import { OgretmenService } from '../_services/ogretmen.service';

@Component({
  selector: 'app-gelecek-ders',
  templateUrl: './gelecek-ders.component.html',
  styleUrls: ['./gelecek-ders.component.css']
})
export class GelecekDersComponent implements OnInit {
  jwtHelper = new JwtHelperService();;
  id!: number;
  rolü!: string;
  dersler?: GelecekDers[];
  constructor(private authService: AuthService, private ogretmenService: OgretmenService, private serviceOgrenci: OgrenciService) {
    const token = localStorage.getItem("token");
    if(token){
      this.authService.decodedToken = this.jwtHelper.decodeToken(token);
      this.id = parseInt(this.authService.decodedToken.nameid); 
      this.rolü = this.authService.decodedToken.role;
    }
  }

  ngOnInit(): void {
    if(this.rolü == "ogretmen"){
      this.getDersOgretmen();
    }
    else if(this.rolü == "ogrenci"){
      this.getDersOgrenci();
    }
  }

  getDersOgrenci(){
    this.serviceOgrenci.getGelecek(this.id).subscribe(x => {
      this.dersler = x;
    })
  }

  getDersOgretmen(){
    this.ogretmenService.getGelecekDers(this.id).subscribe(x => {
      this.dersler = x;
    })
  }
}
