import { TestBed } from '@angular/core/testing';

import { SpotifyService } from './spotify.service';
import { HttpClient } from '@angular/common/http';

describe('SpotifyService', () => {
  const httpSpy = jasmine.createSpyObj('HttpClient', ['get']);

  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      { provide: HttpClient, useValue: httpSpy }
    ]
  }));

  it('should be created', () => {
    const service: SpotifyService = TestBed.get(SpotifyService);
    expect(service).toBeTruthy();
  });
});
