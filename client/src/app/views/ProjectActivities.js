import React from 'react';
import axios from 'axios';
import {API_BASE_URL} from '../constants';
import ProjectActivitiesTable from '../components/ProjectActivitiesTable';

export default class ProjectActivities extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            projectActivities: [],
            dataReady: false
        };
    }

    componentDidMount() {        
        
        axios({
            method: "GET",
            url: `${API_BASE_URL}projects/${this.props.projectId}/activities`
          })
            .then(res => {
                this.setState({ projectActivities: res.data, dataReady: true });
            })
            .catch(err => {
                alert(`Status code: ${err.response.status} \n Message: ${err.response.data}`);
            });
    }
    
    render() {

        if(!this.state.dataReady) return null;

        return (
            <ProjectActivitiesTable 
                data = {this.state.projectActivities} 
                isProjectComplete = {this.props.isProjectComplete} 
                />
        );
    }
}