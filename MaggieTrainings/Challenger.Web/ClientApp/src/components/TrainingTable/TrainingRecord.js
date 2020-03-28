import React, { PureComponent } from 'react';
import { TiDelete } from "react-icons/ti";

export default class TrainingRecord extends PureComponent {
    
    constructor(props) {
        super(props);
        this.handleDeleteTraining = this.handleDeleteTraining.bind(this);
    }

    handleDeleteTraining() {

        var data = new FormData();
        data.append("id", this.props.id);

        fetch("MaggieTraining/DeleteTraining", {
            method: "DELETE", 
            body: data
            })
        .then(() => {
            this.props.onDelete();
        });
    }

    render() {
        return (
            <tr key={this.props.id}>
                <td>{this.props.addDate}</td>
                <td>{this.props.trainingResult.disciplineName}</td>
                <td>{this.props.trainingResult.trainingDuration}</td>
                <td><TiDelete onClick={this.handleDeleteTraining} className="link"/></td>
            </tr>
        )
    }
}