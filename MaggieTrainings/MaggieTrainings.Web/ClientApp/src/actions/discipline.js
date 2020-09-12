export const FETCH_DISCIPLINES_PENDING = 'FETCH_DISCIPLINES_PENDING';
export const FETCH_DISCIPLINES_SUCCESS = 'FETCH_DISCIPLINES_SUCCESS';
export const FETCH_DISCIPLINES_ERROR = 'FETCH_DISCIPLINES_ERROR';

export function fetchDisciplinesPending() {
    return {
        type: FETCH_DISCIPLINES_PENDING
    }
}

export function fetchDisciplinesSuccess(disciplines) {
    return {
        type: FETCH_DISCIPLINES_SUCCESS,
        disciplines: disciplines
    }
}

export function fetchDisciplinesError(error) {
    return {
        type: FETCH_DISCIPLINES_ERROR,
        error: error
    }
}