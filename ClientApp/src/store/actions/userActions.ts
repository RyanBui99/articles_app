import IStorageUser from '../../interfaces/IStorageUser';
import ICreateEditUser from '../../interfaces/ICreateEditUser';

export enum UserActionType {
  GET_USERS_PENDING = 'FETCH_USERS_PENDING',
  GET_USERS_SUCCESS = 'FETCH_USERS_SUCCESS',
  GET_USERS_ERROR = 'FETCH_USERS_ERROR',
  ADD_USER = 'ADD_USER',
}

interface getUsersPending {
  type: UserActionType.GET_USERS_PENDING;
}

interface getUsersSuccess {
  type: UserActionType.GET_USERS_SUCCESS;
  payload: IStorageUser[];
}

interface getUsersError {
  type: UserActionType.GET_USERS_ERROR;
  payload: string;
}

interface addUser {
  type: UserActionType.GET_USERS_ERROR;
  payload: ICreateEditUser[];
}

export type UserActions =
  | getUsersPending
  | getUsersSuccess
  | getUsersError
  | addUser;
