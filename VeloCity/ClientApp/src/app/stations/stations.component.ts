import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IStation } from '../../interfaces/IStation';
import { StationsService } from '../../services/stations.service';

@Component({
  selector: 'app-stations',
  templateUrl: './stations.component.html',
  styleUrls: ['./stations.component.css']
})
export class StationsComponent implements OnInit{
  public stations: IStation[] = [];

  constructor(
    private stationsService: StationsService,
    private router: Router  ) {
    
  }

  ngOnInit(): void {
    this.stationsService.loadStations().subscribe(stations => this.stations = stations);
  }

  deleteStation(id: number) {
    this.stationsService.deleteStation(id);
    this.reloadCurrentRoute();
  }

  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate([currentUrl]);
    });
  }
}


