import React from 'react';
import { List, Datagrid, TextField } from 'react-admin';

export const PostList = (props) => (
    <List {...props}>
        <Datagrid>
            <TextField source="relationId" />
            <TextField source="title" />           
            
        </Datagrid>
    </List>
);