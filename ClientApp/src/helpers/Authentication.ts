import IStorageUser from "../interfaces/IStorageUser";

const key = 'username';

/**
 * Object with functions that set/get a user to/from localstorage.
 */
const Authentication = {
  getUser(): IStorageUser {
    const usernameLocalstorage = JSON.parse(
      localStorage.getItem(key) ||
        '{"id":"null","isAdmin":false,"username":"null","token":"null"}'
    );
    return usernameLocalstorage;
  },

  setUser(user: IStorageUser) {
    localStorage.setItem(key, JSON.stringify(user));
  },
};

export default Authentication;
