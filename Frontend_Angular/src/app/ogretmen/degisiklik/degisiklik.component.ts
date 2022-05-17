import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthService } from 'src/app/_services/auth.service';
import { DersForOgretmen } from 'src/app/_models/ogretmen';
import { OgretmenService } from 'src/app/_services/ogretmen.service';
import { GelecekDers } from 'src/app/_models/hepsi';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { AlertifyService } from 'src/app/_services/alertify.service';

@Component({
  selector: 'degisiklik',
  templateUrl: './degisiklik.component.html',
  styleUrls: ['./degisiklik.component.css']
})
export class DegisiklikComponent implements OnInit {
  jwtHelper = new JwtHelperService();
  id!: number;
  dersleri?: DersForOgretmen[]; 
  secilenDers?: number;
  birinciAc: boolean = false;
  gelecekDers?: GelecekDers[];
  secim?: number;

  button1: boolean = true;
  button2: boolean = false;

  time?: NgbDateStruct;

  constructor(private authService: AuthService, private ogretmenService: OgretmenService, private aletify: AlertifyService) { 
    const token = localStorage.getItem("token");
    if(token){
      this.authService.decodedToken = this.jwtHelper.decodeToken(token);
      this.id = parseInt(this.authService.decodedToken.nameid); 
    }

  }

  ngOnInit(): void {
    this.derslerigetir();
    
  }

  derslerigetir(){
    this.ogretmenService.getDers(this.id).subscribe(x => {
      this.dersleri = x;
    })
  }

  dersSecme(){
    if(this.secilenDers != undefined){
      this.ogretmenService.getDerseGoreGelecekGetir(this.secilenDers).subscribe(x => {
        this.gelecekDers = x;
        if(this.gelecekDers.length > 0){
          this.birinciAc = true;
          this.button1 = false;
          this.button2 = true;
        }
        else{//burada uyarı versin.
          this.birinciAc = false;
        }
      })
    }
  }

  iptal(){
    //seçim = DersSaat-id gelicek
    if(this.secim != undefined){
      this.ogretmenService.DersIptal(this.secim).subscribe(x => {
        this.aletify.success("Başarılı Şekilde İptal Edildi");
      })
    }
  }

}
