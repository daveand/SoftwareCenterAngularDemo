import { TestBed } from '@angular/core/testing';

import { BlobService } from './blob.service';

describe('BlobService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BlobService = TestBed.get(BlobService);
    expect(service).toBeTruthy();
  });
});
