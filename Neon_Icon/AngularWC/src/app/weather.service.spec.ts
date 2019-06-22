import { TestBed } from '@angular/core/testing';
import { WeatherService } from './weather.service';
import { HttpClientTestingModule} from '@angular/common/http/testing';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';



describe('WeatherService', () => {
  const spyService = jasmine.createSpyObj('HttpClient', ['get']);
  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      { provide: HttpClient, useValue: spyService }
    ]
  }));

  spyService.get.and.returnValue();

  it('should be created', () => {
    const service: WeatherService = TestBed.get(WeatherService);
    expect(service).toBeTruthy();
  });
});
