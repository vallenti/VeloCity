import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IStation } from '../../interfaces/IStation';

@Component({
  selector: 'app-stations',
  templateUrl: './stations.component.html',
  styleUrls: ['./stations.component.css']
})
export class StationsComponent {
  public stations: IStation[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<IStation[]>(baseUrl + 'api/stations').subscribe(result => {
      this.stations = result;
    }, error => console.error(error));
  }
}


