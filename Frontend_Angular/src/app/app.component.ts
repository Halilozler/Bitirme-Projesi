import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { deCode } from './_models/hepsi';
import { AuthService } from './_services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  deToken?: deCode;

  //ogretmen: boolean = false;
  token: boolean = false;
  
  constructor(private authService: AuthService, private router: Router) {
    
  }

  ngOnInit(): void {
    this.deToken = this.authService.TokenDecode(); //tokenimizi decode yaptık.
    if(this.deToken.id != undefined){
      console.log("girdi");
      this.token = true;
      if(this.deToken.rolu == "admin"){
        this.router.navigateByUrl("/admin"); //sayfalara yönlendiriyoruz.
      }
      else if(this.deToken.rolu == "ogretmen"){
        this.router.navigateByUrl("/ogretmen");
      }
      else{
        this.router.navigateByUrl("/ogrenci");
      }
    }
  }
  
}
