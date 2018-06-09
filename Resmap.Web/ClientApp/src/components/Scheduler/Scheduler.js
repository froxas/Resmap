import React, {Component} from 'react';
import {DayPilotScheduler} from "daypilot-pro-react";
import {DayPilot} from "daypilot-pro-react";

export class Scheduler extends Component {
    displayName = Scheduler.name
    constructor(props) {
        super(props);

        this.state = {
            startDate: "2018-05-01",
            days: 31,
            scale: "Day",
            eventHeight:30,
            cellWidth: 50,
            timeHeaders: [

                { groupBy: "Month"},
                { groupBy: "Day", format: "d"}

            ],
            cellWidthSpec: "Auto",
            resources: [
                {name: "Resource A", id: "A"},
                {name: "Resource B", id: "B"},
                {name: "Resource C", id: "C"},
                {name: "Resource D", id: "D"},
                {name: "Resource E", id: "E"},
                {name: "Resource F", id: "F"},
                {name: "Resource G", id: "G"}
            ],
            events: [
                {id: 1, text: "Event 1", start: "2018-05-02T00:00:00", end: "2018-05-05T00:00:00", resource: "A" },
                {id: 2, text: "Event 2", start: "2018-05-03T00:00:00", end: "2018-05-10T00:00:00", resource: "C", barColor: "#38761d", barBackColor: "#93c47d" },
                {id: 3, text: "Event 3", start: "2018-05-02T00:00:00", end: "2018-05-08T00:00:00", resource: "D", barColor: "#f1c232", barBackColor: "#f1c232" },
                {id: 3, text: "Event 3", start: "2018-05-02T00:00:00", end: "2018-05-08T00:00:00", resource: "E", barColor: "#cc0000", barBackColor: "#ea9999" }
            ]
        };
        fetch('http://localhost:61612/api/employees')
      .then(response => response.json())
      .then(data => {
        this.setState({ employees: data, loading: false });        
      });      
    }

    render() {
        var {...config} = this.state;
        return (
            <div>
                <DayPilotScheduler
                    {...config}
                />
            </div>
        );
    }
}