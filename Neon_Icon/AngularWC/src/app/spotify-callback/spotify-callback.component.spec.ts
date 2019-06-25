import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { SpotifyCallbackComponent } from './spotify-callback.component';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClient } from '@angular/common/http';


describe('SpotifyCallbackComponent', () => {
  let component: SpotifyCallbackComponent;
  let fixture: ComponentFixture<SpotifyCallbackComponent>;

  const httpSpy = jasmine.createSpyObj('HttpClient', ['get']);

  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      { provide: HttpClient, useValue: httpSpy }
    ]
  }));

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule
      ],
      declarations: [ SpotifyCallbackComponent ]
    }
    )
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SpotifyCallbackComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  // it('should create', () => {
  //   expect(component).toBeTruthy();
  // });
});
