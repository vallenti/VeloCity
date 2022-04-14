import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthorizeService } from '../../api-authorization/authorize.service';
import { ITrip } from '../../interfaces/ITrip';
import { TripService } from '../../services/trip.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  public isAuthenticated?: Observable<boolean>;
  public hasCurrentTrip?: Observable<boolean>;

  constructor(
    private authorizeService: AuthorizeService,
    private tripService: TripService) {

  }

  ngOnInit(): void {
    this.isAuthenticated = this.authorizeService.isAuthenticated();
    this.hasCurrentTrip = this.tripService.hasCurrentTrip();
  }

  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
