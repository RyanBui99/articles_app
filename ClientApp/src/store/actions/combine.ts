import { type } from "os";
import { combineReducers } from "redux";
import { userReducer } from '../reducers/userReducer';

// Combine reducers into 1 object. Blogposts will be placed soon
const reducers = combineReducers({
    users: userReducer
})

export default reducers
export type RootState = ReturnType<typeof reducers>