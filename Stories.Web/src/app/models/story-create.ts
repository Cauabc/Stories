export class StoryCreate {
    title: string;
    description: string;
    department: string;

    constructor(title: string, description: string, department: string) {
        this.title = title;
        this.description = description;
        this.department = department;
    }
}
