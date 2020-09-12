export const FETCH_TRAININGS_PENDING = 'FETCH_TRAININGS_PENDING';
export const FETCH_TRAININGS_SUCCESS = 'FETCH_TRAININGS_SUCCESS';
export const FETCH_TRAININGS_ERROR = 'FETCH_TRAININGS_ERROR';

export const FETCH_DASHBOARD_DATA_PENDING = 'FETCH_DASHBOARD_DATA_PENDING';
export const FETCH_DASHBOARD_DATA_SUCCESS = 'FETCH_DASHBOARD_DATA_SUCCESS';
export const FETCH_DASHBOARD_DATA_ERROR = 'FETCH_DASHBOARD_DATA_ERROR';

export const DELETE_TRAINING_PENDING = 'DELETE_TRAINING_PENDING';
export const DELETE_TRAINING_SUCCESS = 'DELETE_TRAINING_SUCCESS';
export const DELETE_TRAINING_ERROR = 'DELETE_TRAINING_ERROR';

export const ADD_TRAINING_PENDING = 'ADD_TRAINING_PENDING';
export const ADD_TRAINING_SUCCESS = 'ADD_TRAINING_SUCCESS';
export const ADD_TRAINING_ERROR = 'ADD_TRAINING_ERROR';

export const EDIT_TRAINING_PENDING = 'EDIT_TRAINING_PENDING';
export const EDIT_TRAINING_SUCCESS = 'EDIT_TRAINING_SUCCESS';
export const EDIT_TRAINING_ERROR = 'EDIT_TRAINING_ERROR';

export function fetchTrainingsPending() {
    return {
        type: FETCH_TRAININGS_PENDING
    }
}

export function fetchTrainingsSuccess(trainings) {
    return {
        type: FETCH_TRAININGS_SUCCESS,
        trainings: trainings
    }
}

export function fetchTrainingsError(error) {
    return {
        type: FETCH_TRAININGS_ERROR,
        error: error
    }
}

export function deleteTrainingPending() {
    return {
        type: DELETE_TRAINING_PENDING
    }
}

export function deleteTrainingSuccess() {
    return {
        type: DELETE_TRAINING_SUCCESS
    }
}

export function deleteTrainingError(error) {
    return {
        type: DELETE_TRAINING_ERROR,
        error: error
    }
}

export function fetchDashboardDataPending() {
    return {
        type: FETCH_DASHBOARD_DATA_PENDING
    }
}

export function addTrainingSuccess() {
    return {
        type: ADD_TRAINING_SUCCESS
    }
}

export function addTrainingPending() {
    return {
        type: ADD_TRAINING_PENDING
    }
}

export function addTrainingError(error) {
    return {
        type: ADD_TRAINING_ERROR,
        error: error
    }
}

export function fetchDashboardDataSuccess(trainings) {
    return {
        type: FETCH_DASHBOARD_DATA_SUCCESS,
        trainings: trainings
    }
}

export function fetchDashboardDataError(error) {
    return {
        type: FETCH_DASHBOARD_DATA_ERROR,
        error: error
    }
}

export function editTrainingSuccess() {
    return {
        type: EDIT_TRAINING_SUCCESS
    }
}

export function editTrainingPending() {
    return {
        type: EDIT_TRAINING_PENDING
    }
}

export function editTrainingError(error) {
    return {
        type: EDIT_TRAINING_ERROR,
        error: error
    }
}