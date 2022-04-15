import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { IDropdown } from '../../interfaces/IDropdown';
import { BikesService } from '../../services/bikes.service';
import { StationsService } from '../../services/stations.service';

@Component({
  selector: 'app-bikes-new',
  templateUrl: './bikes-new.component.html',
  styleUrls: ['./bikes-new.component.css']
})
export class BikesNewComponent implements OnInit {
  @ViewChild('f') form!: NgForm
  bikeStatuses!: IDropdown[];
  bikeTypes!: IDropdown[];
  bikeStations!: IDropdown[];
  constructor(private bikeService: BikesService,
    private stationService: StationsService,
    private router: Router) { }

  ngOnInit(): void {
    this.bikeService.getBikeStatuses().subscribe(statuses => {
      this.bikeStatuses = statuses;
      console.log(statuses);
    });
    this.bikeService.getBikeTypes().subscribe(types => {
      this.bikeTypes = types;
      console.log(types);
    });
    this.stationService.getAvailableStations().subscribe(stations => {
      this.bikeStations = stations;
      console.log(stations);
    });

    console.log(this.bikeStatuses);
    console.log(this.bikeTypes);
  }

  onSubmit() {
    const content = this.form.value;
    console.log(content);
    this.bikeService.createBike(content.bikeType, content.bikeStatus, content.bikeStation).subscribe();
    this.form.reset();
    this.router.navigate(['/bikes']);
  }
}
