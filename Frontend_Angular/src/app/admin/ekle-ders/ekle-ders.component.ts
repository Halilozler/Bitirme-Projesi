import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Bolum, Ders, Ogretim, Ogretmen, Sınıf } from 'src/app/_models/admin';
import { AdminService } from 'src/app/_services/admin.service';
import { IptalpopupComponent } from '../iptalpopup/iptalpopup.component';

@Component({
  selector: 'app-ekle-ders',
  templateUrl: './ekle-ders.component.html',
  styleUrls: ['./ekle-ders.component.css']
})
export class EkleDersComponent implements OnInit {
  bolum?: Bolum[];
  model: Ders= {
    dersId: 0,
    dersKodu: '',
    dersAdi: '',
    durum: true,
    ogretmen_Id: 0,
    bolum_Id: 0,
    ogretim_Id: 0,
    sinif_Id: 0
  };
  a?: number;
  b?: number;
  c?: number;
  secilenBolum?: number;
  secilenOgretmen?: number;
  secilenOgretim?: number;
  secilenSinif?: number;
  ogretmenAc: boolean = false;
  ogretimAc: boolean = false;
  sinifAc:boolean = false;
  ogretmenler?: Ogretmen[];
  ogretim?: Ogretim[];
  sinif?: Sınıf[];

  constructor(private adminService: AdminService, private cdRef: ChangeDetectorRef, private modelServices: NgbModal, private modelActive: NgbActiveModal) { 
    this.getir();
  }

  ngOnInit(): void {
  }

  ekle(){
    if(this.secilenSinif != undefined && this.secilenBolum && this.secilenOgretim && this.secilenOgretmen){
      this.model.bolum_Id = this.secilenBolum;
      this.model.ogretim_Id = this.secilenOgretim;
      this.model.ogretmen_Id = this.secilenOgretmen;
      this.model.sinif_Id = this.secilenSinif;

      this.modelActive.close();

      const modalRef = this.modelServices.open(IptalpopupComponent);
      modalRef.componentInstance.deger = 2;
      modalRef.componentInstance.ders = this.model;
        
    }
    
  }

  getir(){
    this.adminService.getBolum().subscribe(x => {
      this.bolum = x;
    })
  }

  secimBolum(){
    if(this.secilenBolum != this.a){
      this.a = this.secilenBolum;
      this.ogretmenAc = true;
      this.cdRef.detectChanges();

      this.adminService.getBolumeOgretmen(this.secilenBolum).subscribe(x => {
        this.ogretmenler = x;
      })
    }
  }

  secimOgretmen(){
    if(this.secilenOgretmen != this.b){
      this.b = this.secilenOgretmen;
      this.ogretimAc = true;
      this.cdRef.detectChanges();

      this.adminService.getOgretim().subscribe(x => {
        this.ogretim = x;
      })
    }
  }

  secimOgretim(){
    if(this.secilenOgretim != this.c){
      this.c = this.secilenOgretim;
      this.sinifAc = true;
      this.cdRef.detectChanges();

      this.adminService.getSinif().subscribe(x => {
        this.sinif = x;
      })
    }
  }
}
