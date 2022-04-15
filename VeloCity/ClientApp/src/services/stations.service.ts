import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IStation } from '../interfaces/IStation';
import { Observable } from 'rxjs';
import { IDropdown } from '../interfaces/IDropdown';


@Injectable()
export class StationsService {
  public stations: IStation[] = [];
  constructor(
    private http: HttpClient, 
    @Inject('BASE_URL') private baseUrl: string) {
  }

  loadStations(): Observable<IStation[]> {
    return this.http.get<IStation[]>(this.baseUrl + 'api/stations');
  }

  getAvailableStations(): Observable<IDropdown[]> {
    return this.http.get<IDropdown[]>(this.baseUrl + 'api/stations/available');
  }

  createStation(stationName: string, stationBikesCount: string, stationCoordinates: string): Observable<IStation> {
    return this.http.post<IStation>(this.baseUrl + 'api/stations', {
      stationName: stationName,
      stationBikesCount: +stationBikesCount,
      stationCoordinates: stationCoordinates
    })
  }

  deleteStation(id: number) {
    this.http.delete(this.baseUrl + 'api/stations/' + id).subscribe();
  }
}
