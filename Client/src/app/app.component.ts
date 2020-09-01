import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { DataService } from './data.service';
import { BikeForFront } from './bikeForFront';

@Component({
    // tslint:disable-next-line: component-selector
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    encapsulation: ViewEncapsulation.None,
    providers: [ DataService ]
})

export class AppComponent implements OnInit {

    AvailableBikes: BikeForFront[];
    RentedBikes: BikeForFront[];
    bikeForFront: BikeForFront = new BikeForFront();

    constructor(private dataService: DataService) {}

    ngOnInit(): void{
      this.loadAvailableBikes();
    }

    loadAvailableBikes(): void{
      this.dataService.getAvailableBikes().subscribe((data: BikeForFront[]) => {
        this.AvailableBikes = data;
        this.loadRentedBikes();
      });
    }

    loadRentedBikes(): void{
      this.dataService.getRentedBikes().subscribe((data: BikeForFront[]) => {
        this.RentedBikes = data;
        this.sumRent();
      });
    }

    sumRent(): number{
      let total = 0;
      this.RentedBikes?.forEach((data: BikeForFront) => {
        total += data.price;
      });
      return Number(total.toFixed(2));
    }

    createBike(): void{
      if (this.bikeForFront.title != null && this.bikeForFront.type != null && this.bikeForFront.price >= 0){
        this.dataService.createBike(this.bikeForFront).subscribe((data: BikeForFront) => {
          this.AvailableBikes.push(this.bikeForFront);
          this.loadAvailableBikes();
        });
      }
      else{
        alert('Please fill in all the required fields');
      }
    }

    updateRentedBike(id: number): void{
      this.updateStatus(id, this.RentedBikes);
    }

    updateAvailableBike(id: number): void{
      this.updateStatus(id, this.AvailableBikes);
    }

    updateStatus(id: number, bikes: BikeForFront[]): void{
      this.dataService.updateBike(id).subscribe(data => {
        const index: number = bikes.indexOf(this.dataService.getBike(id) as BikeForFront);
        bikes.splice(index, 1);
        this.loadAvailableBikes();
      });
    }

    delete(id: number): void{
      this.dataService.deleteBike(id).subscribe(data => this.loadAvailableBikes());
    }
}
