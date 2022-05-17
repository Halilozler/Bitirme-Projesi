import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgbAccordion, NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Yoklama } from 'src/app/_models/hepsi';
import { YoklamaEkraniComponent } from '../yoklama-ekrani/yoklama-ekrani.component';

@Component({
  selector: 'app-yoklama',
  templateUrl: './yoklama.component.html',
  styleUrls: ['./yoklama.component.css']
})
export class YoklamaComponent implements OnInit {
  @Input() yoklama?: Yoklama[];
  
  constructor(private modelServices: NgbModal, private router: Router, private activeModelService: NgbActiveModal) { }

  ngOnInit(): void { }
  
  yonlendirme(dersSaat_Id: number){
    sessionStorage.setItem("id",dersSaat_Id.toString());
    
    this.router.navigateByUrl("/yoklama");
    this.kapatma();
  }

  kapatma(){
    this.activeModelService.close();
  }

}
