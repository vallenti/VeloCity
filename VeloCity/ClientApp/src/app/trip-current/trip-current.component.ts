import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthorizeService } from '../../api-authorization/authorize.service';
import { ITrip } from '../../interfaces/ITrip';
import { TripService } from '../../services/trip.service';

@Component({
  selector: 'app-trip-current',
  templateUrl: './trip-current.component.html',
  styleUrls: ['./trip-current.component.css']
})
export class TripCurrentComponent implements OnInit, AfterViewInit {
  @ViewChild('f') form!: NgForm
  trip!: ITrip | null;
  isAuthenticated?: Observable<boolean>;
  bikeQRCodeId: string | undefined;

  constructor(
    private authorizeService: AuthorizeService,
    private tripService: TripService,
    private router: Router  ) { }

  ngOnInit(): void {
    this.isAuthenticated = this.authorizeService.isAuthenticated();
    this.tripService.getCurrentTrip().subscribe(t => this.trip = t);
  }

  ngAfterViewInit(): void {
    console.dir(this.form);
  }

  onCodeResult(event: any): void {
    this.bikeQRCodeId = event;
  }

  onSubmit() {
    const content = this.form.value;
    console.log(content);
    this.tripService.endTrip(content.stationCode);
    this.form.reset();
    this.router.navigate(['/']);
  }
}
