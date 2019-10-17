import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KnowledgesComponent } from './knowledges.component';

describe('KnowledgesComponent', () => {
  let component: KnowledgesComponent;
  let fixture: ComponentFixture<KnowledgesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [KnowledgesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KnowledgesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
