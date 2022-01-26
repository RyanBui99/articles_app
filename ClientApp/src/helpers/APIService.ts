import axios from 'axios';
import ILoginRegister from '../interfaces/ILoginRegister';
import ICreateEditUser from '../interfaces/ICreateEditUser';
import IStorageUser from '../interfaces/IStorageUser';
import { ICreateBlogPost } from '../interfaces/ICreateBlogPost';
import { IEditBlogPost } from '../interfaces/IEditBlogPost';

// const URL = process.env.SERVER_ENDPOINT || 'https://localhost:44342';
const URL = process.env.SERVER_ENDPOINT || 'https://localhost:5001';

/**
 * All the endpoints to the server
 */
export const APIService = {
  async login(userCredentials: ILoginRegister) {
    const response = await axios.post(
      `${URL}/api/authentication/login`,
      userCredentials
    );
    return response;
  },

  async register(userCredentials: ICreateEditUser | ILoginRegister) {
    const response = await axios.post(
      `${URL}/api/authentication/register`,
      userCredentials
    );
    return response;
  },

  async getAllUsers() {
    const response = await axios.get(`${URL}/api/admin/users`);
    return response;
  },

  async updateUser(userId: string, updatedCredentials: IStorageUser) {
    const response = await axios.put(
      `${URL}/api/admin/updateUser/${userId}`,
      updatedCredentials
    );
    return response;
  },

  async deleteUser(userId: string) {
    const response = await axios.delete(
      `${URL}/api/admin/deleteUser/${userId}`
    );
    return response;
  },

  async getAllPosts() {
    const response = await axios.get(`${URL}/api/blogpost/getPosts`);
    return response;
  },

  async getClickedPost(blogPostId: string) {
    const response = await axios.get(
      `${URL}/api/blogpost/getPost/${blogPostId}`
    );
    return response;
  },

  async createNewPost(blogPost: ICreateBlogPost) {
    const blogPostAsFormData = new FormData();
    blogPostAsFormData.append('imageFile', blogPost.imageFile as any);
    blogPostAsFormData.append('header', blogPost.header);
    blogPostAsFormData.append('content', blogPost.content);

    const response = await axios.post(
      `${URL}/api/blogpost/createPost`,
      blogPostAsFormData,
      { headers: { 'Content-Type': 'multipart/form-data' } }
    );
    return response;
  },

  async deleteBlogPost(blogPostId: string) {
    const response = await axios.delete(
      `${URL}/api/blogpost/delete/${blogPostId}`
    );
    return response;
  },

  async editBlogPost(blogPostId: string, blogPost: IEditBlogPost) {
    const blogPostAsFormData = new FormData();
    blogPostAsFormData.append('imageFile', blogPost.imageFile as any);
    blogPostAsFormData.append('header', blogPost.header);
    blogPostAsFormData.append('content', blogPost.content);
    blogPostAsFormData.append('imageName', blogPost.imageName);

    const response = await axios.put(
      `${URL}/api/blogpost/editPost/${blogPostId}`,
      blogPostAsFormData,
      { headers: { 'Content-Type': 'multipart/form-data' } }
    );
    return response;
  },
};
