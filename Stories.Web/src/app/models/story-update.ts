export class StoryUpdate {
    id: string;
    title: string;
    description: string;
    department: string;

    constructor(id: string, title: string, description: string, department: string){
        this.id = id;
        this.title = title;
        this.description = description;
        this.department = department;
    }
}
