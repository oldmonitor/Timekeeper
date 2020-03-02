import { UserPhoto } from './user-photo';

export interface User {
  userId: number;
  userName: string;

  lastName: string;
  firstName: string;
  photoUrl: string;
  userPhotoes?: UserPhoto[];
}
