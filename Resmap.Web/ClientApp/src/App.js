import React, { Component } from 'react';
import { Route } from 'react-router';

import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { FetchEmp } from './components/Employee/FetchEmp';
import { Counter } from './components/Counter';
import { Auth } from './components/Auth/Auth';
import { Login } from './components/Auth/Login';
import { Register } from './components/Auth/Register';
import { Scheduler } from './components/Scheduler/Scheduler';
import { SchedulerCar } from './components/Scheduler/SchedulerCar';
import { Relation } from './components/Relation/Relation';

// You can import style files in ./App.js and add global styles in ./App.css
import '@progress/kendo-theme-default/dist/all.css';
import 'antd/dist/antd.css';

export default class App extends Component {
  displayName = App.name

  render() {
    return (      
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetchdata' component={FetchData} />
        <Route path='/fetchemp' component={FetchEmp} />    
        <Route path='/login' component={Login} />  
        <Route path='/register' component={Register} />  
        <Route path='/Auth' component={Auth} />  
        <Route path='/scheduler' component={Scheduler} /> 
        <Route path='/schedulerCar' component={SchedulerCar} /> 
        <Route path='/relation' component={Relation} /> 
      </Layout>      
    );
  }
}
