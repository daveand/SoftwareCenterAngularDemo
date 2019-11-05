import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KnowledgeEditComponent } from './edit.component';

describe('KnowledgeEditComponent', () => {
  let component: KnowledgeEditComponent;
  let fixture: ComponentFixture<KnowledgeEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [KnowledgeEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KnowledgeEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
