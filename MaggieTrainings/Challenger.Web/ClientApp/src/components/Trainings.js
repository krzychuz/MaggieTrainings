import React, { PureComponent } from 'react';
import ProgressBar from 'react-bootstrap/ProgressBar'
import Button from 'react-bootstrap/Button'
import { Card, Grid } from "tabler-react";
import './Trainings.css';
import { Collapse } from 'reactstrap';

export class Trainings extends PureComponent {

    constructor(props) {
        super(props);
        this.state = { dashboardData: [], trainingData: [], disciplinesData: [],
            dashboardLoading: true, trainingsLoading: true, isAddTrainingOpened: false};

        this.loadData();
    }

    handleAddTraining() {
        var selectedDiscipline = this.refs.selectedDiscipline.value;
        var trainingDuration = this.refs.trainingDuration.value;

        var data = new FormData();
        data.append("DisciplineName", selectedDiscipline);
        data.append("TrainingDuration", trainingDuration);

        // TODO - understand why I cannot send it as JSON and have to use FormData HTML5 object
        // Problem is - JSON is double-endoded thus cannot be parsed by API

        fetch("MaggieTraining/AddTraining", {
            method: "POST", 
            body: data
            })
        .then(() => {
            this.loadData().bind(this);
            this.toggleAddTraining();
        });

    }

    loadData() {
        fetch('MaggieTraining/GetDashboardData')
            .then(response => response.json())
            .then(data => {
                this.setState({ dashboardData: data, dashboardLoading: false });
            })

        fetch('MaggieTraining/GetAllTrainings')
            .then(response => response.json())
            .then(data => {
                this.setState({ trainingData: data, trainingsLoading: false });
            });
    }

    toggleAddTraining() {
        fetch('MaggieTraining/GetDisciplines')
            .then(response => response.json())
            .then(data => {
                this.setState({ disciplinesData: data, isAddTrainingOpened: !this.state.isAddTrainingOpened });
            });
    }

    static renderTrainingTable(...trainingData) {
        return (
            <table className='table table-striped'>
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Data</th>
                        <th>Aktywność</th>
                        <th>Czas trwania</th>
                    </tr>
                </thead>
                <tbody>
                    {trainingData.map(trainingData =>
                        <tr key={trainingData.id}>
                            <td>{trainingData.id}</td>
                            <td>{trainingData.addDate}</td>
                            <td>{trainingData.trainingResult.disciplineName}</td>
                            <td>{trainingData.trainingResult.trainingDuration}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    static renderTrainingDashboard(dashboardData) {
        return (
            <Grid.Row cards>
                <Grid.Col>
                    <Card title="Liczba treningów" body={dashboardData.numberOfTrainings} />
                </Grid.Col>
                <Grid.Col>
                    <Card
                        title="Cel roczny"
                        body={100}
                    />
                </Grid.Col>
                <Grid.Col>
                    <Card title="Ostatni trening" body={dashboardData.lastTraining} />
                </Grid.Col>
            </Grid.Row>
            );
    }

    static renderIcons() {
        return (
            <div className="text-center">
                <img className="sport" alt="Sailing icon" src={require("./svg/sailing.svg")} />
                <img className="sport" alt="Gymnastics icon" src={require("./svg/artistic_gymnastics.svg")} />
                <img className="sport" alt="Athletics icon" src={require("./svg/athletics.svg")} />
                <img className="sport" alt="Cycling icon" src={require("./svg/cycling_road.svg")} />
                <img className="sport" alt="Swimming icon" src={require("./svg/swimming.svg")} />
                <img className="sport" alt="Volleyball icon" src={require("./svg/volleyball.svg")} />
            </div>
            );
    }

    static renderProgressBar(trainingData) {
        return (
            <ProgressBar animated now={trainingData.numberOfTrainings} />
            );
    }

    static renderDisciplinesDropdown(...disciplinesData) {
        return (
            <div class="col">
                <label class="mr-sm-2 sr-only" for="inlineFormCustomSelect">Preference</label>
                <select class="custom-select mr-sm-2 bottom-spacing-medium" id="inlineFormCustomSelect" ref="selectedDiscipline">
                    <option selected>Wybierz aktywność...</option>
                    {disciplinesData.map(disciplinesData =>
                        <option value={disciplinesData.description}>{disciplinesData.description}</option>
                    )}
                </select>
            </div>
        );
    }

    render() {
        let trainingTable = this.state.trainingsLoading ? <p><em>Ładowanie...</em></p> : Trainings.renderTrainingTable(...this.state.trainingData);
        let dashboard = this.state.dashboardLoading ? <p><em>Ładowanie...</em></p> : Trainings.renderTrainingDashboard(this.state.dashboardData);
        let icons = Trainings.renderIcons();
        let progressBar = this.state.dashboardLoading ? <p><em>Ładowanie...</em></p> : Trainings.renderProgressBar(this.state.dashboardData);
        let disciplinesDropdown = Trainings.renderDisciplinesDropdown(...this.state.disciplinesData);

        return (
            <div>
                <div>
                    {icons}
                </div>

                <div>
                    &nbsp;
                    <h1>Podsumowanie treningów</h1>
                    {dashboard}
                </div>

                <div>
                    &nbsp;
                    <h1>Postępy</h1>
                    {progressBar}
                </div>

                <div>
                    &nbsp;
                    <h1>Ostatnie treningi</h1>
                    {trainingTable}
                </div>

                <div className ="text-center bottom-spacing-big">
                    <Button variant="primary" size="lg" onClick={this.toggleAddTraining.bind(this)}>Zarejestruj nowy trening</Button>
                    &nbsp;
                </div>

                <Collapse isOpen={this.state.isAddTrainingOpened}>
                <form>
                    <div class="form-row">
                        <div class="col">
                            <input type="text" class="form-control" placeholder="Czas trwania" ref="trainingDuration"/>
                        </div>
                        {disciplinesDropdown}
                    </div>
                </form>
                    <div class="text-center bottom-spacing">
                        
                        <div class="col-auto my-1">
                            <button type="submit" class="btn btn-primary bottom-spacing-big" onClick={this.handleAddTraining.bind(this)}>Dodaj</button>
                        </div>
                    </div>
                </Collapse>

            </div>
        );
    }
}
