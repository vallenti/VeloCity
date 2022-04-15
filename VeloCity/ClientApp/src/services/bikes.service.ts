import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IBike } from '../interfaces/IBike';
import { IDropdown } from '../interfaces/IDropdown';

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

  createBike(bikeType: number, bikeStatus: number, bikeStation: number): Observable<IBike> {
    return this.http.post<IBike>(this.baseUrl + 'api/bikes', {
      bikeType: bikeType,
      bikeStatus: bikeStatus,
      bikeStation: bikeStation
    });
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

  getBikeStatuses(): Observable<IDropdown[]> {
    return this.http.get<IDropdown[]>(this.baseUrl + 'api/bikes/statuses');
  }

  getBikeTypes(): Observable<IDropdown[]> {
    return this.http.get<IDropdown[]>(this.baseUrl + 'api/bikes/types');
  }
}
