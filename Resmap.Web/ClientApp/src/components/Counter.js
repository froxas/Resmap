import React, { Component } from 'react';
import { Dropdown, Input, Header, Icon } from 'semantic-ui-react'
import { Tab } from 'semantic-ui-react'
const panes = [
    { menuItem: 'Tab 1', render: () => <Tab.Pane loading>Tab 1 Content</Tab.Pane> },
    { menuItem: 'Tab 2', render: () => <Tab.Pane>Tab 2 Content</Tab.Pane> },
    { menuItem: 'Tab 3', render: () => <Tab.Pane>Tab 3 Content</Tab.Pane> },
]


export class Counter extends Component {
  displayName = Counter.name

  constructor(props) {
      super(props);  
      this.state = {
          divWidth: {
              width: 500
          },
          options: [
              { key: 1, text: 'VCA', level: 1, value: 1 },
              { key: 2, text: 'English', level: 0, value: 2 },
              { key: 3, text: 'VCU', level: 1, value: 3 },
              { key: 4, text: 'Scaffolder A', level: 2, value: 4 },
              { key: 5, text: 'Insulator', level: 2, value: 5 }
          ]
      };
      this.getColor = this.getColor.bind(this);

      fetch('http://localhost:61612/api/employees')
          .then(response => response.json())
          .then(data => {
              this.setState({ employees: data, loading: false });
          });  
    }


    renderLabel = label => ({        
        color: 'green',
        content: `${label.text}`,
        icon: 'check',
    })

    getColor() {
        return 'blue';
    }
      
  render() {
      return (
          <div style={this.state.divWidth}>  
              <Tab panes={panes} />
              <Header as='h2'>
                  <Icon name='plug' />
                  <Header.Content>Uptime Guarantee</Header.Content>
              </Header>
              <Dropdown text='Filter' icon='filter' floating labeled button className='icon'>
                  <Dropdown.Menu>
                      <Dropdown.Header content='Search Issues' />
                      <Input icon='search' iconPosition='left' name='search' />
                      <Dropdown.Header icon='tags' content='Filter by tag' />
                      <Dropdown.Divider />
                      <Dropdown.Item label={{ color: 'red', empty: true, circular: true }} text='Important' />
                      <Dropdown.Item label={{ color: 'blue', empty: true, circular: true }} text='Announcement' />
                      <Dropdown.Item label={{ color: 'black', empty: true, circular: true }} text='Discussion' />
                  </Dropdown.Menu>
              </Dropdown>
   
          </div>
          
      );
  }
}
