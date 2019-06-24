import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material';
import { MatInputModule } from '@angular/material/input';

import { AppComponent } from './app.component';
import { SpotifyComponent } from './spotify/spotify.component';
import { SpotifyCallbackComponent } from './spotify-callback/spotify-callback.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { WeatherComponent } from './weather/weather.component';
import { MessagesComponent } from './messages/messages.component';
import { UserComponent } from './user/user.component';
import { PreferencesComponent } from './preferences/preferences.component';

@NgModule({
  declarations: [
    AppComponent,
    SpotifyComponent,
    DashboardComponent,
    WeatherComponent,
    MessagesComponent,
    SpotifyComponent,
    SpotifyCallbackComponent,
    UserComponent,
    PreferencesComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatInputModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
