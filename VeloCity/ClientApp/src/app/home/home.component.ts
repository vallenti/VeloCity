import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IMarker } from '../../interfaces/IMarker';
import { StationsService } from '../../services/stations.service';
import { TripService } from '../../services/trip.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public hasCurrentTrip?: Observable<boolean>;
  markers: IMarker[] = [];
  zoom = 12;
  center!: google.maps.LatLngLiteral;
  options: google.maps.MapOptions = {
    mapTypeId: 'roadmap',
    zoomControl: true,
    scrollwheel: true,
    disableDoubleClickZoom: false,
    maxZoom: 15,
    minZoom: 4,
  }
  constructor(private stationsService: StationsService,
    private tripService: TripService) { }

  ngOnInit() {
    this.hasCurrentTrip = this.tripService.hasCurrentTrip();

    this.center = {
      lat: 42.496820,
      lng: 27.417761,
    };

    this.addStations();
  }

  addStations(): void {
    this.stationsService.loadStations().subscribe(stations => {
      for (let station of stations) {
        this.markers.push({
          position: {
            lat: station.latitude,
            lng: station.longitude,
          },
          label: {
            color: 'white',
            text: this.hasCurrentTrip ? station.availableBikes.toString() : station.parkedBikesCount.toString(),
          },
          title: station.name,
          options: {
            animation: google.maps.Animation.DROP
          },
        });
      }
    });
  }
}
