import React, { PureComponent } from 'react';
import './Trainings.css';
import TrainingTable from './TrainingTable/TrainingTable';
import TrainingHeader from './TrainingHeader/TrainingHeader';
import TrainingDashboard from './TrainingDashboard/TrainingDashboard';
import TrainingProgressBar from './TrainingProgressBar/TrainingProgressBar';

export class Trainings extends PureComponent {

    render() {
        return (
            <div>
                <TrainingHeader />

                <div>
                    &nbsp;
                    <h1>Podsumowanie treningów</h1>
                    <TrainingDashboard />
                </div>

                <div>
                    &nbsp;
                    <h1>Postępy</h1>
                    <TrainingProgressBar />
                </div>

                <div>
                    &nbsp;
                    <TrainingTable />
                </div>

            </div>
        );
    }
}
