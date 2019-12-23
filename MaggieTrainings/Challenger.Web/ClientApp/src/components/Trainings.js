import React, { PureComponent } from 'react';
import ProgressBar from 'react-bootstrap/ProgressBar'
import Button from 'react-bootstrap/Button'
import { Card, Grid } from "tabler-react";
import './Trainings.css';

export class Trainings extends PureComponent {

    constructor(props) {
        super(props);
        this.state = { dashboardData: [], trainingData: [], dashboardLoading: true, trainingsLoading: true};

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

    handleAddTraining() {
        fetch('MaggieTraining/AddTraining')
            .then(window.location.reload());
    }

    static renderTrainingTable(...trainingData) {
        return (
            <table className='table table-striped'>
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Data</th>
                    </tr>
                </thead>
                <tbody>
                    {trainingData.map(trainingData =>
                        <tr key={trainingData.id}>
                            <td>{trainingData.id}</td>
                            <td>{trainingData.addDate}</td>
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
            <div className="centered">
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

    render() {
        let trainingTable = this.state.trainingsLoading ? <p><em>Ładowanie...</em></p> : Trainings.renderTrainingTable(...this.state.trainingData);
        let dashboard = this.state.dashboardLoading ? <p><em>Ładowanie...</em></p> : Trainings.renderTrainingDashboard(this.state.dashboardData);
        let icons = Trainings.renderIcons();
        let progressBar = this.state.dashboardLoading ? <p><em>Ładowanie...</em></p> : Trainings.renderProgressBar(this.state.dashboardData);

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

                <div className ="centered">
                    <Button variant="primary" size="lg" onClick={this.handleAddTraining} >Zarejestruj nowy trening</Button>
                    &nbsp;
                </div>
            </div>
        );
    }
}
