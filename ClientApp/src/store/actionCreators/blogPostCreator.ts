import { Dispatch } from 'redux';
import { APIService } from '../../helpers/APIService';
import { BlogPostActions, BlogPostActionTypes } from '../actions/blogPostActions';

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
      console.log(data)
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
