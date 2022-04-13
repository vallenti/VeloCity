import { Component, OnInit } from '@angular/core';
import { IStation } from '../../interfaces/IStation';
import { StationsService } from '../../services/stations.service';

@Component({
  selector: 'app-stations',
  templateUrl: './stations.component.html',
  styleUrls: ['./stations.component.css']
})
export class StationsComponent implements OnInit{
  public stations: IStation[] = [];

  constructor(private stationsService: StationsService) {
    
  }

  ngOnInit(): void {
    this.stations = this.stationsService.getStations();
  }
}


