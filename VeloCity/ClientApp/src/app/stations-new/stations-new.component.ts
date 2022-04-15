import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { IMarker } from '../../interfaces/IMarker';
import { StationsService } from '../../services/stations.service';

@Component({
  selector: 'app-stations-new',
  templateUrl: './stations-new.component.html',
  styleUrls: ['./stations-new.component.css']
})
export class StationsNewComponent implements OnInit {
  @ViewChild('f') form!: NgForm
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

  constructor(
    private stationsService: StationsService,
    private router: Router) { }

  ngOnInit(): void {
    this.center = {
      lat: 42.496820,
      lng: 27.417761,
    };
  }

  addMarker(event: google.maps.MapMouseEvent): void {
    let latitude = event.latLng!.lat.apply(this);
    let longitude = event.latLng!.lng.apply(this);
    this.marker = {
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
    this.coordinates = latitude + ',' + longitude;

    this.form.value.stationCoordinates = this.coordinates;
  }

  onSubmit() {
    const content = this.form.value;
    console.log(content);
    this.stationsService.createStation(content.stationName, content.stationBikesCount, content.stationCoordinates).subscribe();
    this.form.reset();
    this.router.navigate(['/stations']);
  }
}
