import { createStore, applyMiddleware, combineReducers } from "redux";
import { trainingsReducer} from '../reducers/training';
import { disciplinesReducer } from '../reducers/discipline'

import thunk from 'redux-thunk';
import logger from "redux-logger";
import promise from "redux-promise-middleware";

const rootReducer = combineReducers({
    trainingsReducer, 
    disciplinesReducer
})

export const store = createStore(rootReducer, applyMiddleware(thunk, logger, promise))