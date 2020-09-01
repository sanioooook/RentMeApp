import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BikeForFront } from './bikeForFront';
import { Observable } from 'rxjs';

@Injectable()
export class DataService {

    private url = 'https://localhost:5001/api/bikes';

    constructor(private http: HttpClient) {}
    getBike(id: number): Observable<BikeForFront> {
      return this.http.get<BikeForFront>(this.url + '/' + id);
    }
    getAvailableBikes(): Observable<BikeForFront[]> {
        return this.http.get<BikeForFront[]>(this.url + '/available');
    }
    getRentedBikes(): Observable<BikeForFront[]>{
        return this.http.get<BikeForFront[]>(this.url + '/rented');
    }
    createBike(bikeForFront: BikeForFront): Observable<BikeForFront> {
        return this.http.post(this.url + '/create', bikeForFront);
    }
    updateBike(id: number): Observable<BikeForFront> {
        return this.http.put(this.url + '/status', id);
    }
    deleteBike(id: number): Observable<BikeForFront> {
        return this.http.delete(this.url + '/' + id);
    }
}
