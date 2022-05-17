import { Component, OnInit } from '@angular/core';
import { Ogrenci } from 'src/app/_models/admin';
import { deCode } from 'src/app/_models/hepsi';
import { AdminService } from 'src/app/_services/admin.service';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-a-ogrenci',
  templateUrl: './a-ogrenci.component.html',
  styleUrls: ['./a-ogrenci.component.css']
})
export class AOgrenciComponent implements OnInit {
  token?: deCode;
  ogrenci?: Ogrenci[];
  oogrenci: Ogrenci[] = []
  isChecked?: boolean;
  kelime?: string;
  hepsiniGoster: boolean = false;

  constructor(private adminService: AdminService, private authService: AuthService) { 
    this.token = authService.TokenDecode();
  }

  ngOnInit(): void {
    this.getOgrenci();
  }

  getOgrenci(){
    this.oogrenci = [];
    this.adminService.getOgrenciler(this.kelime).subscribe(x => {
      this.ogrenci = x;
      for (let i = 0; i < this.ogrenci.length; i++) {
        if(this.ogrenci[i].durum != false){
          this.oogrenci.push(this.ogrenci[i]);
        }
      }
    })
  }
  iptalOgrenci(){
    if(this.isChecked){
      this.hepsiniGoster = true;
    }else{
      this.hepsiniGoster = false;
    }
  }
}
