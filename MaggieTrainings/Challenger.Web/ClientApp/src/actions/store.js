import { createStore, applyMiddleware, combineReducers } from "redux";
import { trainingsReducer} from '../reducers/training';
import { disciplinesReducer } from '../reducers/discipline'
import { initialState } from '../reducers/initialState'
import thunk from 'redux-thunk';

const middlewares = [thunk];

const rootReducer = combineReducers({
    trainingsReducer, 
    disciplinesReducer
})

export const store = createStore(rootReducer, applyMiddleware(...middlewares))