import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule, MatFormFieldModule, MatInputModule, MatSelectModule } from '@angular/material';
import { AppComponent } from './app.component';
import { SpotifyComponent } from './spotify/spotify.component';
import { SpotifyCallbackComponent } from './spotify-callback/spotify-callback.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { WeatherComponent } from './weather/weather.component';
import { MessagesComponent } from './messages/messages.component';
import { UserComponent } from './user/user.component';
import { PreferencesComponent } from './preferences/preferences.component';
import { RouterModule } from '@angular/router';

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
    RouterModule.forRoot([]),
    MatFormFieldModule,
    FormsModule,
    MatInputModule,
    AppRoutingModule,
    MatButtonModule,
    MatSelectModule,
    HttpClientModule,
    BrowserAnimationsModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ]
})

export class AppModule { }
