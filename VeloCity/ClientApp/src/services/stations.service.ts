import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IStation } from '../interfaces/IStation';


@Injectable({
  providedIn: 'root'
})
export class StationsService {
  public stations: IStation[] = [];
  constructor(
    private http: HttpClient, 
    @Inject('BASE_URL') private baseUrl: string) {
  }

  getStations(): IStation[] {
    this.http.get<IStation[]>(this.baseUrl + 'api/stations').subscribe(result => {
      this.stations = result;
    }, error => console.error(error));

    return this.stations;
  }
}
