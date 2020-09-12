import { FETCH_TRAININGS_PENDING, FETCH_TRAININGS_SUCCESS, FETCH_TRAININGS_ERROR } from '../actions/training';
import { FETCH_DASHBOARD_DATA_PENDING, FETCH_DASHBOARD_DATA_SUCCESS, FETCH_DASHBOARD_DATA_ERROR } from '../actions/training';
import { DELETE_TRAINING_ERROR, DELETE_TRAINING_SUCCESS, DELETE_TRAINING_PENDING } from '../actions/training';
import { ADD_TRAINING_ERROR, ADD_TRAINING_SUCCESS, ADD_TRAINING_PENDING } from '../actions/training';
import { EDIT_TRAINING_ERROR, EDIT_TRAINING_SUCCESS, EDIT_TRAINING_PENDING } from '../actions/training';
import { initialState } from './initialState'

export function trainingsReducer(state = initialState, action) {
    switch (action.type) {
        // Fetch trainings
        case FETCH_TRAININGS_PENDING: 
            return {
                ...state,
                trainingsPending: true
            }
        case FETCH_TRAININGS_SUCCESS:
            return {
                ...state,
                trainingsPending: false,
                trainings: action.trainings
            }
        case FETCH_TRAININGS_ERROR:
            return {
                ...state,
                trainingsPending: false,
                trainingsError: action.error
            }

        // Delete training
        case DELETE_TRAINING_PENDING:
            return {
                ...state,
                deleteTrainingPending: true
            }
        case DELETE_TRAINING_SUCCESS:
            return {
                ...state,
                deleteTrainingPending: false
            }
        case DELETE_TRAINING_ERROR:
            return {
                ...state,
                deleteTrainingPending: false,
                deleteTrainingError: action.error
            }

        // Add training
        case ADD_TRAINING_PENDING:
            return {
                ...state,
                addTrainingPending: true
            }
        case ADD_TRAINING_SUCCESS:
            return {
                ...state,
                addTrainingPending: false
            }
        case ADD_TRAINING_ERROR:
            return {
                ...state,
                addTrainingPending: false,
                addTrainingError: action.error
            }

        // Edit training
        case EDIT_TRAINING_PENDING:
            return {
                ...state,
                editTrainingPending: true
            }
        case EDIT_TRAINING_SUCCESS:
            return {
                ...state,
                editTrainingPending: false
            }
        case EDIT_TRAINING_ERROR:
            return {
                ...state,
                editTrainingPending: false,
                editTrainingError: action.error
            }

        // Fetch dashboard data
        case FETCH_DASHBOARD_DATA_PENDING:
            return {
                ...state,
                dashboardDataPending: true
            }
        case FETCH_DASHBOARD_DATA_SUCCESS:
            return {
                ...state,
                dashboardDataPending: false,
                dashboardData: action.trainings
            }
        case FETCH_DASHBOARD_DATA_ERROR:
            return {
                ...state,
                dashboardDataPending: false,
                dashboardDataError: action.error
            }

        default: 
            return state;
    }
}

export const getTrainings = state => state.trainingsReducer.trainings;
export const getTrainingsPending = state => state.trainingsReducer.trainingsPending;
export const getTrainingsError = state => state.trainingsReducer.trainingsError;

export const getDashboardData = state => state.trainingsReducer.dashboardData;
export const getDashboardDataPending = state => state.trainingsReducer.dashboardDataPending;
export const getDashbaordDataError = state => state.trainingsReducer.dashboardDataError;

export const deleteTrainingSuccess = state => state.trainingsReducer.trainings;
export const deleteTrainingPending = state => state.trainingsReducer.deleteTrainingPending;
export const deleteTrainingError = state => state.trainingsReducer.deleteTrainingError;

export const addTrainingSuccess = state => state.trainingsReducer.trainings;
export const addTrainingPending = state => state.trainingsReducer.addTrainingPending;
export const addTrainingError = state => state.trainingsReducer.addTrainingError;

export const editTrainingSuccess = state => state.trainingsReducer.trainings;
export const editTrainingPending = state => state.trainingsReducer.editTrainingPending;
export const editTrainingError = state => state.trainingsReducer.editTrainingError;