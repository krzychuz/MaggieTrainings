import React, { PureComponent } from 'react';
import ProgressBar from 'react-bootstrap/ProgressBar'
import Button from 'react-bootstrap/Button'
import { Card, Grid } from "tabler-react";
import './Trainings.css';

export class Trainings extends PureComponent {

    constructor(props) {
        super(props);
        this.state = { trainingData: [], loading: true };

        fetch('MaggieTraining/GetDashboardData')
            .then(response => response.json())
            .then(data => {
                this.setState({ trainingData: data, loading: false });
            })

    }

    handleClick() {
        fetch('MaggieTraining/AddTraining')
            .then(window.location.reload());
    }

    render() {
        return (
            <div>
                <h1>Podsumowanie treningów</h1>
                &nbsp;
                <Grid.Row cards>
                    <Grid.Col>
                        <Card title="Liczba treningów" body={this.state.trainingData.numberOfTrainings} />
                    </Grid.Col>
                    <Grid.Col>
                        <Card
                            title="Cel roczny"
                            body={100}
                        />
                    </Grid.Col>
                    <Grid.Col>
                        <Card title="Ostatni trening" body={this.state.trainingData.lastTraining} />
                    </Grid.Col>
                </Grid.Row>
                &nbsp;
                <ProgressBar animated now={this.state.trainingData.numberOfTrainings} />
                <div className ="centered">
                    <Button variant="primary" size="lg" onClick={this.handleClick} >Zarejestruj nowy trening</Button>
                </div>
                <div className="centered">
                    <img className="sport" alt="Golf icon" src={require("./svg/sailing.svg")} />
                    <img className="sport" alt="Golf icon" src={require("./svg/artistic_gymnastics.svg")} />
                    <img className="sport" alt="Golf icon" src={require("./svg/athletics.svg")} />
                    <img className="sport" alt="Golf icon" src={require("./svg/cycling_road.svg")} />
                    <img className="sport" alt="Golf icon" src={require("./svg/swimming.svg")} />
                    <img className="sport" alt="Golf icon" src={require("./svg/volleyball.svg")} />
                </div>
                
            </div>
        );
    }
}
