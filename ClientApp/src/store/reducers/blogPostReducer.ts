import { BlogPostActions, BlogPostActionTypes } from '../actions/blogPostActions';
import IStorageBlogPosts from '../../interfaces/IStorageBlogPosts';

interface State {
  pending: boolean;
  blogPosts: IStorageBlogPosts[];
  error: string | null;
}

const initialState = {
  pending: false,
  blogPosts: [],
  error: null,
};

export function blogPostReducer(state: State = initialState, action: BlogPostActions):State {
  switch (action.type) {
    case BlogPostActionTypes.GET_BLOGPOSTS_PENDING:
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
    case BlogPostActionTypes.GET_BLOGPOSTS_ERROR:
      return {
        ...state,
        pending: false,
      };
    default:
      return state;
  }
}
