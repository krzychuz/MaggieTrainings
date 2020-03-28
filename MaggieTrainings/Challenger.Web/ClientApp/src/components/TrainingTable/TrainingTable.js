import React, { PureComponent } from 'react';
import TrainingRecord from './TrainingRecord'

export default class TrainingTable extends PureComponent {
    
    constructor(props) {
        super(props);
        this.state = { trainingData: [], isDataLoading: true};
    }

    componentDidMount() {
        fetch('MaggieTraining/GetAllTrainings')
        .then(response => response.json())
        .then(data => {
            this.setState({ trainingData: data, isDataLoading: false});
        });
    }

    render() {
        if (this.state.isDataLoading)
            return null;

        return (<table className='table table-striped'>
            <thead>
                <tr>
                    <th>Data</th>
                    <th>Aktywność</th>
                    <th>Czas trwania</th>
                    <th>Akcja</th>
                </tr>
            </thead>
            <tbody>
                {this.state.trainingData.map(trainingData =>
                    <TrainingRecord key={trainingData.id}
                                    id={trainingData.id}
                                    addDate={trainingData.addDate}
                                    trainingResult={trainingData.trainingResult}
                                    onDelete={this.props.onDelete}/>)}
            </tbody>
        </table>);
    }
}