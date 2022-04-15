import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IBike } from '../interfaces/IBike';

@Injectable()
export class BikesService {
  public bikes: IBike[] = [];
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) {
  }

  loadBikes(): Observable<IBike[]> {
    return this.http.get<IBike[]>(this.baseUrl + 'api/bikes');
  }

  createBike(stationName: string, stationBikesCount: string, stationCoordinates: string): Observable<IBike> {
    return this.http.post<IBike>(this.baseUrl + 'api/bikes', {
      stationName: stationName,
      stationBikesCount: +stationBikesCount,
      stationCoordinates: stationCoordinates
    })
  }

  serviceBike(id: number): void {
    this.http.get(this.baseUrl + 'api/bikes/service/' + id).subscribe();
  }

  makeBikeAvailable(id: number): void {
    this.http.get(this.baseUrl + 'api/bikes/available/' + id).subscribe();
  }

  deleteBike(id: number) {
    this.http.delete(this.baseUrl + 'api/bikes/' + id).subscribe();
  }
}
