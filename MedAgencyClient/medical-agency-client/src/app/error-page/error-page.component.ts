import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { AuthService } from 'src/services/auth.service';


@Component({
  selector: 'app-error-page',
  templateUrl: './error-page.component.html',
  styleUrls: ['./error-page.component.sass']
})
export class ErrorPageComponent implements OnInit {

  response: object;
  constructor(private http: HttpClient, private authService: AuthService) { }

  // tslint:disable-next-line:typedef
  ngOnInit() {
    if (this.authService.isLoggedIn()) {
      let headers = new HttpHeaders({
        'Authorization': this.authService.getAuthorizationHeaderValue(),
        responseType: 'text'
      });

      this.http.get<any>("http://localhost:5555/api", { headers: headers })
        .subscribe(
          response => this.response = response,
          err => console.log('angular is trash'));
    } else {
      this.authService.startAuthentication();
    }
  }

}
