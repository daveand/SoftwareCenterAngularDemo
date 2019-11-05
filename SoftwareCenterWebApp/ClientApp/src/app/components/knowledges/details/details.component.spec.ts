import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KnowledgedetailsComponent } from './details.component';

describe('KnowledgedetailsComponent', () => {
  let component: KnowledgedetailsComponent;
  let fixture: ComponentFixture<KnowledgedetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [KnowledgedetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KnowledgedetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
