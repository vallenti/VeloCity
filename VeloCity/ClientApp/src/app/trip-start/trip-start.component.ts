import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { ZXingScannerComponent } from '@zxing/ngx-scanner';
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
  @ViewChild('scanner', { static: false }) scanner!: ZXingScannerComponent;
  bikeQRCodeId: string | undefined;

  constructor(
    private tripService: TripService,
    private router: Router   ) { }

  ngAfterViewInit(): void {
    
  }
  onCodeResult(event: any): void {
    this.bikeQRCodeId = event;
  }

  onSubmit() {
    const content = this.form.value;
    console.log(content);
    this.tripService.startTrip(content.bikeCode).subscribe();
    this.form.reset();
    this.router.navigate(['/']);
  }

}
