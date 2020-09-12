import React, { PureComponent } from 'react';
import { Collapse } from 'reactstrap';
import Button from 'react-bootstrap/Button';
import DisciplinesDropdown from './DisciplinesDropdown';
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";

import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

import { addTrainingError, addTrainingPending, addTrainingSuccess } from '../../reducers/training'
import { fetchTrainings, addTraining } from '../../actions/trainingService'

class AddTraining extends PureComponent {
    
    constructor(props) {
        super(props);
        this.state = { disciplinesData: [], isAddTrainingOpened: false, selectedDate: new Date()};
        this.toggleAddTraining = this.toggleAddTraining.bind(this)
        this.handleAddTraining = this.handleAddTraining.bind(this)
        this.setRef = this.setRef.bind(this);
    }

    toggleAddTraining() {
        this.setState({ isAddTrainingOpened: !this.state.isAddTrainingOpened });
    }

    handleDateChange = date => {
        this.setState({
          selectedDate: date
        });
      };

    async handleAddTraining() {
        const { addTraining } = this.props;

        var trainingData = {
            discipline: this.childRef.value,
            duration: this.refs.trainingDuration.value,
            date: this.state.selectedDate.toLocaleDateString("pl-PL")
        }

        addTraining(trainingData);
    }

    setRef(reference) {
        this.childRef = reference;
    }

    render() {
        return (
            <div className="top-spacing-big">
                <div className ="text-center bottom-spacing-big">
                    <Button variant="primary" size="lg" onClick={this.toggleAddTraining}>Zarejestruj nowy trening</Button>
                    &nbsp;
                </div>

                <Collapse isOpen={this.state.isAddTrainingOpened}>
                    <form>
                        <div className="form-row">
                            <div className="col">
                                <DatePicker className="form-control col" selected={this.state.selectedDate} onChange={this.handleDateChange}/>
                            </div>
                            <div className="col">
                                <input type="text" className="form-control" placeholder="Czas trwania" ref="trainingDuration"/>
                            </div>
                            <div className="col">
                                <DisciplinesDropdown setRef={this.setRef}/>
                            </div>
                        </div>
                    </form>
                    <div className="text-center bottom-spacing">
                        <div className="col-auto my-1">
                            <button type="submit" className="btn btn-primary bottom-spacing-big" onClick={this.handleAddTraining}>Dodaj</button>
                        </div>
                    </div>
                </Collapse>
            </div>
        );
    }
}

const mapStateToProps = state => ({
    addTrainingError: addTrainingError(state),
    addTrainingPending: addTrainingPending(state),
    addTrainingSuccess: addTrainingSuccess(state)
})

const mapDispatchToProps = dispatch => bindActionCreators({
    addTraining: addTraining,
    fetchTrainings: fetchTrainings
}, dispatch)

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(AddTraining);