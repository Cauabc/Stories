import { StoryCreate } from './story-create';

describe('StoryCreate', () => {
  it('should create an instance', () => {
    expect(new StoryCreate('', '', '')).toBeTruthy();
  });
});
