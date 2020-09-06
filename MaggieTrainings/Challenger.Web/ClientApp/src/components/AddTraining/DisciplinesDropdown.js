import React, { PureComponent } from 'react';

import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

import { getDisciplines, getDisciplinesError, getDisciplinesPending } from '../../reducers/discipline'
import { fetchDisciplines } from '../../actions/disciplineService'

class DisciplinesDropdown extends PureComponent {
    
    constructor(props) {
        super(props);
        this.state = {disciplinesData: [], isDataLoading: true}
    }

    componentWillMount() {
        const { fetchDisciplines } = this.props;
        fetchDisciplines();
    }

    shouldComponentRender() {
        const { disciplinesPending } = this.props;

        if (disciplinesPending === undefined)
            return false;

        return !disciplinesPending;
    }

    render() {
        const { disciplines, disciplinesError, disciplinesPending } = this.props;

        if (!this.shouldComponentRender())
            return null;

        return (
            <div>
                <label className="mr-sm-2 sr-only">Preference</label>
                <select className="custom-select mr-sm-2 bottom-spacing-medium" defaultValue={"Default"} ref={this.props.setRef}>
                    <option value="Default" disabled>Wybierz dyscyplinę...</option>
                    {disciplines.map(disciplinesData =>
                        <option key={disciplinesData.id} value={disciplinesData.description}>{disciplinesData.description}</option>
                    )}
                </select>
            </div>
        );
    }
}

const mapStateToProps = state => ({
    disciplines: getDisciplines(state),
    disciplinesError: getDisciplinesError(state),
    disciplinesPending: getDisciplinesPending(state)
})

const mapDispatchToProps = dispatch => bindActionCreators({
    fetchDisciplines: fetchDisciplines
}, dispatch)

export default connect(
    mapStateToProps,
    mapDispatchToProps
)(DisciplinesDropdown);