import { Component, OnInit } from '@angular/core';
import { HttpService } from 'src/services/http.service';
import { Card } from '../../models/Card';

@Component({
  selector: 'app-cards-view',
  templateUrl: './cards-view.component.html',
  styleUrls: ['./cards-view.component.sass']
})
export class CardsViewComponent implements OnInit {

  card: Card;

  constructor(private httpService: HttpService) { }

  ngOnInit(): void {
    this.httpService.getCardOfUser(1).subscribe((data: Card) => {
      this.card = data;
      console.log(this.card);
    });
  }


}
