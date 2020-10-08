import { Component, OnInit } from '@angular/core';
import { HttpService } from '../../services/http.service';
import {User} from '../../models/user';

@Component({
  selector: 'app-welcome-page',
  templateUrl: './welcome-page.component.html',
  styleUrls: ['./welcome-page.component.sass']
})
export class WelcomePageComponent implements OnInit {

 constructor(){}

  ngOnInit(): void {
  }

}
