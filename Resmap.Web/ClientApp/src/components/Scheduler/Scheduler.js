import React, {Component} from 'react';
import {DayPilotScheduler} from "daypilot-pro-react";
import {DayPilot} from "daypilot-pro-react";

export class Scheduler extends Component {
    displayName = Scheduler.name
    constructor(props) {
        super(props);

        this.state = {           
            startDate: "2018-04-01",
            days: 180,
            scale: "Week",
            eventHeight:30,
            cellWidth: 50,
            timeHeaders: [
                { groupBy: "Month"},
                { groupBy: "Week"},
                //{ groupBy: "Day", format: "d"}
            ],
            cellWidthSpec: "Auto",
            resources: [],
            events: []            
        };
         
    }

    componentDidMount() {
        let url = [
            'http://localhost:61612/api/events/employee/resources',
            'http://localhost:61612/api/events/employee'
        ];
        let request = url.map(url => fetch(url));

        Promise.all(request)
        // map array of responses into array of response.json() to read their content 
        .then(responses => Promise.all(responses.map(r => r.json())) )                
        .then(data => 
            this.setState({
                resources: data[0].resources,
                events: data[1].events,
                loading: false 
            })
        )        
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