import axios from 'axios';
import ILogin from '../interfaces/ILogin';

const URL = process.env.SERVER_ENDPOINT || 'https://localhost:5001';

export const APIService = {
  async login(userCredentials: ILogin) {
    const response = await axios.post(`${URL}/api/authentication/login`, userCredentials);
    return response;
  },
};
