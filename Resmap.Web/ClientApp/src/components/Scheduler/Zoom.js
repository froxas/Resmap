import React, {Component} from 'react';

export class Zoom extends Component {

    constructor(props) {
        super(props);
        this.state = {
            level: "month"
        }
    }

    change(ev) {
        var newLevel = ev.target.value;

        this.setState({
            level: newLevel
        });

        if (this.props.onChange) {
            this.props.onChange({level: newLevel})
        }

    }

    render() {
        return (
            <div className="space">
                Zoom:
                <label><input type="radio" name="zoom" value="month" onChange={ev => this.change(ev)} checked={this.state.level === "month"} /> Month</label>
                <label><input type="radio" name="zoom" value="week"  onChange={ev => this.change(ev)} checked={this.state.level === "week"} /> Week</label>
                <label><input type="radio" name="zoom" value="year"  onChange={ev => this.change(ev)} checked={this.state.level === "year"} /> Year</label>
            </div>
        );
    }
}