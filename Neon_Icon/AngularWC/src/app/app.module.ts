import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SpotifyComponent } from './spotify/spotify.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { WeatherComponent } from './weather/weather.component';
import { MessagesComponent } from './messages/messages.component';
import { InfoService } from './info.service';
import { SpotifyCallbackComponent } from './spotify-callback/spotify-callback.component';
import { SpotifyService } from './spotify.service';
import { TokenService, AuthService } from 'spotify-auth';

@NgModule({
  declarations: [
    AppComponent,
    SpotifyComponent,
    DashboardComponent,
    WeatherComponent,
    MessagesComponent,
    SpotifyComponent,
    SpotifyCallbackComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
  ],
  providers: [ 
    InfoService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: SpotifyService, //Force interception.
      multi: true
    },
    TokenService,
    AuthService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
