import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Bildirim, DersYoklaması, GelecekDers, Yoklama } from '../_models/hepsi';
import { DersForOgretmen } from '../_models/ogretmen';

@Injectable({
  providedIn: 'root'
})
export class OgretmenService {

  baseUrl: string = "https://localhost:7152/api/Ogretmen/"
  constructor(private http: HttpClient) { }

  getDers(id: number): Observable<DersForOgretmen[]>{
    return this.http.get<DersForOgretmen[]>(this.baseUrl + "ders/" + id);
  }

  getGelecekDers(id: number): Observable<GelecekDers[]>{
    return this.http.get<GelecekDers[]>(this.baseUrl + "gelecek/" + id);
  }

  getGecmisDers(dersId: number): Observable<Yoklama[]>{
    return this.http.get<Yoklama[]>(this.baseUrl + "gecmisders/" + dersId);
  }

  getYoklama(dersSaat_id: number): Observable<DersYoklaması>{
    return this.http.get<DersYoklaması>(this.baseUrl + "yoklama/" + dersSaat_id);
  }

  YoklamaEkle(ogrenciId: number, dersSaatId: number){
    return this.http.post(this.baseUrl + "ekle/" + ogrenciId + "/" + dersSaatId,"");
  }

  YoklamaSil(YoklamaId?: number, ogrenciId?: number, dersId?: number){
    if(!YoklamaId){
      YoklamaId = 0;
    }
    return this.http.post(this.baseUrl + "sil/" + YoklamaId + "/" + ogrenciId + "/" + dersId,"");
  }

  getDerseGoreGelecekGetir(DersId: number): Observable<GelecekDers[]>{
    return this.http.get<GelecekDers[]>(this.baseUrl + "derseGetir/" + DersId);
  }

  DersIptal(Derssaat_id: number){
    return this.http.post(this.baseUrl + "iptal/" + Derssaat_id,"");
  }

  bildirim(Ogretmen_Id: number): Observable<Bildirim[]>{
    return this.http.get<Bildirim[]>(this.baseUrl + "bildirim/" + Ogretmen_Id);
  }
}
