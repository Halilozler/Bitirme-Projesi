import { getLocaleDayPeriods } from '@angular/common';
import { getInterpolationArgsLength } from '@angular/compiler/src/render3/view/util';
import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { getValueInRange } from '@ng-bootstrap/ng-bootstrap/util/util';
import { Ders, DersSaati } from 'src/app/_models/admin';
import { deCode } from 'src/app/_models/hepsi';
import { AdminService } from 'src/app/_services/admin.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-ders-saat-ekle',
  templateUrl: './ders-saat-ekle.component.html',
  styleUrls: ['./ders-saat-ekle.component.css']
})
export class DersSaatEkleComponent implements OnInit {
  token?: deCode;
  ders: Ders[] = [];
  secilenDers?: number;
  a?: number;
  tarihAc: boolean = false;
  selectedDate?: Date;
  min!: string;

  constructor(private adminService: AdminService, private authService: AuthService, private alertify: AlertifyService) {
    this.token = authService.TokenDecode();
  }

  ngOnInit(): void {
    this.getDers();
    this.minTarih();
  }

  minTarih(){
    const date = new Date();
    var yil = date.getFullYear();
    var ay = date.getMonth() + 1;
    var gun = date.getDate();
    
    this.min = yil + "-" + ay + "-" + gun + "T" + "00:00";
  }

  getDers(){
    this.adminService.getDersler().subscribe(x => {
      this.ders = x;
      for(var i=0; i<x.length; i++){
        if(this.ders[i].durum == false){
          this.ders.splice(i,2);
        }
      }
    })
  }

  selectedDers(){
    if(this.secilenDers != this.a){
      this.a = this.secilenDers;
      this.tarihAc = true;
    }
  }

  sec(){
    if(this.secilenDers != undefined && this.selectedDate != undefined){
      const dersSaati = new DersSaati();
      dersSaati.ders_id = this.secilenDers;
      dersSaati.tarih = this.selectedDate;
      this.adminService.DersSaatEkle(dersSaati).subscribe(x => {
        this.alertify.success("Ders Saati Eklendi")
      },error => {
        //console.log(error);
        this.alertify.error(error);
      })
    }
  }


}
