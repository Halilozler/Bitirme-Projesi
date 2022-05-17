import { Component, OnInit } from '@angular/core';
import { DersYoklaması, YoklamaDto } from 'src/app/_models/hepsi';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { OgretmenService } from 'src/app/_services/ogretmen.service';

@Component({
  selector: 'app-yoklama-ogretmen',
  templateUrl: './yoklama-ogretmen.component.html',
  styleUrls: ['./yoklama-ogretmen.component.css']
})
export class YoklamaOgretmenComponent implements OnInit {
  dersSaat_Id!: number;
  derseGelenler?: YoklamaDto[];
  derseGelmeyenler?: YoklamaDto[];
  hepsi?: YoklamaDto[];
  dersYoklama?: DersYoklaması;
  butonaktif: boolean = true;

  constructor(private ogretmenService: OgretmenService, private aletify: AlertifyService) {
    var id =  sessionStorage.getItem("id");
    sessionStorage.removeItem("id");
    if(id != null){
      this.dersSaat_Id = parseInt(id);
    }
  }

  ngOnInit(): void {
    this.yoklamaListesi();
  }

  yoklamaListesi(){
    this.ogretmenService.getYoklama(this.dersSaat_Id).subscribe(x => {
      this.dersYoklama = x;
      this.derseGelenler = this.dersYoklama.derseGelenler;
      this.derseGelenler.forEach(this.dogruEkle);
      this.hepsi = this.derseGelenler;
    })
  }

  duzenle(){
    this.butonaktif = false;
    this.derseGelmeyenler = this.dersYoklama?.derseGelmeyenler;
    this.derseGelmeyenler?.forEach(this.yanlisEkle);

    if(this.derseGelmeyenler != undefined){
      for(let i = 0; i < this.derseGelmeyenler.length; i++){
        this.hepsi?.push(this.derseGelmeyenler[i]);
      }
    }
  }

  ekle(ogrenciId?: number, p?: YoklamaDto){
    //this.dersSaat_Id = buradan gelicek.
    if(ogrenciId && p){
      this.ogretmenService.YoklamaEkle(ogrenciId,this.dersSaat_Id).subscribe(x => {
        p.durum = true;
        this.aletify.success("Yoklamaya Eklendi");
      }, err => {
        this.aletify.error("Hata oluştu.");
      });
    }
  }

  sil(yoklamaId?: number, ogrenciId?: number, p?: YoklamaDto){
    if(p){
      this.ogretmenService.YoklamaSil(yoklamaId,ogrenciId,this.dersSaat_Id).subscribe(x =>{
        p.durum = false;
        this.aletify.success("Yoklamadan silindi");
      }, err => {
        this.aletify.error("Hata oluştu.");
      });
    }
    else{

    }
  }

  dogruEkle(item: YoklamaDto){
    item.durum = true;
  }

  yanlisEkle(item: YoklamaDto){
    item.durum = false;
  }

}
