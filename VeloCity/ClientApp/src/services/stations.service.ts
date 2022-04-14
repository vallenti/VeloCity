import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IStation } from '../interfaces/IStation';
import { Observable } from 'rxjs';


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
}
