import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Bildirim, GelecekDers, Yoklama, YoklamaDto } from '../_models/hepsi';
import { DersForOgrenci } from '../_models/ogrenci';

@Injectable({
  providedIn: 'root'
})
export class OgrenciService {

  baseUrl: string = "https://localhost:7152/api/Ogrenci/"
  constructor(private http: HttpClient) { }

  getDers(id: number): Observable<DersForOgrenci[]>{
    return this.http.get<DersForOgrenci[]>(this.baseUrl + "dersgetir/" + id);
  }

  getGelecek(id: number): Observable<GelecekDers[]>{
    return this.http.get<GelecekDers[]>(this.baseUrl + "gelecek/" + id);
  }

  getBildirim(id: number): Observable<Bildirim[]>{
    return this.http.get<Bildirim[]>(this.baseUrl + "bildirim/" + id);
  }

  getGecmisDers(dersId: number, ogrenciId: number): Observable<Yoklama[]>{
    return this.http.get<Yoklama[]>(this.baseUrl + "gecmisders/" + dersId + "/" + ogrenciId);
  }

  getYoklama(dersSaat_Id: number): Observable<YoklamaDto[]>{
    return this.http.get<YoklamaDto[]>(this.baseUrl + "yoklama/" + dersSaat_Id);
  }
}
