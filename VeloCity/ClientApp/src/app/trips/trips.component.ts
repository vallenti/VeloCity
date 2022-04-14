import { Component, OnInit } from '@angular/core';
import { ITrip } from '../../interfaces/ITrip';
import { TripService } from '../../services/trip.service';

@Component({
  selector: 'app-trips',
  templateUrl: './trips.component.html',
  styleUrls: ['./trips.component.css']
})
export class TripsComponent implements OnInit{
  public trips: ITrip[] = [];

  constructor(private tripService: TripService) {

  }

  ngOnInit(): void {
    this.tripService.loadStations().subscribe(trips => this.trips = trips);
  }
}
