import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Ders, DersEkle } from 'src/app/_models/admin';
import { deCode } from 'src/app/_models/hepsi';
import { AdminService } from 'src/app/_services/admin.service';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-iptalpopup',
  templateUrl: './iptalpopup.component.html',
  styleUrls: ['./iptalpopup.component.css']
})
export class IptalpopupComponent implements OnInit {
  sifre!: string;
  token!: deCode;
  @Input() id!: number;
  @Input() ders!: Ders;
  @Input() deger?: number;

  constructor(private authService: AuthService, private adminService: AdminService, private ngModel: NgbActiveModal) { 
    this.token = authService.TokenDecode();
  }

  ngOnInit(): void {
  }

  onayla(){
    if(this.deger == 1){
      this.adminService.DersSil(this.id,this.token.id,this.sifre).subscribe(x => {
        console.log("başarılı");
        this.ngModel.close();
      }, (error => {
        console.log("şifre yanlış");
      }))
    }
    else if(this.deger == 2){
      var dersEkle = new DersEkle();
      dersEkle.ders_Kodu = this.ders.dersKodu;
      dersEkle.ders_Adi = this.ders.dersAdi;
      dersEkle.durum = true;
      dersEkle.ogretmen_Id = this.ders.ogretmen_Id;
      dersEkle.bolum_Id = this.ders.bolum_Id;
      dersEkle.ogretim_Id = this.ders.ogretim_Id;
      dersEkle.sinif_Id = this.ders.sinif_Id;
      this.adminService.DersEkle(dersEkle,this.token.id,this.sifre).subscribe(x => {
        console.log("başarılı");
        this.ngModel.close();
      })
    }
    
  }

}
