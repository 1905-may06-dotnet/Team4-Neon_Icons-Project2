import { Component, OnInit } from '@angular/core';
import { Preferences } from '../preferences';
import { PreferencesService } from '../preferences.service';

@Component({
  selector: 'app-preferences',
  templateUrl: './preferences.component.html',
  styleUrls: ['./preferences.component.css']
})
export class PreferencesComponent implements OnInit {

  constructor(private preferencesService: PreferencesService) { }

  Preferences: Preferences;

  ngOnInit() {
  }

  GetGenre() {
    this.preferencesService.GetGenre(this.Preferences)
      .subscribe(preferences => this.Preferences = preferences);
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
