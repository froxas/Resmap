import React, { Component } from 'react';
import { Icon, Step } from 'semantic-ui-react'
import { Button, Card, Image } from 'semantic-ui-react'
import {Table } from 'semantic-ui-react'

export class Counter extends Component {
  displayName = Counter.name

  constructor(props) {
    super(props);
    this.state = { currentCount: 0 };
    this.incrementCounter = this.incrementCounter.bind(this);
  }

  incrementCounter() {
    this.setState({
      currentCount: this.state.currentCount + 1
    });
  }

  render() {
    return (
      <div>
        <h1>Counter</h1>

        <p>This is a simple example of a React component.</p>

        <p>Current count: <strong>{this.state.currentCount}</strong></p>

        <Button onClick={this.incrementCounter}>Increment</Button>



        <Step.Group widths={3}>
    <Step>
      <Icon name='truck' />
      <Step.Content>
        <Step.Title>Shipping</Step.Title>
      </Step.Content>
    </Step>
    <Step active>
      <Icon name='credit card' />
      <Step.Content>
        <Step.Title>Billing</Step.Title>
      </Step.Content>
    </Step>
    <Step disabled>
      <Icon name='info' />
      <Step.Content>
        <Step.Title>Confirm Order</Step.Title>
      </Step.Content>
    </Step>
  </Step.Group>


<Card.Group>
    <Card>
      <Card.Content>
        <Image floated='right' size='mini' src='/assets/images/avatar/large/steve.jpg' />
        <Card.Header>Steve Sanders</Card.Header>
        <Card.Meta>Friends of Elliot</Card.Meta>
        <Card.Description>
          Steve wants to add you to the group <strong>best friends</strong>
        </Card.Description>
      </Card.Content>
      <Card.Content extra>
        <div className='ui two buttons'>
          <Button basic color='green'>
            Approve
          </Button>
          <Button basic color='red'>
            Decline
          </Button>
        </div>
      </Card.Content>
    </Card>
    <Card>
      <Card.Content>
        <Image floated='right' size='mini' src='/assets/images/avatar/large/molly.png' />
        <Card.Header>Molly Thomas</Card.Header>
        <Card.Meta>New User</Card.Meta>
        <Card.Description>
          Molly wants to add you to the group <strong>musicians</strong>
        </Card.Description>
      </Card.Content>
      <Card.Content extra>
        <div className='ui two buttons'>
          <Button basic color='green'>
            Approve
          </Button>
          <Button basic color='red'>
            Decline
          </Button>
        </div>
      </Card.Content>
    </Card>
    <Card>
      <Card.Content>
        <Image floated='right' size='mini' src='/assets/images/avatar/large/jenny.jpg' />
        <Card.Header>Jenny Lawrence</Card.Header>
        <Card.Meta>New User</Card.Meta>
        <Card.Description>Jenny requested permission to view your contact details</Card.Description>
      </Card.Content>
      <Card.Content extra>
        <div className='ui two buttons'>
          <Button basic color='green'>
            Approve
          </Button>
          <Button basic color='red'>
            Decline
          </Button>
        </div>
      </Card.Content>
    </Card>
  </Card.Group>
  <Table>
    <Table.Body>
      <Table.Row>
        <Table.Cell collapsing>
          <Icon name='folder' />
          node_modules
        </Table.Cell>
        <Table.Cell>Initial commit</Table.Cell>
        <Table.Cell>10 hours ago</Table.Cell>
      </Table.Row>
      <Table.Row>
        <Table.Cell>
          <Icon name='folder' />
          test
        </Table.Cell>
        <Table.Cell>Initial commit</Table.Cell>
        <Table.Cell>10 hours ago</Table.Cell>
      </Table.Row>
      <Table.Row>
        <Table.Cell>
          <Icon name='folder' />
          build
        </Table.Cell>
        <Table.Cell>Initial commit</Table.Cell>
        <Table.Cell>10 hours ago</Table.Cell>
      </Table.Row>
    </Table.Body>
  </Table>

      </div>

      
    );
  }
}
