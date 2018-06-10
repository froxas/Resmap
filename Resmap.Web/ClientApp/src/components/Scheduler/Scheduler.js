import React, {Component} from 'react';
import {DayPilotScheduler} from "daypilot-pro-react";
import {DayPilot} from "daypilot-pro-react";
import { Zoom } from "./Zoom";

export class Scheduler extends Component {
    displayName = Scheduler.name
    constructor(props) {
        super(props);

        this.state = {           
            startDate: "2018-04-01",
            days: 60,
            scale: "Day",
            eventHeight:30,
            cellWidth: 50,
            timeHeaders: [
                { groupBy: "Month"},
                { groupBy: "Day", format: "d"}
            ],
            cellWidthSpec: "Auto",
            resources: [],
            events: []            
        };
         
    }

    componentDidMount() {
        fetch('http://localhost:61612/api/events')
      .then(response => response.json())
      .then(data => {
        this.setState({ resources: data.resources, events: data.events, loading: false });            
      });         
    }



    zoomChange(args) {
        switch (args.level) {
            case "month":
                this.setState({
                    startDate: DayPilot.Date.today().firstDayOfMonth(),
                    days: DayPilot.Date.today().daysInMonth(),
                    scale: "Month"
                });
                break;
            case "week":
                this.setState({
                    startDate: DayPilot.Date.today().firstDayOfWeek(),
                    days: 7,
                    scale: "Week"
                });
                break;
                case "year":
                this.setState({
                    startDate: DayPilot.Date.today().firstDayOfWeek(),
                    days: 360,
                    scale: "Year"
                });
                break;
            default:
                throw new Error("Invalid zoom level");
        }
    }



    render() {     
        var {...config} = this.state;
        return (
            <div>
                 <Zoom onChange={args => this.zoomChange(args)} />
                <DayPilotScheduler
                    {...config}
                />
            </div>
        );
    }
}