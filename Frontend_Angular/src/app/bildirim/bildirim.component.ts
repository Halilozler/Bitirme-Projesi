import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Bildirim, deCode } from '../_models/hepsi';
import { AuthService } from '../_services/auth.service';
import { OgretmenService } from '../_services/ogretmen.service';
import { OgrenciService } from '../_services/ogrenci.service';
import { AdminService } from '../_services/admin.service';

@Component({
  selector: 'bildirim',
  templateUrl: './bildirim.component.html',
  styleUrls: ['./bildirim.component.css']
})
export class BildirimComponent implements OnInit {
  token?: deCode;
  bildirim?: Bildirim[];
  bildirimKontrol: boolean = false;

  constructor(private authService: AuthService, private ogretmenService: OgretmenService, 
    private ogrenciService: OgrenciService, private adminService: AdminService) {
    this.token = authService.TokenDecode();
  }

  ngOnInit(): void {
    if(this.token?.rolu == "ogretmen"){
      this.ogretmenService.bildirim(this.token.id).subscribe(x => {
        if(x.length > 0){
          this.bildirim = x;
          this.bildirimKontrol = true;
        }
      })
    }
    else if(this.token?.rolu == "ogrenci"){
      this.ogrenciService.getBildirim(this.token.id).subscribe(x => {
        if(x.length > 0){
          this.bildirim = x;
          this.bildirimKontrol = true;
        }
      })
    }
    else if(this.token?.rolu == "admin"){
      this.adminService.getBildirim().subscribe(x => {
        if(x.length > 0){
          this.bildirim = x;
          this.bildirimKontrol = true;
        }
      })
    }
  }

}
