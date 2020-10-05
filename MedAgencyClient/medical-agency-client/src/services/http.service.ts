import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable()
export class HttpService{

    constructor(private http: HttpClient){ }

    // tslint:disable-next-line: typedef
    getData(url){
        return this.http.get(url);
    }
}
