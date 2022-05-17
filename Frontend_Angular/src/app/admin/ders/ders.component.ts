import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Ders } from 'src/app/_models/admin';
import { deCode } from 'src/app/_models/hepsi';
import { AdminService } from 'src/app/_services/admin.service';
import { AuthService } from 'src/app/_services/auth.service';
import { EkleDersComponent } from '../ekle-ders/ekle-ders.component';
import { IptalpopupComponent } from '../iptalpopup/iptalpopup.component';

@Component({
  selector: 'app-ders',
  templateUrl: './ders.component.html',
  styleUrls: ['./ders.component.css']
})
export class DersComponent implements OnInit {
  token?: deCode;
  dersler?: Ders[];
  oDersler: Ders[] = []
  isChecked?: boolean;
  kelime?: string;
  hepsiniGoster: boolean = false;
  iptalAc: boolean = false;

  constructor(private adminService: AdminService, private authService: AuthService, private modelServices: NgbModal) { 
    this.token = authService.TokenDecode();
    this.getDersler();
  }

  ngOnInit(): void {
    
  }
  

  getDersler(){
    this.oDersler = [];
    this.adminService.getDersler(this.kelime).subscribe(x => {
      this.dersler = x;
      for (let i = 0; i < this.dersler.length; i++) {
        if(this.dersler[i].durum == true){
          this.oDersler.push(this.dersler[i]);
        }
      }
    })
  }
  iptalDersler(){
    if(this.isChecked){
      this.hepsiniGoster = true;
    }else{
      this.hepsiniGoster = false;
    }
  }

  iptalSekme(){
    if(this.iptalAc == false)
      this.iptalAc = true;
    else
    this.iptalAc = false;
  }

  iptal(p:number){
    const modalRef = this.modelServices.open(IptalpopupComponent);
    modalRef.componentInstance.id = p;
    modalRef.componentInstance.deger = 1;
  }

  ekle(){
    const modalRef = this.modelServices.open(EkleDersComponent);
  }

}
