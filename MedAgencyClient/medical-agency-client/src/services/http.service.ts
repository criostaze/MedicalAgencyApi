import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable()
export class HttpService{

    constructor(private http: HttpClient){ }

    // tslint:disable-next-line: typedef
    getUser(id){
        return this.http.get(`https://localhost:44351/api/users/${id}`);
    }

    // tslint:disable-next-line:typedef
    getCardOfUser(id){
        return this.http.get(`https://localhost:44351/api/cards/${id}`);
    }
}
