import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SpotifyComponent } from './spotify.component';
import { HttpClient } from '@angular/common/http';

describe('SpotifyComponent', () => {
  let component: SpotifyComponent;
  let fixture: ComponentFixture<SpotifyComponent>;

  const httpSpy = jasmine.createSpyObj('HttpClient', ['get']);

  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      { provide: HttpClient, useValue: httpSpy }
    ]
  }));

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SpotifyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SpotifyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
