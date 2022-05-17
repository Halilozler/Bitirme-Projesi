import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { YoklamaComponent } from 'src/app/ogrenci/yoklama/yoklama.component';
import { Yoklama } from 'src/app/_models/hepsi';
import { DersForOgretmen } from 'src/app/_models/ogretmen';
import { AuthService } from 'src/app/_services/auth.service';
import { OgretmenService } from 'src/app/_services/ogretmen.service';
import { YoklamaPopupComponent } from '../yoklama-popup/yoklama-popup.component';

@Component({
  selector: 'app-dersleri',
  templateUrl: './dersleri.component.html',
  styleUrls: ['./dersleri.component.css']
})
export class DersleriComponent implements OnInit {
  jwtHelper = new JwtHelperService();
  dersler?: DersForOgretmen[];
  yoklama?: Yoklama[];
  id!: number;
  constructor(private ogretmenService: OgretmenService, private modelServices: NgbModal, private authService: AuthService) { }

  ngOnInit(): void {
    const token = localStorage.getItem("token");
    if(token){
      this.authService.decodedToken = this.jwtHelper.decodeToken(token);
      this.id = parseInt(this.authService.decodedToken.nameid); 
    }
    this.getDersler();
  }

  getDersler(){
    this.ogretmenService.getDers(this.id).subscribe(x => {
      this.dersler = x;
    });
  }

  select(p: number){
    this.ogretmenService.getGecmisDers(p).subscribe(x => {
      this.yoklama = x;
      
      if(this.yoklama.length > 0){
        const modalRef = this.modelServices.open(YoklamaPopupComponent);
        modalRef.componentInstance.yoklama = this.yoklama;
      }else{
        
      }

    })
    
  }

}
