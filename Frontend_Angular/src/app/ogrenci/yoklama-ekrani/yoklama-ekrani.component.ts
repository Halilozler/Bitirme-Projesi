import { Component, Input, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { YoklamaDto } from 'src/app/_models/hepsi';
import { OgrenciService } from 'src/app/_services/ogrenci.service';

@Component({
  selector: 'app-yoklama-ekrani',
  templateUrl: './yoklama-ekrani.component.html',
  styleUrls: ['./yoklama-ekrani.component.css']
})
export class YoklamaEkraniComponent implements OnInit {
  dersSaat_Id!: number;
  yoklama?: YoklamaDto[];
  
  constructor(private ogrenciService: OgrenciService) { 
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
    this.ogrenciService.getYoklama(this.dersSaat_Id).subscribe(x => {
      this.yoklama = x;
      for(var i= 0; i < this.yoklama.length; i++){
        this.yoklama[i].numara = i+1;
      }
    })
    
  }

}
