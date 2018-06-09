import React, { Component } from 'react';
import { Input, Checkbox, Button, Icon, Form } from 'antd';
import axios from 'axios';

const FormItem = Form.Item;
const formStyle ={
    //maxWidth: '300px'
}
const buttonStyle = {
    width: '100%'
}
const linkStyle = {
  float: 'right'
}

export class Register extends Component {
  displayName = Register.name 
  state = {
    username: '',
    email: '',
    password: ''   
  }

  onChange = (e) => {
    this.setState({
      [e.target.name] : e.target.value
    })      
  }

  onSubmit = async () => {
    const {username, email, password} = this.state;
    try {
      const response = 
        await axios.post('http://localhost:61612/api/users', {username, email, password});
      console.log(response);      
    } catch (err) {
      console.log(err);      
    }
  } 

  render() {
    return (
      <div>   
        <p></p> 
        <Form style={formStyle}>
        <FormItem>
        <Input 
          prefix={<Icon type="user" style={{ color: 'rgba(0,0,0,.25)' }} />} 
          placeholder="Username" 
          name='username'           
          onChange={e => this.onChange(e)} 
          value={this.state.username}
          />    
        </FormItem>
        <FormItem>
          <Input 
            prefix={<Icon type="mail" style={{ color: 'rgba(0,0,0,.25)' }} />} 
            placeholder="Email" 
            name='email'             
            onChange={e => this.onChange(e)} 
            value={this.state.email}
            />    
        </FormItem>
        <FormItem>
          <Input 
            prefix={<Icon type="lock" style={{ color: 'rgba(0,0,0,.25)' }} />} 
            placeholder="Password" 
            name='password'             
            onChange={e => this.onChange(e)} 
            value={this.state.password}
            />    
        </FormItem> 
        <FormItem>
        <Checkbox>Remember me</Checkbox>
        <a style={linkStyle} href="">Forgot password</a>
          <Button 
            type="primary"
            onClick={() => this.onSubmit()}
            style={buttonStyle}
          >
          Register
          </Button>  
          Or <a href="">register now!</a>       
        </FormItem>       
        </Form>
      </div>
    );
  }
}
