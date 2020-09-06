import React, { PureComponent } from 'react';
import ProgressBar from 'react-bootstrap/ProgressBar'

import { getDashboardData, getDashbaordDataError, getDashboardDataPending } from '../../reducers/training'
import { fetchDashboardData } from '../../actions/trainingService'

import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

class TrainingProgressBar extends PureComponent {

    shouldComponentRender() {
        const { dashboardDataPending } = this.props;

        if (dashboardDataPending === undefined)
            return false;

        return !dashboardDataPending;
    }

    render() {
        const { dashboardData } = this.props;

        if (!this.shouldComponentRender())
            return null;

        return (
            <ProgressBar animated now={dashboardData.numberOfTrainings} />
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
)(TrainingProgressBar);