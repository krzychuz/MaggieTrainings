import React, { PureComponent } from 'react';
import { Card, Grid } from "tabler-react";

export default class TrainingDashboard extends PureComponent {
    
    constructor(props) {
        super(props);
        this.state = { dashboardData: [], dataLoading: true };
    }

    componentDidMount() {
        fetch('MaggieTraining/GetDashboardData')
        .then(response => response.json())
        .then(data => {
            this.setState({ dashboardData: data, isDataLoading: false });
        })
    }

    render() {
        if (this.state.isDataLoading)
            return null;

        return (
            <Grid.Row cards>
                <Grid.Col>
                    <Card title="Liczba treningów" body={this.state.dashboardData.numberOfTrainings} />
                </Grid.Col>
                <Grid.Col>
                    <Card title="Cel roczny" body={100} />
                </Grid.Col>
                <Grid.Col>
                    <Card title="Ostatni trening" body={this.state.dashboardData.lastTraining} />
                </Grid.Col>
            </Grid.Row>
        );
    }
}