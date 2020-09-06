import React, { PureComponent } from 'react';

export default class TrainingHeader extends PureComponent {

    render() {
        return (
            <div className="text-center">
                <img className="sport" alt="Sailing icon" src={require("../svg/sailing.svg")} />
                <img className="sport" alt="Gymnastics icon" src={require("../svg/artistic_gymnastics.svg")} />
                <img className="sport" alt="Athletics icon" src={require("../svg/athletics.svg")} />
                <img className="sport" alt="Cycling icon" src={require("../svg/cycling_road.svg")} />
                <img className="sport" alt="Swimming icon" src={require("../svg/swimming.svg")} />
                <img className="sport" alt="Volleyball icon" src={require("../svg/volleyball.svg")} />
            </div>);
    }
}