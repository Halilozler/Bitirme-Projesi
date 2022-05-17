import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Yoklama } from 'src/app/_models/hepsi';

@Component({
  selector: 'app-yoklama-popup',
  templateUrl: './yoklama-popup.component.html',
  styleUrls: ['./yoklama-popup.component.css']
})
export class YoklamaPopupComponent implements OnInit {
  @Input() yoklama?: Yoklama[];
  constructor(private modelServices: NgbModal, private router: Router, private activeModelService: NgbActiveModal) { }

  ngOnInit(): void { }

  yonlendirme(dersSaat_Id: number){
    sessionStorage.setItem("id",dersSaat_Id.toString());
    
    this.router.navigateByUrl("/ogretmen/yoklama");
    this.kapatma();
  }

  kapatma(){
    this.activeModelService.close();
  }

}
