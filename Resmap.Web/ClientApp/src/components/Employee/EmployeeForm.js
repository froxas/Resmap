import React, { Component } from 'react';
import { Input, Checkbox, Button, Icon, Form } from 'antd';
import {
  Select, InputNumber, Switch, Radio,
  Slider, Upload, Rate,
} from 'antd';
import axios from 'axios';
const Option = Select.Option;
const FormItem = Form.Item;
const formStyle ={
    maxWidth: '400px'
}
const buttonStyle = {
    //width: '100%'
}
const linkStyle = {
  float: 'right'
}

export class EmployeeForm extends Component {
  displayName = EmployeeForm.name 
  state = {
    employeeId: '',
    firstName: '',
    lastName: '',
    jobTitle: '',
    department: ''    
  }

  onChange = (e) => {
    this.setState({
      [e.target.name] : e.target.value
    })      
    console.log(this.state);
    
  }

  handleChange = (value) => {
    console.log(this.state.jobTitle); 
    this.setState({
      jobTitle: value
    });

      
  }

  onSubmit = async () => {
    const { 
        employeeId,
        firstName,
        lastName,
        jobTitle,
        department
    } = this.state;
    try {
      const response = 
        await axios.post(
            'http://localhost:61612/api/employees', 
            {
                employeeId,
                firstName,
                lastName,
                jobTitle,
                department});
      console.log(response);      
    } catch (err) {
      console.log(err);      
    }    
    
    
  } 
  

  render() {

    const formItemLayout = {
        labelCol: {
          xs: { span: 24 },
          sm: { span: 6 },
        },
        wrapperCol: {
          xs: { span: 24 },
          sm: { span: 18 },
        },
      };

      const tailFormItemLayout = {
        wrapperCol: {
          xs: {
            span: 24,
            offset: 0,
          },
          sm: {
            span: 16,
            offset: 6,
          },
        },
      };

    return (
      <div>   
        <p></p> 
        <Form style={formStyle}>
        <FormItem
            {...formItemLayout}
            label="Employee Id:">
        <Input          
          name='employeeId'           
          onChange={e => this.onChange(e)} 
          value={this.state.employeeId}
          />    
        </FormItem>
        <FormItem
            {...formItemLayout}
            label="First Name:">
          <Input             
            name='firstName'             
            onChange={e => this.onChange(e)} 
            value={this.state.firstName}
            />    
        </FormItem>
        <FormItem
            {...formItemLayout}
            label="Last Name">
          <Input           
            name='lastName'             
            onChange={e => this.onChange(e)} 
            value={this.state.lastName}
            />    
        </FormItem> 
        <FormItem
          {...formItemLayout}
          label="Job Title"
        >
          <Select
            placeholder="Select"                        
            onChange={this.handleChange}                  
          >
            <Option value="Development">Development</Option>
            <Option value="HR">HR</Option>
            <Option value="Lithunian">Lithunian</Option>
           </Select>
          
        </FormItem>       
        
        <FormItem
            {...formItemLayout}
            label="Department">
          <Input            
            name='department'             
            onChange={e => this.onChange(e)} 
            value={this.state.department}
            />    
        </FormItem>
        <FormItem {...tailFormItemLayout}>
        <Button 
            type="primary"
            onClick={() => this.onSubmit()}
            style={buttonStyle}>
          Register
          </Button>            
        </FormItem>       
        </Form>
      </div>
    );
  }
}
