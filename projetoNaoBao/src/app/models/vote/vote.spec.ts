import { Vote } from './vote';

describe('Vote', () => {
  it('should create an instance', () => {
    expect(new Vote("", "", true)).toBeTruthy();
  });
});
