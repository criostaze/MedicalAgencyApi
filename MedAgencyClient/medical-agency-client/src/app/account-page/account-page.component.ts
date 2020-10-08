import { Component, OnInit } from '@angular/core';
import { User } from 'src/models/user';
import { HttpService } from 'src/services/http.service';
import { HttpClient, HttpClientModule, HttpHandler } from '@angular/common/http';

@Component({
  selector: 'app-account-page',
  templateUrl: './account-page.component.html',
  styleUrls: ['./account-page.component.sass']
})
export class AccountPageComponent implements OnInit {

  user: User;

  constructor(private httpService: HttpService) { }

  ngOnInit(): void {
    this.httpService.getData('/assets/userTest.json').subscribe((data: User) => this.user = data);
  }

}
