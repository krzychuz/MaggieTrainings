import { FETCH_DISCIPLINES_ERROR, FETCH_DISCIPLINES_PENDING, FETCH_DISCIPLINES_SUCCESS } from '../actions/discipline';

const initialState = {
    disciplinesPending: false,
    disciplines: [],
    disciplinesError: null
}

export function disciplinesReducer(state = initialState, action) {
    switch (action.type) {
        // Fetch disciplines
        case FETCH_DISCIPLINES_PENDING:
            return {
                ...state,
                disciplinesPending: true
            }
        case FETCH_DISCIPLINES_SUCCESS:
            return {
                ...state,
                disciplinesPending: false,
                disciplines: action.disciplines
            }
        case FETCH_DISCIPLINES_ERROR:
            return {
                ...state,
                disciplinesPending: false,
                disciplinesError: action.error
            }

        default:
            return state;
    }
}

export const getDisciplines = state => state.disciplinesReducer.disciplines;
export const getDisciplinesPending = state => state.disciplinesReducer.disciplinesPending;
export const getDisciplinesError = state => state.disciplinesReducer.disciplinesError;
