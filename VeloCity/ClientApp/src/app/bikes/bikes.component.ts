import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IBike } from '../../interfaces/IBike';
import { BikesService } from '../../services/bikes.service';

@Component({
  selector: 'app-bikes',
  templateUrl: './bikes.component.html',
  styleUrls: ['./bikes.component.css']
})
export class BikesComponent implements OnInit {
  public bikes: IBike[] = [];

  constructor(private bikeService: BikesService,
      private router: Router) { }

  ngOnInit(): void {
    this.bikeService.loadBikes().subscribe(bikes => this.bikes = bikes);
  }

  serviceBike(id: number): void {
    this.bikeService.serviceBike(id);
    this.reloadCurrentRoute();
  }

  makeBikeAvailable(id: number): void {
    this.bikeService.makeBikeAvailable(id);
    this.reloadCurrentRoute();
  }

  deleteBike(id: number): void {
    this.bikeService.deleteBike(id);
    this.reloadCurrentRoute();
  }

  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate([currentUrl]);
    });
  }
}
