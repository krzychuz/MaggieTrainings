import React, { PureComponent } from 'react';
import { Collapse } from 'reactstrap';
import Button from 'react-bootstrap/Button';
import DisciplinesDropdown from './DisciplinesDropdown';
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";

export default class AddTraining extends PureComponent {
    
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

    handleAddTraining() {
        var selectedDiscipline = this.childRef.value;
        var trainingDuration = this.refs.trainingDuration.value;

        var data = new FormData();
        data.append("DisciplineName", selectedDiscipline);
        data.append("TrainingDuration", trainingDuration);
        data.append("TrainingDate", this.state.selectedDate.toLocaleDateString("pl-PL"));

        fetch("MaggieTraining/AddTraining", {
            method: "POST", 
            body: data
            })
        .then(() => {
            this.toggleAddTraining();
            this.props.onAdd();
        });

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
                            <DatePicker className="form-control col" selected={this.state.selectedDate} onChange={this.handleDateChange}/>
                            <div className="col">
                                <input type="text" className="form-control" placeholder="Czas trwania" ref="trainingDuration"/>
                            </div>
                            <DisciplinesDropdown setRef={this.setRef}/>
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