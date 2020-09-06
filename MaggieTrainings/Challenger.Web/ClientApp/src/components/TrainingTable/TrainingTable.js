import React, { Component } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

import { getTrainings, getTrainingsError, getTrainingsPending } from '../../reducers/training'
import { fetchTrainings } from '../../actions/trainingService'

import TrainingRecord from './TrainingRecord'


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

        return (<table className='table table-striped'>
            <thead>
                <tr>
                    <th>Data</th>
                    <th>Aktywność</th>
                    <th>Czas trwania</th>
                    <th>Akcja</th>
                </tr>
            </thead>
            <tbody>
                {trainings.map(trainingData =>
                    <TrainingRecord key={trainingData.id}
                                    id={trainingData.id}
                                    addDate={trainingData.addDate}
                                    trainingResult={trainingData.trainingResult}
                                    onDelete={this.props.onDelete}/>)}
            </tbody>
        </table>);
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