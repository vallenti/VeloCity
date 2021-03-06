import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { GoogleMapsModule } from '@angular/google-maps'
import { ZXingScannerModule } from '@zxing/ngx-scanner';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { StationsComponent } from './stations/stations.component';
import { BikesComponent } from './bikes/bikes.component';
import { TripsComponent } from './trips/trips.component';
import { StationsService } from '../services/stations.service';
import { TripStartComponent } from './trip-start/trip-start.component';
import { TripService } from "../services/trip.service";
import { AuthorizeService } from '../api-authorization/authorize.service';
import { TripCurrentComponent } from './trip-current/trip-current.component';
import { StationsNewComponent } from './stations-new/stations-new.component';
import { BikesNewComponent } from './bikes-new/bikes-new.component';
import { BikesService } from '../services/bikes.service';
import { CurrencyBGNPipe } from './pipes/currencyBGN.pipe';
import { StationsUpdateComponent } from './stations-update/stations-update.component';
import { NotFoundPageComponent } from '../not-found-page/not-found-page.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    StationsComponent,
    BikesComponent,
    TripsComponent,
    TripStartComponent,
    TripCurrentComponent,
    StationsNewComponent,
    BikesNewComponent,
    CurrencyBGNPipe,
    StationsUpdateComponent,
    NotFoundPageComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    GoogleMapsModule,
    ZXingScannerModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'stations', component: StationsComponent, canActivate: [AuthorizeGuard] },
      { path: 'stations/new', component: StationsNewComponent, canActivate: [AuthorizeGuard] },
      { path: 'stations/update/:id', component: StationsUpdateComponent, canActivate: [AuthorizeGuard] },
      { path: 'bikes', component: BikesComponent, canActivate: [AuthorizeGuard] },
      { path: 'bikes/new', component: BikesNewComponent, canActivate: [AuthorizeGuard] },
      { path: 'trips', component: TripsComponent, canActivate: [AuthorizeGuard] },
      { path: 'trip/start', component: TripStartComponent, canActivate: [AuthorizeGuard] },
      { path: 'trips/current', component: TripCurrentComponent, canActivate: [AuthorizeGuard] },
      { path: '**', component: NotFoundPageComponent }
    ]) 
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
    StationsService,
    TripService,
    BikesService,
    AuthorizeService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
