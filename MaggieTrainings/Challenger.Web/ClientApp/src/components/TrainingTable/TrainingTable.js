import React, { Component } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

import { fetchTrainings, deleteTraining, addTraining, editTraining } from '../../actions/trainingService';

import { deleteTrainingError, deleteTrainingPending, deleteTrainingSuccess } from '../../reducers/training'
import { getTrainings, getTrainingsError, getTrainingsPending } from '../../reducers/training';
import { addTrainingError, addTrainingPending, addTrainingSuccess } from '../../reducers/training'
import { editTrainingError, editTrainingPending, editTrainingSuccess } from '../../reducers/training'

import MaterialTable, { Column } from 'material-table';


class TrainingTable extends Component {
    
    constructor(props) {
        super(props);
        this.shouldComponentRender = this.shouldComponentRender.bind(this);
    }

    componentDidMount() {
        const { fetchTrainings } = this.props;
        fetchTrainings();
    }

    shouldComponentRender() {
        const { trainingsPending } = this.props;

        if (trainingsPending === undefined)
            return false;

        return !trainingsPending;
    }

    async handleAddTraining(training) {
        const { addTraining } = this.props;

        var trainingData = {
            discipline: training.trainingResult.disciplineName,
            duration: training.trainingResult.trainingDuration,
            date: training.addDate.toLocaleDateString("pl-PL")
        }

        addTraining(trainingData);
    }

    async handleDeleteTraining(training) {
        const { deleteTraining } = this.props;

        deleteTraining(training.id);
    }

    async handleEditTraining(training) {
        const { editTraining } = this.props;

        var trainingData = {
            id: training.id,
            discipline: training.trainingResult.disciplineName,
            duration: training.trainingResult.trainingDuration,
            date: training.addDate
        }

        editTraining(trainingData);
    }

    render() {
        const { trainings } = this.props;

        if (!this.shouldComponentRender())
            return (
                <div className="d-flex justify-content-center">
                    <div className="spinner-border text-primary" role="status">
                        <span className="sr-only">Loading...</span>
                    </div>
                </div>
            )

        return (
            <MaterialTable
                title="Ostatnie treningi"
                columns={[
                    { title: 'Data', field: 'addDate', type: 'date' },
                    { title: 'Dyscyplina', field: 'trainingResult.disciplineName' },
                    { title: 'Czas trwania', field: 'trainingResult.trainingDuration' },
                ]}
                data={trainings}
                editable={{
                    onRowUpdate: (newData, oldData) => this.handleEditTraining(newData),
                    onRowDelete: (oldData) => this.handleDeleteTraining(oldData),
                    onRowAdd: (newData) => this.handleAddTraining(newData)
                }}
                options={{
                    search: false,
                    pageSize: 10,
                    filtering: true
                }}
                localization={{
                    body: {
                        addTooltip: 'Dodaj trening',
                        emptyDataSourceMessage: 'Nie znaleziono żadnych treningów',
                        editTooltip: 'Edytuj',
                        deleteTooltip: 'Usuń',
                        editRow: {
                            deleteText: 'Czy na pewno chcesz usunąć ten trening?',
                            cancelTooltip: 'Anuluj',
                            saveTooltip: 'Zapisz'
                        },
                        filterRow: {
                            filterTooltip: 'Filtruj'
                        }
                    },
                    toolbar: {
                        searchTooltip: 'Szukaj'
                    },
                    pagination: {
                        labelRowsSelect: 'na stronie',
                        labelDisplayedRows: '{from}-{to} z {count}',
                        firstTooltip: 'Pierwsza strona',
                        previousTooltip: 'Poprzednia strona',
                        nextTooltip: 'Następna strona',
                        lastTooltip: 'Ostatnia strona'
                    },
                    header: {
                        actions: 'Akcje'
                    }
                }}
            />
        );

    }
}

const mapStateToProps = state => ({
    trainingsError: getTrainingsError(state),
    trainings: getTrainings(state),
    trainingsPending: getTrainingsPending(state),
    deleteTrainingError: deleteTrainingError(state),
    deleteTrainingPending: deleteTrainingPending(state),
    deleteTrainingSuccess: deleteTrainingSuccess(state),
    addTrainingError: addTrainingError(state),
    addTrainingPending: addTrainingPending(state),
    addTrainingSuccess: addTrainingSuccess(state),
    editTrainingError: editTrainingError(state),
    editTrainingPending: editTrainingPending(state),
    editTrainingSuccess: editTrainingSuccess(state)
})

const mapDispatchToProps = dispatch => bindActionCreators({
    fetchTrainings: fetchTrainings,
    deleteTraining: deleteTraining,
    addTraining: addTraining,
    editTraining: editTraining
}, dispatch)

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(TrainingTable);