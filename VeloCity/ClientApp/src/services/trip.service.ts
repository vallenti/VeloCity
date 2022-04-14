import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ITrip } from '../interfaces/ITrip';

@Injectable()
export class TripService {
  public stations: ITrip[] = [];
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) {
  }

  loadStations(): Observable<ITrip[]> {
    return this.http.get<ITrip[]>(this.baseUrl + 'api/trips');
  }

  startTrip(bikeCode: string): Observable<ITrip> {
    return this.http.post<ITrip>(this.baseUrl + 'api/trips/start', { bikeCode: +bikeCode })
  }

  endTrip(stationCode: string): void {
    this.http.post(this.baseUrl + 'api/trips/end', { stationCode: +stationCode }).subscribe();
  }

  getCurrentTrip(): Observable<ITrip | null> {
    return this.http.get<ITrip | null>(this.baseUrl + 'api/trips/current', {});
  }

  hasCurrentTrip(): Observable<boolean> {
    return this.getCurrentTrip().pipe(map(t => !!t));
  }
}
