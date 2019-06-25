import { TestBed } from '@angular/core/testing';

import { PreferencesService } from './preferences.service';
import { HttpClient } from '@angular/common/http';

describe('PreferencesService', () => {
  const spyService = jasmine.createSpyObj('HttpClient', ['get']);
  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      { provide: HttpClient, useValue: spyService }
    ]
  }));

  it('should be created', () => {
    const service: PreferencesService = TestBed.get(PreferencesService);
    expect(service).toBeTruthy();
  });
});
