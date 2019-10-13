import React from 'react';
import axios from 'axios';
import {USER_ID, API_BASE_URL} from '../constants';
import UserProjectsTable from '../components/UserProjectsTable'

class Project extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
			project: "",
			dataReady: false
        };
	}

    componentDidMount() {		
		var projectId = this.props.match.params.id;

        axios.get(`${API_BASE_URL}projects/${projectId}?includeChildren=true`)
          .then(res => {
            this.setState({ project: res.data, dataReady: true });
        }).catch(error => {
            console.log(error.response);
		})
    }
    
    render() {
		const {project, dataReady} = this.state;

		if(!dataReady) return null;  // if not checked will try to map undefined values

        return (
			<>
            <ul>
				<li>Project name: {project.name}</li>
				<li>Deadline: {project.deadLineDate}</li>
				<li>Completed: {project.isComplete ? "yes" : "no"}</li>
				<li>Created at: {project.deadLineDate}</li>
			</ul>

			{ project.projectActivities.map(
				activity =>
				<div key={activity.id}>
					<p>Activity</p>
					<p className="activity">Name: {activity.name}</p>
					<p className="activity">Description: {activity.description}</p>
					<p className="activity">Created: {activity.creationDate}</p>
					{activity.activityRecords.map(
						record =>
						<div key = {record.id}>
							<p className="activity">Record</p>
							<p className="record">Name: {record.name}</p>
							<p className="record">Logged time: {record.loggedMinutes}</p>
							<p className="record">Description: {record.description}</p>
							<p className="record">Created: {record.creationDate}</p>
						</div>
					)}
				</div>
			)}
			
			</>
        )
    }
}

export default Project;