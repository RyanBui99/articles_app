import axios from 'axios';
import ILoginRegister from '../interfaces/ILoginRegister';

const URL = process.env.SERVER_ENDPOINT || 'https://localhost:5001';

export const APIService = {
  async login(userCredentials: ILoginRegister) {
    const response = await axios.post(`${URL}/api/authentication/login`, userCredentials);
    return response;
  },
};
