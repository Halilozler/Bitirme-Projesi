import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Bolum, Ders, DersEkle, DersSaati, Ogrenci, Ogretim, Ogretmen, Sınıf } from '../_models/admin';
import { Bildirim } from '../_models/hepsi';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  //bizim backendimizin adresi:
  baseUrl: string = "https://localhost:7152/api/Admin/"
  constructor(private http: HttpClient) { }

  getBolum(): Observable<Bolum[]>{
    return this.http.get<Bolum[]>(this.baseUrl + "bolum");
  }

  getSinif(): Observable<Sınıf[]>{
    return this.http.get<Sınıf[]>(this.baseUrl + "sinif");
  }

  getOgretim(): Observable<Ogretim[]>{
    return this.http.get<Ogretim[]>(this.baseUrl + "ogretim");
  }

  getBildirim(): Observable<Bildirim[]>{
    return this.http.get<Bildirim[]>(this.baseUrl + "bildirim");
  }

  getBolumeOgretmen(bolumId?: number): Observable<Ogretmen[]>{
    return this.http.get<Ogretmen[]>(this.baseUrl + "bolumOgretmen/" + bolumId);
  }

  getOgretmenler(ogretmenAd?: string): Observable<Ogretmen[]>{
    if(ogretmenAd){
      if(ogretmenAd.replace(/\s/g,"") != ""){
        return this.http.get<Ogretmen[]>(this.baseUrl + "ogretmenler/" + ogretmenAd);
      }
    }
    return this.http.get<Ogretmen[]>(this.baseUrl + "ogretmenler/" + "987");
  }

  getOgrenciler(OgrenciAd?: string): Observable<Ogrenci[]>{
    if(OgrenciAd){
      if(OgrenciAd.replace(/\s/g,"") != ""){
        return this.http.get<Ogrenci[]>(this.baseUrl + "ogrenciler/" + OgrenciAd);
      }
    }
    return this.http.get<Ogrenci[]>(this.baseUrl + "ogrenciler/" + "987");
  }

  getDersler(dersAd?: string): Observable<Ders[]>{
    if(dersAd){
      if(dersAd.replace(/\s/g,"") != ""){
        return this.http.get<Ders[]>(this.baseUrl + "dersler/" + dersAd);
      }
    }
    return this.http.get<Ders[]>(this.baseUrl + "dersler/" + "987");
  }

  DersSil(dersId: number, adminId: number, sifre: string){
    return this.http.post(this.baseUrl + "dersSil/" + dersId + "/" + adminId + "/" + sifre,"");
  }

  DersEkle(ders: DersEkle, adminId: number, sifre: string){
    return this.http.post(this.baseUrl + "dersEkle/" + adminId + "/" + sifre,ders);
  }

  DersSaatEkle(ders: DersSaati){
    return this.http.post(this.baseUrl + "dersSaatEkle",ders);
  }
}
