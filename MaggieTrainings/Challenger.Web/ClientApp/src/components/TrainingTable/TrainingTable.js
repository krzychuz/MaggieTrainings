import React, { Component } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

import { getTrainings, getTrainingsError, getTrainingsPending } from '../../reducers/training';
import { fetchTrainings } from '../../actions/trainingService';

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
                    onRowUpdate: (newData, oldData) => {

                    },
                    onRowDelete: (oldData) => {

                    },
                    onRowAdd: (newData) => {

                    }
                }}
                options={{
                    search: false,
                    pageSize: 10,
                    filtering: true
                }}
            />
        );

    }
}

const mapStateToProps = state => ({
    trainingsError: getTrainingsError(state),
    trainings: getTrainings(state),
    trainingsPending: getTrainingsPending(state)
})

const mapDispatchToProps = dispatch => bindActionCreators({
    fetchTrainings: fetchTrainings
}, dispatch)

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(TrainingTable);