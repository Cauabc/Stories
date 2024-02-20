export class Vote {
    accountId: string;
    storyId: string;
    upvote: boolean;

    constructor(accountId: string, storyId: string, upvote: boolean){
        this.accountId = accountId;
        this.storyId = storyId;
        this.upvote = upvote;
    }
}
