import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { IBike } from '../../interfaces/IBike';

@Component({
  selector: 'app-bikes',
  templateUrl: './bikes.component.html',
  styleUrls: ['./bikes.component.css']
})
export class BikesComponent {
  public bikes: IBike[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<IBike[]>(baseUrl + 'api/bikes').subscribe(result => {
      this.bikes = result;
    }, error => console.error(error));
  }
}
