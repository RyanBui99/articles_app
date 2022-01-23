import IStorageBlogPosts from '../../interfaces/IStorageBlogPosts';
import { ICreateBlogPost } from '../../interfaces/ICreateBlogPost';
import { IEditBlogPost } from '../../interfaces/IEditBlogPost';

export enum BlogPostActionTypes {
  GET_BLOGPOSTS_PENDING = 'FETCH_USERS_PENDING',
  GET_BLOGPOSTS_SUCCESS = 'FETCH_USERS_SUCCESS',
  GET_BLOGPOSTS_ERROR = 'FETCH_USERS_ERROR',
  GET_CLICKED_BLOGPOST_PENDING = 'GET_CLICKED_BLOGPOST_PENDING',
  GET_CLICKED_BLOGPOST_SUCCESS = 'GET_CLICKED_BLOGPOST_SUCCESS',
  GET_CLICKED_BLOGPOST_ERROR = 'GET_CLICKED_BLOGPOST_ERROR',
  ADD_BLOGPOST_PENDING = 'ADD_BLOGPOST_PENDING',
  ADD_BLOGPOST_SUCCESS = 'ADD_BLOGPOST_SUCCESS',
  ADD_CLICKED_BLOGPOST_ERROR = 'ADD_CLICKED_BLOGPOST_ERROR',
  EDIT_BLOGPOST_PENDING = 'EDIT_BLOGPOST_PENDING',
  EDIT_BLOGPOST_SUCCESS = 'EDIT_BLOGPOST_SUCCESS',
  EDIT_BLOGPOST_ERROR = 'EDIT_BLOGPOST_ERROR',
}

interface getBlogPostsPending {
  type: BlogPostActionTypes.GET_BLOGPOSTS_PENDING;
}

interface getBlogPostsSuccess {
  type: BlogPostActionTypes.GET_BLOGPOSTS_SUCCESS;
  payload: IStorageBlogPosts[];
}

interface getBlogPostsError {
  type: BlogPostActionTypes.GET_BLOGPOSTS_ERROR;
  payload: string;
}

interface getClickedBlogPostPending {
  type: BlogPostActionTypes.GET_CLICKED_BLOGPOST_PENDING;
}

interface getClickedBlogPostSuccess {
  type: BlogPostActionTypes.GET_CLICKED_BLOGPOST_SUCCESS;
  payload: IStorageBlogPosts;
}

interface getClickedBlogPostError {
  type: BlogPostActionTypes.GET_CLICKED_BLOGPOST_ERROR;
  payload: string;
}

interface addBlogPostPending {
  type: BlogPostActionTypes.ADD_BLOGPOST_PENDING;
}

interface addBlogPostSuccess {
  type: BlogPostActionTypes.ADD_BLOGPOST_SUCCESS;
  payload: IStorageBlogPosts[];
}

interface addBlogPostError {
  type: BlogPostActionTypes.ADD_CLICKED_BLOGPOST_ERROR;
  payload: string;
}

interface editBlogPostPending {
  type: BlogPostActionTypes.EDIT_BLOGPOST_PENDING;
}

interface editBlogPostSuccess {
  type: BlogPostActionTypes.EDIT_BLOGPOST_SUCCESS;
  payload: IStorageBlogPosts;
}

interface editBlogPostError {
  type: BlogPostActionTypes.EDIT_BLOGPOST_ERROR;
  payload: string;
}

export type BlogPostActions =
  | getBlogPostsPending
  | getBlogPostsSuccess
  | getBlogPostsError
  | getClickedBlogPostPending
  | getClickedBlogPostSuccess
  | getClickedBlogPostError
  | addBlogPostPending
  | addBlogPostSuccess
  | addBlogPostError
  | editBlogPostPending
  | editBlogPostSuccess
  | editBlogPostError;
