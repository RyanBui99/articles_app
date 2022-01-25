// We need this to use useSelector  (You can Export this as a react-hook to use separately)
// https://redux.js.org/usage/usage-with-typescript#define-typed-hooks
// useSelector allows us to extract data from the Redux store.
import { useSelector, TypedUseSelectorHook } from 'react-redux';
import { RootState } from '../store/actions/combine';
export const useTypedSelector: TypedUseSelectorHook<RootState> = useSelector;