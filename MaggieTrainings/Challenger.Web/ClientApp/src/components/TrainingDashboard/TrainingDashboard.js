import React, { PureComponent } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import { Card, Grid } from "tabler-react";

import { getDashboardData, getDashbaordDataError, getDashboardDataPending} from '../../reducers/training'
import { fetchDashboardData } from '../../actions/trainingService'

class TrainingDashboard extends PureComponent {
    
    constructor(props) {
        super(props);
        this.shouldComponentRender = this.shouldComponentRender.bind(this);
    }

    componentWillMount() {
        const { fetchDashboardData } = this.props;
        fetchDashboardData();
    }

    shouldComponentRender() {
        const { dashboardDataPending } = this.props;

        if (dashboardDataPending === undefined)
            return false;

        return !dashboardDataPending;
    }

    render() {
        const { dashboardData, dashboardDataError, dashboardDataPending } = this.props;

        if (!this.shouldComponentRender())
            return null;

        return (
            <Grid.Row cards>
                <Grid.Col>
                    <Card title="Liczba treningów" body={dashboardData.numberOfTrainings} />
                </Grid.Col>
                <Grid.Col>
                    <Card title="Cel roczny" body={100} />
                </Grid.Col>
                <Grid.Col>
                    <Card title="Ostatni trening" body={dashboardData.lastTraining} />
                </Grid.Col>
            </Grid.Row>
        );
    }
}

const mapStateToProps = state => ({
    dashboardDataError: getDashbaordDataError(state),
    dashboardData: getDashboardData(state),
    dashboardDataPending: getDashboardDataPending(state)
})

const mapDispatchToProps = dispatch => bindActionCreators({
    fetchDashboardData: fetchDashboardData
}, dispatch)

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(TrainingDashboard);