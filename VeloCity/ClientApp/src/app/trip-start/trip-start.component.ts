import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { TripService } from '../../services/trip.service';

@Component({
  selector: 'app-trip-start',
  templateUrl: './trip-start.component.html',
  styleUrls: ['./trip-start.component.css']
})
export class TripStartComponent implements AfterViewInit  {
  @ViewChild('f') form!: NgForm

  constructor(
    private tripService: TripService,
    private router: Router   ) { }

  ngAfterViewInit(): void {
    console.dir(this.form);
  }

  onSubmit() {
    const content = this.form.value;
    console.log(content);
    this.tripService.startTrip(content.bikeCode).subscribe();
    this.form.reset();
    this.router.navigate(['/']);
  }

}
