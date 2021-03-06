import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DashboardComponent } from './dashboard/dashboard.component';
import { SpotifyComponent } from './spotify/spotify.component';
import { WeatherComponent } from './weather/weather.component';
import { SpotifyCallbackComponent } from './spotify-callback/spotify-callback.component';
import { UserComponent } from './user/user.component';
import { PreferencesComponent } from './preferences/preferences.component';

const routes: Routes = [
  { path: '', redirectTo: 'weather', pathMatch: 'full' },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'weather', component: WeatherComponent },
  { path: 'spotify', component: SpotifyComponent },
  { path: 'spotifycallback', component: SpotifyCallbackComponent },
  { path: 'user', component: UserComponent },
  { path: 'preferences', component: PreferencesComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
