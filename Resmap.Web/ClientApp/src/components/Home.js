import React, { Component } from 'react';
import { Modal, Button } from 'antd';
import {Register} from './Auth/Register'
import { Steps } from 'antd';
const Step = Steps.Step;

export class Home extends Component {
  displayName = Home.name

  state = {
    modal1Visible: false,
    modal2Visible: false,
  }
  setModal1Visible(modal1Visible) {
    this.setState({ modal1Visible });
  }
  setModal2Visible(modal2Visible) {
    this.setState({ modal2Visible });
  }
  render() {
    return (
      <div>
      <Button type="primary" onClick={() => this.setModal2Visible(true)}>Register Form</Button>
        <Modal
          title="Register Form"
          wrapClassName="vertical-center-modal"
          visible={this.state.modal2Visible}
          onOk={() => this.setModal2Visible(false)}
          onCancel={() => this.setModal2Visible(false)}
          okText="Register"
        >
        <Register/>        
        </Modal>
        <p></p>
        <div>
          <Steps direction="vertical" size="small" current={5}>
            <Step title="Inquary" />
            <Step title="Offer" />
            <Step title="Planning"/>
            <Step title="Preparation"/>
            <Step title="Completion" />
            <Step title="Closing" />
        </Steps>
          </div>
    
      </div>
    );
  }
}
