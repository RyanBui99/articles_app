import { keys } from '@mui/system';
import IStorageUser from '../interfaces/IStorageUser';

const key = 'user';

/**
 * Object with functions that set/get a user to/from localstorage.
 */
const Authentication = {
  getUser(): IStorageUser {
    const usernameLocalstorage = JSON.parse(
      localStorage.getItem(key) ||
        '{"id":"null","username":"null","role":"null"}'
    );
    return usernameLocalstorage;
  },

  setUser(user: IStorageUser) {
    localStorage.setItem(key, JSON.stringify(user));
  },

  logoutUser() {
    localStorage.removeItem(key);
  },
};

export default Authentication;
