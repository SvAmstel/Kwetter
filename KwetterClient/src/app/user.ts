export class User {
  id: number;
  naam: string;
  bio: string;

  toJSON(): UserJSON {
    return Object.assign(this);
  }
}

interface UserJSON {
  name: string;
  age: number;
  created: string;
}
