import { Dispatch } from 'redux';
import { APIService } from '../../helpers/APIService';
import {
  BlogPostActions,
  BlogPostActionTypes,
} from '../actions/blogPostActions';
import { ICreateBlogPost } from '../../interfaces/ICreateBlogPost';
import { IEditBlogPost } from '../../interfaces/IEditBlogPost';

/**
 * Get all the blosPosts from server
 * @returns
 */
export const getBlogPosts = () => {
  return async (dispatch: Dispatch<BlogPostActions>) => {
    dispatch({
      type: BlogPostActionTypes.GET_BLOGPOSTS_PENDING,
    });
    try {
      const { data } = await APIService.getAllPosts();
      dispatch({
        type: BlogPostActionTypes.GET_BLOGPOSTS_SUCCESS,
        payload: data,
      });
    } catch (err: any) {
      dispatch({
        type: BlogPostActionTypes.GET_BLOGPOSTS_ERROR,
        payload: err.message,
      });
    }
  };
};

export const getClickedBlogPost = (blogPostId: string) => {
  return async (dispatch: Dispatch<BlogPostActions>) => {
    dispatch({
      type: BlogPostActionTypes.GET_CLICKED_BLOGPOST_PENDING,
    });
    try {
      const { data } = await APIService.getClickedPost(blogPostId);
      dispatch({
        type: BlogPostActionTypes.GET_CLICKED_BLOGPOST_SUCCESS,
        payload: data,
      });
    } catch (err: any) {
      dispatch({
        type: BlogPostActionTypes.GET_CLICKED_BLOGPOST_ERROR,
        payload: err.message,
      });
    }
  };
};

export const createNewPost = (blogPost: ICreateBlogPost) => {
  return async (dispatch: Dispatch<BlogPostActions>) => {
    dispatch({
      type: BlogPostActionTypes.ADD_BLOGPOST_PENDING,
    });
    try {
      await APIService.createNewPost(blogPost);
      const { data } = await APIService.getAllPosts();
      dispatch({
        type: BlogPostActionTypes.ADD_BLOGPOST_SUCCESS,
        payload: data,
      });
    } catch (err: any) {
      dispatch({
        type: BlogPostActionTypes.ADD_CLICKED_BLOGPOST_ERROR,
        payload: err.message,
      });
      throw err;
    }
  };
};

export const editBlogPost = (blogPostId: string, blogPost: IEditBlogPost) => {
  return async (dispatch: Dispatch<BlogPostActions>) => {
    dispatch({
      type: BlogPostActionTypes.EDIT_BLOGPOST_PENDING,
    });
    try {
      await APIService.editBlogPost(blogPostId, blogPost);
      const { data } = await APIService.getClickedPost(blogPostId);
      dispatch({
        type: BlogPostActionTypes.EDIT_BLOGPOST_SUCCESS,
        payload: data,
      });
    } catch (err: any) {
      dispatch({
        type: BlogPostActionTypes.EDIT_BLOGPOST_ERROR,
        payload: err.message,
      });
      throw err;
    }
  };
};
