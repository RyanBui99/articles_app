import IStorageBlogPosts from '../../interfaces/IStorageBlogPosts';

export enum BlogPostActionTypes {
  GET_BLOGPOSTS_PENDING = 'FETCH_USERS_PENDING',
  GET_BLOGPOSTS_SUCCESS = 'FETCH_USERS_SUCCESS',
  GET_BLOGPOSTS_ERROR = 'FETCH_USERS_ERROR',
  GET_CLICKED_BLOGPOST_PENDING = 'GET_CLICKED_BLOGPOST_PENDING',
  GET_CLICKED_BLOGPOST_SUCCESS = 'GET_CLICKED_BLOGPOST_SUCCESS',
  GET_CLICKED_BLOGPOST_ERROR = 'GET_CLICKED_BLOGPOST_ERROR',
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

export type BlogPostActions =
  | getBlogPostsPending
  | getBlogPostsSuccess
  | getBlogPostsError
  | getClickedBlogPostPending
  | getClickedBlogPostSuccess
  | getClickedBlogPostError;
