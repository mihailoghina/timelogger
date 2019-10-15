import React from 'react';
import ReactDOM from 'react-dom';
import App from './app/App';
import axios from 'axios';
import {USER_ID, API_BASE_URL} from './app/constants';

/*
  axios({
    method: "POST",
    url: "http://localhost:5000/api/users",
    headers: {
        'Content-Type' : 'application/json' 
    },
     data: {
        name: 'aaaaaa',
        email: 'proba@gmail.com',
        PathToAvatar: 'path'
     }
  })
    .then(res => {
        if(res.status === 201)
    })
    .catch(err => {
        alert(err.response.data);
    });

    axios({
        method: "PUT",
        url: "http://localhost:5000/api/projects/b8b939ba-b8b0-43e6-a80f-43cb47d3ab54",
        headers: {
            'Content-Type' : 'application/json' 
        },
         data: {
            name: 'Build interview application update',
            isComplete: 'true',
            DeadLineDate: new Date()
         }
      })
        .then(res => {
            debugger;
            if(res.status === 201)
        })
        .catch(err => {
            alert(err.response.data);
        });

*/

ReactDOM.render(<App />, document.getElementById('root'));
