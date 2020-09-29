import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable()
export class HttpService{

    constructor(private http: HttpClient){ }

    // tslint:disable-next-line: typedef
    getData(){
        return this.http.get('assets/user.json');
    }
}
