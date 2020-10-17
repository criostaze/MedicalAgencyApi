import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { switchMap } from 'rxjs/operators';
import { HttpService } from 'src/services/http.service';
import { Card } from '../../models/Card';

@Component({
  selector: 'app-cards-view',
  templateUrl: './cards-view.component.html',
  styleUrls: ['./cards-view.component.sass']
})
export class CardsViewComponent implements OnInit {

  card: Card;
  id: number;

  constructor(private httpService: HttpService, private route: ActivatedRoute) { }

  ngOnInit(): void {

    this.route.paramMap.pipe(
      switchMap(params => params.getAll('id'))
    )
      .subscribe(data => {
        this.id = +data;
        this.httpService.getCardOfUser(this.id).subscribe((cardData: Card) => {
          this.card = cardData;
          console.log(this.card);
        });
      });
  }

}
