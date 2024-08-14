import { TestBed } from '@angular/core/testing';
import { RouterModule } from '@angular/router';
import { AppCalculadorComponente } from './app.component';

describe('AppComponent', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        RouterModule.forRoot([])
      ],
      declarations: [
        AppCalculadorComponente
      ],
    }).compileComponents();
  });

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppCalculadorComponente);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });

  it(`should have as title 'CdbApp'`, () => {
    const fixture = TestBed.createComponent(AppCalculadorComponente);
    const app = fixture.componentInstance;
    expect(app.title).toEqual('CdbApp');
  });

  it('should render title', () => {
    const fixture = TestBed.createComponent(AppCalculadorComponente);
    fixture.detectChanges();
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('h1')?.textContent).toContain('Hello, CdbApp');
  });
});
