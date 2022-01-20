import {
  BlogPostActions,
  BlogPostActionTypes,
} from '../actions/blogPostActions';
import IStorageBlogPosts from '../../interfaces/IStorageBlogPosts';

interface State {
  pending: boolean;
  blogPosts: IStorageBlogPosts[];
  blogPost: IStorageBlogPosts;
  error: string | null;
}

const initialState = {
  pending: false,
  blogPosts: [],
  blogPost: {
    imageSrc: '',
    imageName: '',
    header: '',
    content: '',
    id: '',
    preview: '',
  },
  error: null,
};

export function blogPostReducer(
  state: State = initialState,
  action: BlogPostActions
): State {
  switch (action.type) {
    case BlogPostActionTypes.GET_BLOGPOSTS_PENDING:
    case BlogPostActionTypes.GET_CLICKED_BLOGPOST_PENDING:
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
    case BlogPostActionTypes.GET_BLOGPOSTS_ERROR:
    case BlogPostActionTypes.GET_CLICKED_BLOGPOST_ERROR:
      return {
        ...state,
        pending: false,
      };
    default:
      return state;
  }
}

// blogPost: {imageSrc: '',
// imageName: '',
// header: '',
// content: '',
// id: '',
// preview: ''},
