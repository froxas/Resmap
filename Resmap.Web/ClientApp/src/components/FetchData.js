import React, { Component } from 'react';
// ES2015 module syntax
import { Grid, GridColumn as Column, GridCell, GridToolbar  } from '@progress/kendo-react-grid';
import { orderBy } from '@progress/kendo-data-query';
import cellWithEditing from './cellWithEditing.js';

export class FetchData extends Component {
  displayName = FetchData.name

  constructor(props) {
    super(props);
    this.state = { 
      forecasts: [],
      loading: true,
      productInEdit: undefined 
      };

    fetch('api/SampleData/WeatherForecasts')
      .then(response => response.json())
      .then(data => {
        this.setState({ forecasts: data, loading: false });
      });
  }

  cancel() {
    this.setState({ productInEdit: undefined });
  }

  insert() {
    this.setState({ productInEdit: { } });
  }


  static renderForecastsTable(forecasts) {
    return (
      <Grid
          style={{ maxHeight: '100%' }}
          data={forecasts}
          >
          <GridToolbar>
            <button
              className="k-primary k-button k-grid-edit-command" >
              Add New
            </button>
          </GridToolbar>
          <Column field="dateFormatted" title="Date"/>
          <Column field="temperatureC" title="Temp. (C)"/>
          <Column field="temperatureF" title="Temp. (F)"/>
          <Column field="summary" title="Summary"/>
          <Column
            title="Edit"
              cell={cellWithEditing(this.edit, this.remove)}
              />
        </Grid>      
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderForecastsTable(this.state.forecasts);

    return (      
      <div>        
        <h1>Weather forecast</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}     
        
        
      </div>
    );
  }
}
