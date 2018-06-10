import React, { Component } from 'react';
import { Grid, GridColumn as Column, GridCell, GridToolbar  } from '@progress/kendo-react-grid';
import { orderBy } from '@progress/kendo-data-query';
import cellWithEditing from '../cellWithEditing.js';
import { Input } from '@progress/kendo-react-inputs';
import { EmployeeForm } from './EmployeeForm';
import { Modal, Button } from 'antd';

export class FetchEmp extends Component {
  displayName = FetchEmp.name

  constructor(props) {
    super(props);
      this.state = { 
          employees: [],
          loading: true,
          value: '',
          modal1Visible: false,
          productInEdit: undefined,
          
      };    
     
    fetch('http://localhost:61612/api/employees')
      .then(response => response.json())
      .then(data => {
        this.setState({ employees: data, loading: false });        
      });  

  }  
  
  close() {
    this.setState({ modal1Visible: false });
  }
   
  setModal1Visible(modal1Visible) {
    this.setState({ modal1Visible });
  }
 
  static renderEmployeesTable(employees) {    
    return (  
      <div>    
        
      </div>      
    );
  }

  render() {    
      //let contents = this.state.loading
      //? <p><em>Loading...</em></p>
      //: FetchEmp.renderEmployeesTable(this.state.employees);
    return (      
      <div>        
        <h1>Employees</h1>   
        <Grid
          style={{ maxHeight: '100%' }}
          data={this.state.employees} 
          onPageChange={this.pageChange}
          total={this.state.total}
          skip={this.state.skip}
          pageable={this.state.pageable}
          pageSize={this.state.pageSize}         
          >
           <GridToolbar>
            <button 
                onClick={() => this.setModal1Visible(true)}
                className="k-primary k-button k-grid-edit-command" >
                Add New
              </button>    
          </GridToolbar>          
          <Column field="employeeId" title="Employee Id"/>
          <Column field="name" title="Full name"/>
          <Column field="jobTitle" title="Job Title"/>
          <Column field="department" title="Department"/>    
          <Column field="isSubcontractor" title="Subcontractor"/>  
          <Column field="isDeleted" title="Deleted"/>  
          <Column
            title="Edit"
            cell={cellWithEditing(this.handleShow, this.remove)}
              />     
        </Grid>     
        
        {this.state.modal1Visible &&
        <Modal
          title="Register Form"
          wrapClassName="vertical-center-modal"
          visible={this.state.modal1Visible}
          onOk={() => this.setModal1Visible(false)}
          onCancel={() => this.setModal1Visible(false)}
          okText="Register"
      >
      <EmployeeForm
        close={this.close}/>         
      </Modal>
        }                  
      </div>
    );
  }
}
