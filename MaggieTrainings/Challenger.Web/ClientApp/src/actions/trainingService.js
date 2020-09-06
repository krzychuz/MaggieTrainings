import { fetchTrainingsError, fetchTrainingsSuccess, fetchTrainingsPending } from './training';
import { fetchDashboardDataError, fetchDashboardDataSuccess, fetchDashboardDataPending } from './training';
import { deleteTrainingPending, deleteTrainingError, deleteTrainingSuccess } from './training'
import { addTrainingPending, addTrainingSuccess, addTrainingError } from './training';

export function fetchTrainings() {
    return dispatch => {
        dispatch(fetchTrainingsPending());
        fetch('api/trainings')
            .then(res => res.json())
            .then(res => {
                if(res.error) {
                    throw(res.error);
                }
                dispatch(fetchTrainingsSuccess(res));
                return res;
            })
            .catch(error => {
                dispatch(fetchTrainingsError(error));
            })
    }
}

export function deleteTraining(id) {
    return dispatch => {
        dispatch(deleteTrainingPending());
        fetch(`api/trainings/${id}`, {
            method: 'DELETE'
        })
            .then(() => {
                dispatch(deleteTrainingSuccess());
                dispatch(fetchTrainings());
                dispatch(fetchDashboardData());
            })
            .catch(error => {
                dispatch(deleteTrainingError(error));
            })
    }
}

export function addTraining(training) {

    var trainingData = new FormData();
    trainingData.append("DisciplineName", training.discipline);
    trainingData.append("TrainingDuration", training.duration);
    trainingData.append("TrainingDate", training.date);

    return dispatch => {
        dispatch(addTrainingPending())
        fetch(`api/trainings`, {
            method: 'POST',
            body: trainingData
        })
            .then(() => {
                dispatch(addTrainingSuccess());
                dispatch(fetchTrainings());
                dispatch(fetchDashboardData());
            })
            .catch(error => {
                dispatch(addTrainingError(error));
            })
    }
}

export function fetchDashboardData() {
    return dispatch => {
        dispatch(fetchDashboardDataPending());
        fetch(`api/trainings/dashboardData`)
            .then(res => res.json())
            .then(res => {
                if (res.error) {
                    throw (res.error);
                }
                dispatch(fetchDashboardDataSuccess(res));
                return res;
            })
            .catch(error => {
                dispatch(fetchDashboardDataError(error));
            })
    }
}