import React, { Component } from 'react';
import {fetchUtils, Admin, Resource } from 'react-admin';
import { PostList } from './components/posts';
import simpleRestProvider from 'ra-data-simple-rest';

const httpClient = (url, options = {}) => {
  if (!options.headers) {
      options.headers = new Headers({ Accept: 'application/json' });
  }
  // add your own headers here
  options.headers.set('X-Custom-Header', 'foobar');
  return fetchUtils.fetchJson(url, options);
}

export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Admin dataProvider={simpleRestProvider('http://localhost:61612/api', httpClient)}>
         <Resource name="relations" list={PostList} />
      </Admin>     
    );
  }
}
