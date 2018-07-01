import React, { Component } from 'react';
import { Grid, GridColumn as Column, GridCell, GridToolbar  } from '@progress/kendo-react-grid';
import cellWithEditing from '../cellWithEditing.js';


export class Relation extends Component {
  displayName = Relation.name

  constructor(props) {
    super(props);
      this.state = { 
          relations: [],
          loading: true,
          value: '',
          modal1Visible: false,
          productInEdit: undefined,
          
      };    
     
    fetch('http://localhost:61612/api/relations')
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
          <Column field="relationId" title="Relation Id"/>
          <Column field="title" title="Title"/>
          <Column field="relationType" title="Relation Type"/>        
          <Column
            title="Edit"
            cell={cellWithEditing(this.handleShow, this.remove)}
              />     
        </Grid>                            
      </div>
    );
  }
}
