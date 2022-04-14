import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
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

  endTrip(): void {
    this.http.post(this.baseUrl + 'api/trips/end', {}).subscribe();
  }
}
