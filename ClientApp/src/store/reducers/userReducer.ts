import { UserActions, UserActionType } from '../actions/userActions';
import IStorageUser from '../../interfaces/IStorageUser';

interface State {
  pending: boolean;
  users: IStorageUser[];
  error: string | null;
}

const initialState = {
  pending: false,
  users: [],
  error: null,
};

export function userReducer(state: State = initialState, action: UserActions):State {
  switch (action.type) {
    case UserActionType.GET_USERS_PENDING:
      return {
        ...state,
        pending: true,
      };
    case UserActionType.GET_USERS_SUCCESS:
      return {
        ...state,
        pending: false,
        users: action.payload,
      };
    case UserActionType.GET_USERS_ERROR:
      return {
        ...state,
        pending: false,
        error: action.payload,
      };
    default:
      return state;
  }
}

