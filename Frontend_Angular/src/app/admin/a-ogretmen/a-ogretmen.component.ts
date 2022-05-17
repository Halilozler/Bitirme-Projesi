import { Component, OnInit } from '@angular/core';
import { Ogretmen } from 'src/app/_models/admin';
import { deCode } from 'src/app/_models/hepsi';
import { AdminService } from 'src/app/_services/admin.service';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-a-ogretmen',
  templateUrl: './a-ogretmen.component.html',
  styleUrls: ['./a-ogretmen.component.css']
})
export class AOgretmenComponent implements OnInit {
  token?: deCode;
  Ogretmen?: Ogretmen[];
  oOgretmen: Ogretmen[] = [];
  isChecked?: boolean;
  kelime?: string;
  hepsiniGoster: boolean = false;

  constructor(private adminService: AdminService, private authService: AuthService) { 
    this.token = authService.TokenDecode();
  }

  ngOnInit(): void {
    this.getOgretmen();
  }

  getOgretmen(){
    this.oOgretmen = [];
    this.adminService.getOgretmenler(this.kelime).subscribe(x => {
      this.Ogretmen = x;
      for (let i = 0; i < this.Ogretmen.length; i++) {
        if(this.Ogretmen[i].durum == true){
          this.oOgretmen.push(this.Ogretmen[i]);
        }
      }
    })
  }
  iptalOgretmen(){
    if(this.isChecked){
      this.hepsiniGoster = true;
    }else{
      this.hepsiniGoster = false;
    }
  }

}
