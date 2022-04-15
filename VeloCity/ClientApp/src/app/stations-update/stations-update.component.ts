import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IMarker } from '../../interfaces/IMarker';
import { IStation } from '../../interfaces/IStation';
import { StationsService } from '../../services/stations.service';

@Component({
  selector: 'app-stations-update',
  templateUrl: './stations-update.component.html',
  styleUrls: ['./stations-update.component.css']
})
export class StationsUpdateComponent implements OnInit {
  station!: IStation;
  @ViewChild('f') form!: NgForm
  name: string | undefined;
  bikesCount: string | undefined;
  coordinates: string | undefined;
  marker: IMarker | undefined;
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
  constructor(private activatedRoute: ActivatedRoute,
    private router: Router,
    private stationService: StationsService) { }

  ngOnInit(): void {
    this.center = {
      lat: 42.496820,
      lng: 27.417761,
    };
    this.stationService.loadStation(this.activatedRoute.snapshot.params.id).subscribe(station => {
      this.station = station;
      this.name = station.name;
      this.bikesCount = station.capacity.toString();
      this.coordinates = station.latitude + ',' + station.longitude;
      this.marker = this.setMarker(station.latitude, station.longitude);
    });

    console.log(this.station);
    this.form.value.stationName = this.station.name;
    this.form.value.stationBikesCount = this.station.capacity;
    
  }

  addMarker(event: google.maps.MapMouseEvent): void {
    let latitude = event.latLng!.lat.apply(this);
    let longitude = event.latLng!.lng.apply(this);
    this.marker = this.setMarker(latitude, longitude);
    this.coordinates = latitude + ',' + longitude;

    this.form.value.stationCoordinates = this.coordinates;
  }

  setMarker(latitude: number, longitude: number): IMarker {
    return {
      position: {
        lat: latitude,
        lng: longitude,
      },
      label: {
        color: 'white',
        text: ''
      },
      title: '',
      options: {
        animation: google.maps.Animation.DROP
      },
    }
  }

  onSubmit() {
    const content = this.form.value;
    console.log(content);
    this.stationService.updateStation(this.station.id, content.stationName, content.stationBikesCount, content.stationCoordinates).subscribe();
    this.form.reset();
    this.router.navigate(['/stations']);
  }
}
