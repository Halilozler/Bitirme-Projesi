import { Routes } from "@angular/router";
import { AOgrenciComponent } from "./admin/a-ogrenci/a-ogrenci.component";
import { AOgretmenComponent } from "./admin/a-ogretmen/a-ogretmen.component";
import { DersSaatEkleComponent } from "./admin/ders-saat-ekle/ders-saat-ekle.component";
import { DersComponent } from "./admin/ders/ders.component";
import { AppComponent } from "./app.component";
import { GelecekDersComponent } from "./gelecek-ders/gelecek-ders.component";
import { MainComponent } from "./main/main.component";
import { NotfoundComponent } from "./notfound/notfound.component";
import { HomeComponent } from "./ogrenci/home/home.component";
import { YoklamaEkraniComponent } from "./ogrenci/yoklama-ekrani/yoklama-ekrani.component";
import { DegisiklikComponent } from "./ogretmen/degisiklik/degisiklik.component";
import { DersleriComponent } from "./ogretmen/dersleri/dersleri.component";
import { YoklamaOgretmenComponent } from "./ogretmen/yoklama-ogretmen/yoklama-ogretmen.component";


export const appRoutes: Routes = [
    {path: "", component: AppComponent},
    {path: "main", component: MainComponent},
    {path: "ogrenci", component: HomeComponent},
    {path: "g_ders", component: GelecekDersComponent},
    {path: "yoklama", component: YoklamaEkraniComponent},
    {path: "ogretmen", component: DersleriComponent},
    {path: "ogretmen/yoklama", component: YoklamaOgretmenComponent},
    {path: "ogretmen/degisiklik", component: DegisiklikComponent},
    {path: "admin", component: DersComponent},
    {path: "admin/ogretmen", component: AOgretmenComponent},
    {path: "admin/ogrenci", component: AOgrenciComponent},

    //bunlar dışında bir şey yazıldığında
    {path: "**", component : NotfoundComponent}
];