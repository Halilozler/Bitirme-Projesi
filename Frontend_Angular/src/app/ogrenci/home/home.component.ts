import { Component, Input, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Yoklama } from 'src/app/_models/hepsi';
import { DersForOgrenci } from 'src/app/_models/ogrenci';
import { AuthService } from 'src/app/_services/auth.service';
import { OgrenciService } from 'src/app/_services/ogrenci.service';
import { YoklamaComponent } from '../yoklama/yoklama.component';

@Component({
  selector: 'ogrenci-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  jwtHelper = new JwtHelperService();;
  id!: number;
  dersler?: DersForOgrenci[];
  yoklama?: Yoklama[]; 
  varmi?: boolean;

  constructor(private ogrenciService: OgrenciService, private modelServices: NgbModal, private authService: AuthService) {
    const token = localStorage.getItem("token");
    if(token){
      this.authService.decodedToken = this.jwtHelper.decodeToken(token);
      this.id = parseInt(this.authService.decodedToken.nameid); 
    }
  }

  ngOnInit(): void {
    this.getDersler();
  }

  getDersler(){
    this.ogrenciService.getDers(this.id).subscribe(x => {
      this.dersler = x;
    });
  }

  select(p: number){
    this.ogrenciService.getGecmisDers(p,this.id).subscribe(x => {
      this.yoklama = x;
      
      if(this.yoklama.length > 0){
        this.varmi = true;
      }else{
        this.varmi = false;
      }

      if(this.varmi == true){
        const modalRef = this.modelServices.open(YoklamaComponent);
        modalRef.componentInstance.yoklama = this.yoklama;
        modalRef.componentInstance.varmi = this.varmi;
      }
      else{
        //burada error versin.
      }
      
    })
    
  }
}
