import { Dispatch } from 'redux';
import { APIService } from '../../helpers/APIService';
import { UserActionType, UserActions } from '../actions/userActions';

/**
 * Get all the users from server
 * @returns 
 */
export const getUsers = () => {
  return async (dispatch: Dispatch<UserActions>) => {
    dispatch({
      type: UserActionType.GET_USERS_PENDING,
    });

    try {
      const { data } = await APIService.getAllUsers();
      dispatch({
        type: UserActionType.GET_USERS_SUCCESS,
        payload: data,
      });
    } catch (err: any) {
      dispatch({
        type: UserActionType.GET_USERS_ERROR,
        payload: err.message,
      });
    }
  };
};

// export const addUsers = (userCredentials: ICreateEditUser) => {
//   return async (dispatch: Dispatch<UserActions>) => {
//     dispatch({
//       type: UserActionType.ADD_USER,
//       payload: userCredentials
//     })
//   };
// };
