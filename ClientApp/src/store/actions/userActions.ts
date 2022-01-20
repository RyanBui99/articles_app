import IStorageUser from '../../interfaces/IStorageUser';
import { type } from 'os';

export enum UserActionType {
  GET_USERS_PENDING = 'FETCH_USERS_PENDING',
  GET_USERS_SUCCESS = 'FETCH_USERS_SUCCESS',
  GET_USERS_ERROR = 'FETCH_USERS_ERROR',
  ADD_USER_SUCCESS = 'ADD_USER_SUCCESS',
  ADD_USER_PENDING = 'ADD_USER_PENDING',
  ADD_USER_ERROR = 'ADD_USER_ERROR',
  UPDATE_USER_SUCCESS = 'UPDATE_USER_SUCCESS',
  UPDATE_USER_PENDING = 'UPDATE_USER_PENDING',
  UPDATE_USER_ERROR = 'UPDATE_USER_ERROR',
  DELETE_USER_SUCCESS = 'DELETE_USER_SUCCESS',
  DELETE_USER_PENDING = 'DELETE_USER_PENDING',
  DELETE_USER_ERROR = 'DELETE_USER_ERROR',
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

interface addUserPending {
  type: UserActionType.ADD_USER_PENDING;
}

interface addUserSuccess {
  type: UserActionType.ADD_USER_SUCCESS;
  payload: IStorageUser[];
}

interface addUserError {
  type: UserActionType.ADD_USER_ERROR;
  payload: string;
}

interface updateUserPending {
  type: UserActionType.UPDATE_USER_PENDING;
}

interface updateUserSuccess {
  type: UserActionType.UPDATE_USER_SUCCESS;
  payload: IStorageUser[];
}

interface updateUserError {
  type: UserActionType.UPDATE_USER_ERROR;
  payload: string;
}

interface deleteUserPending {
  type: UserActionType.DELETE_USER_PENDING;
}

interface deleteUserSuccess {
  type: UserActionType.DELETE_USER_SUCCESS;
  payload: IStorageUser[];
}

interface deleteUserError {
  type: UserActionType.DELETE_USER_ERROR;
  payload: string;
}

export type UserActions =
  | getUsersPending
  | getUsersSuccess
  | getUsersError
  | addUserPending
  | addUserSuccess
  | addUserError
  | updateUserPending
  | updateUserSuccess
  | updateUserError
  | deleteUserPending
  | deleteUserSuccess
  | deleteUserError
