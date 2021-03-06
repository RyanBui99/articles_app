import {
  BlogPostActions,
  BlogPostActionTypes,
} from '../actions/blogPostActions';
import IStorageBlogPosts from '../../interfaces/IStorageBlogPosts';
import { IEditBlogPost } from '../../interfaces/IEditBlogPost';

interface State {
  pending: boolean;
  blogPosts: IStorageBlogPosts[];
  blogPost: IStorageBlogPosts;
  error: string | null;
}

const initialState = {
  pending: false,
  blogPosts: [],
  blogPost: <IStorageBlogPosts>{},
  error: null,
};

export function blogPostReducer(
  state: State = initialState,
  action: BlogPostActions
): State {
  switch (action.type) {
    case BlogPostActionTypes.GET_BLOGPOSTS_PENDING:
    case BlogPostActionTypes.GET_CLICKED_BLOGPOST_PENDING:
    case BlogPostActionTypes.ADD_BLOGPOST_PENDING:
    case BlogPostActionTypes.EDIT_BLOGPOST_PENDING:
      return {
        ...state,
        pending: true,
      };
    case BlogPostActionTypes.GET_BLOGPOSTS_SUCCESS:
      return {
        ...state,
        pending: false,
        blogPosts: action.payload,
      };
    case BlogPostActionTypes.GET_CLICKED_BLOGPOST_SUCCESS:
      return {
        ...state,
        pending: false,
        blogPost: action.payload,
      };
    case BlogPostActionTypes.ADD_BLOGPOST_SUCCESS:
      return {
        ...state,
        pending: false,
        blogPosts: action.payload,
      };
    case BlogPostActionTypes.EDIT_BLOGPOST_SUCCESS:
      return {
        ...state,
        pending: false,
        blogPost: action.payload,
      };
    case BlogPostActionTypes.GET_BLOGPOSTS_ERROR:
    case BlogPostActionTypes.GET_CLICKED_BLOGPOST_ERROR:
    case BlogPostActionTypes.ADD_CLICKED_BLOGPOST_ERROR:
    case BlogPostActionTypes.EDIT_BLOGPOST_ERROR:
      return {
        ...state,
        pending: false,
      };
    default:
      return state;
  }
}
