import { Component, OnInit } from '@angular/core';
import { User } from 'src/models/user';
import { HttpService } from 'src/services/http.service';
import { ActivatedRoute } from '@angular/router';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-account-page',
  templateUrl: './account-page.component.html',
  styleUrls: ['./account-page.component.sass']
})
export class AccountPageComponent implements OnInit {

  user: User;
  id: number;

  constructor(private httpService: HttpService, private route: ActivatedRoute) { }

  ngOnInit(): void {

    this.route.paramMap.pipe(
      switchMap(params => params.getAll('id'))
    )
      .subscribe(data => {
        this.id = +data;
        this.httpService.getUser(this.id).subscribe((userData: User) => {
          this.user = userData;
          console.log(this.user);
        });

      });
  }

}


