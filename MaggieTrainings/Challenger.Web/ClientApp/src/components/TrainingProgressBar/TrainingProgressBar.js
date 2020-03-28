import React, { PureComponent } from 'react';
import ProgressBar from 'react-bootstrap/ProgressBar'

export default class TrainingProgressBar extends PureComponent {
    
    constructor(props) {
        super(props);
        this.state = { trainingData: [], isDataLoading: true };
    }

    componentDidMount() {
        fetch('MaggieTraining/GetDashboardData')
        .then(response => response.json())
        .then(data => {
            this.setState({ trainingData: data, isDataLoading: false });
        })
    }

    render() {
        if (this.state.isDataLoading)
            return null;

        return (
            <ProgressBar animated now={this.state.trainingData.numberOfTrainings} />
        );
    }
}