import { User } from './user.model';
import { Files } from './files.model';


export interface FavFiles {
  Id: string;
  UserId: string;
  FilesId: string;

  User: User;
  File: Files;

}
