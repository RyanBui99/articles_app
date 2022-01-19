import axios from 'axios';
import ILoginRegister from '../interfaces/ILoginRegister';
import ICreateEditUser from '../interfaces/ICreateEditUser';

const URL = process.env.SERVER_ENDPOINT || 'https://localhost:5001';

/**
 * All the endpoints to the server
 */
export const APIService = {
  async login(userCredentials: ILoginRegister) {
    const response = await axios.post(`${URL}/api/authentication/login`, userCredentials);
    return response;
  },

  async register(userCredentials: ICreateEditUser) {
    const response = await axios.post(`${URL}/api/authentication/register`, userCredentials);
    return response;
  },

  async getAllUsers() {
    const response = await axios.get(`${URL}/api/admin/users`);
    return response;
  },
};
