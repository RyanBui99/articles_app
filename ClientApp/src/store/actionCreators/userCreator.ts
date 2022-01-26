import { Dispatch } from 'redux';
import { APIService } from '../../helpers/APIService';
import ICreateEditUser from '../../interfaces/ICreateEditUser';
import { UserActionType, UserActions } from '../actions/userActions';
import IStorageUser from '../../interfaces/IStorageUser';
import { type } from 'os';

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
    } catch (error: any) {
      dispatch({
        type: UserActionType.GET_USERS_ERROR,
        payload: error.message,
      });
    }
  };
};

export const addUsers = (userCredentials: ICreateEditUser) => {
  return async (dispatch: Dispatch<UserActions>) => {
    dispatch({
      type: UserActionType.ADD_USER_PENDING,
    });
    try {
      await APIService.register(userCredentials);
      const { data } = await APIService.getAllUsers();
      dispatch({
        type: UserActionType.ADD_USER_SUCCESS,
        payload: data,
      });
    } catch (error: any) {
      dispatch({
        type: UserActionType.ADD_USER_ERROR,
        payload: error.response.data.message,
      });
      throw error
    }
  };
};

export const editUser = (userId: string, updatedUser: IStorageUser) => {
  return async (dispatch: Dispatch<UserActions>) => {
    dispatch({
      type: UserActionType.UPDATE_USER_PENDING,
    });
    try {
      await APIService.updateUser(userId, updatedUser);
      const { data } = await APIService.getAllUsers();
      dispatch({
        type: UserActionType.UPDATE_USER_SUCCESS,
        payload: data,
      });
    } catch (error: any) {
      dispatch({
        type: UserActionType.UPDATE_USER_ERROR,
        payload: error.message,
      });
      throw error
    }
  };
};

export const deleteUser = (userId: string) => {
  return async (dispatch: Dispatch<UserActions>) => {
    dispatch({
      type: UserActionType.DELETE_USER_PENDING,
    });
    try {
      await APIService.deleteUser(userId);
      const { data } = await APIService.getAllUsers();
      dispatch({
        type: UserActionType.DELETE_USER_SUCCESS,
        payload: data,
      });
    } catch (error: any) {
      dispatch({
        type: UserActionType.DELETE_USER_ERROR,
        payload: error.message,
      });
      throw error
    }
  };
};
