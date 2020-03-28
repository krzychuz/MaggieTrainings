import React, { PureComponent } from 'react';

export default class DisciplinesDropdown extends PureComponent {
    
    constructor(props) {
        super(props);
        this.state = {disciplinesData: [], isDataLoading: true}
    }

    componentDidMount() {
        fetch('MaggieTraining/GetDisciplines')
        .then(response => response.json())
        .then(data => {
            this.setState({ disciplinesData: data, isDataLoading: false });
        });
    }

    render() {
        if (this.state.isDataLoading)
            return null;

        return (
            <div className="col">
                <label className="mr-sm-2 sr-only">Preference</label>
                <select className="custom-select mr-sm-2 bottom-spacing-medium" defaultValue={"Default"} ref={this.props.setRef}>
                    <option value="Default" disabled>Wybierz dyscyplinę...</option>
                    {this.state.disciplinesData.map(disciplinesData =>
                        <option key={disciplinesData.id} value={disciplinesData.description}>{disciplinesData.description}</option>
                    )}
                </select>
            </div>
        );
    }
}