import React, { PureComponent } from 'react';
import { TiDelete } from "react-icons/ti";

import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

import { deleteTrainingError, deleteTrainingPending, deleteTrainingSuccess } from '../../reducers/training'
import { deleteTraining, fetchTrainings } from '../../actions/trainingService'

class TrainingRecord extends PureComponent {
    
    constructor(props) {
        super(props);
        this.handleDeleteTraining = this.handleDeleteTraining.bind(this);
    }

    async handleDeleteTraining() {
        const { deleteTraining } = this.props;

        deleteTraining(this.props.id);
    }

    render() {
        return (
            <tr key={this.props.id}>
                <td>{this.props.addDate}</td>
                <td>{this.props.trainingResult.disciplineName}</td>
                <td>{this.props.trainingResult.trainingDuration}</td>
                <td><TiDelete onClick={this.handleDeleteTraining} className="link"/></td>
            </tr>
        )
    }
}

const mapStateToProps = state => ({
    deleteTrainingError: deleteTrainingError(state),
    deleteTrainingPending: deleteTrainingPending(state),
    deleteTrainingSuccess: deleteTrainingSuccess(state)
})

const mapDispatchToProps = dispatch => bindActionCreators({
    deleteTraining: deleteTraining,
    fetchTrainings: fetchTrainings
}, dispatch)

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(TrainingRecord);