import { Component, OnInit } from '@angular/core';
import { Preferences } from '../preferences';
import { PreferencesService } from '../preferences.service';
import { UserService } from '../user.service';
import { User } from '../user';
import { Weather } from '../weather';

@Component({
  selector: 'app-preferences',
  templateUrl: './preferences.component.html',
  styleUrls: ['./preferences.component.css']
})
export class PreferencesComponent implements OnInit {

  constructor(private preferencesService: PreferencesService, private userService: UserService) { }

  Preferences: Preferences;

  ngOnInit() {
  }

  GetGenre() {
    this.Preferences = new Preferences();
    this.Preferences.client = new User();
    this.Preferences.client.username = 'username';
    this.Preferences.client.password = 'password';
    this.Preferences.client.zip = 'zip';
    this.Preferences.preference = new Weather();
    this.Preferences.preference.type = 'type';
    this.Preferences.preference.description = 'description';
    this.Preferences.preference.default_genre = 'genre';
    this.preferencesService.GetGenre(this.Preferences);
  }

  UpdatePreference() {
    this.preferencesService.UpdatePreference(this.Preferences)
      .subscribe(preferences => this.Preferences = preferences);
  }

  RemovePreference() {
    this.preferencesService.RemovePreference(this.Preferences)
      .subscribe(preferences => this.Preferences = preferences);
  }
}
