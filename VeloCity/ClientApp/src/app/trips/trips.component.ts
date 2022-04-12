import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { ITrip } from '../../interfaces/ITrip';

@Component({
  selector: 'app-trips',
  templateUrl: './trips.component.html',
  styleUrls: ['./trips.component.css']
})
export class TripsComponent {
  public trips: ITrip[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<ITrip[]>(baseUrl + 'api/trips').subscribe(result => {
      this.trips = result;
    }, error => console.error(error));
  }
}
