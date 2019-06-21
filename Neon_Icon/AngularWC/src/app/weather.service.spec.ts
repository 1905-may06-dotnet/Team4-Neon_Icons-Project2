import { TestBed } from '@angular/core/testing';
import { WeatherService } from './weather.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';



describe('WeatherService', () => {
  let httpClient : HttpClient;
  let spyService = jasmine.createSpyObj('HttpClient', ['get'])
  let weatherService : WeatherService;
  beforeEach(() => TestBed.configureTestingModule({
    //imports: [HttpClientTestingModule],
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
