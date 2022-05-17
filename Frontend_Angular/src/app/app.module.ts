import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from "@angular/common/http"
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HomeComponent } from './ogrenci/home/home.component';
import { BildirimComponent } from './bildirim/bildirim.component';
import { GelecekDersComponent } from './gelecek-ders/gelecek-ders.component';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { YoklamaComponent } from './ogrenci/yoklama/yoklama.component';
import { YoklamaEkraniComponent } from './ogrenci/yoklama-ekrani/yoklama-ekrani.component';
import { LoginComponent } from './login/login.component';
import { MainComponent } from './main/main.component';
import { FormsModule } from '@angular/forms';
import { HashLocationStrategy, LocationStrategy } from '@angular/common';
import { DersleriComponent } from './ogretmen/dersleri/dersleri.component';
import { YoklamaPopupComponent } from './ogretmen/yoklama-popup/yoklama-popup.component';
import { YoklamaOgretmenComponent } from './ogretmen/yoklama-ogretmen/yoklama-ogretmen.component';
import { DegisiklikComponent } from './ogretmen/degisiklik/degisiklik.component';
import { DersComponent } from './admin/ders/ders.component';
import { AOgretmenComponent } from './admin/a-ogretmen/a-ogretmen.component';
import { AOgrenciComponent } from './admin/a-ogrenci/a-ogrenci.component';
import { IptalpopupComponent } from './admin/iptalpopup/iptalpopup.component';
import { EkleDersComponent } from './admin/ekle-ders/ekle-ders.component';
import { DersSaatEkleComponent } from './admin/ders-saat-ekle/ders-saat-ekle.component';
import { DlDateTimeDateModule, DlDateTimePickerModule } from 'angular-bootstrap-datetimepicker';
import { NotfoundComponent } from './notfound/notfound.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    BildirimComponent,
    GelecekDersComponent,
    YoklamaComponent,
    YoklamaEkraniComponent,
    LoginComponent,
    MainComponent,
    DersleriComponent,
    YoklamaPopupComponent,
    YoklamaOgretmenComponent,
    DegisiklikComponent,
    DersComponent,
    AOgretmenComponent,
    AOgrenciComponent,
    IptalpopupComponent,
    EkleDersComponent,
    DersSaatEkleComponent,
    NotfoundComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    NgbModule,
    FormsModule,
    DlDateTimeDateModule,  // <--- Determines the data type of the model
    DlDateTimePickerModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
