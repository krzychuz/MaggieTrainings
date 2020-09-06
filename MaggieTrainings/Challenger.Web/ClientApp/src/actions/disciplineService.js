import { fetchDisciplinesError, fetchDisciplinesPending, fetchDisciplinesSuccess} from './discipline';

export function fetchDisciplines() {
    return dispatch => {
        dispatch(fetchDisciplinesPending());
        fetch('api/disciplines')
            .then(res => res.json())
            .then(res => {
                if (res.error) {
                    throw (res.error);
                }
                dispatch(fetchDisciplinesSuccess(res));
                return res;
            })
            .catch(error => {
                dispatch(fetchDisciplinesError(error));
            })
    }
}