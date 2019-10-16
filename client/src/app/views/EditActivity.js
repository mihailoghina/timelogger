import React from 'react';
import axios from 'axios';
import {API_BASE_URL} from '../constants';

export default class EditActivity extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            activity: "",
            dataReady: false,
        };
        this.handleSubmit = this.handleSubmit.bind(this);
        this.nameChange = this.nameChange.bind(this);
        this.descriptionChange = this.descriptionChange.bind(this);
        this.loggedMinutesChange = this.loggedMinutesChange.bind(this);
        this.deleteActivity = this.deleteActivity.bind(this);
      }

      postDataToServer(name, description, loggedMinutes) {

        axios({
            method: "PUT",
            url: `${API_BASE_URL}activities/${this.props.match.params.id}`,
            headers: {
                'Content-Type' : 'application/json' 
            },
             data: {
                "name": name,
                "description": description,
                "loggedMinutes": loggedMinutes
             }
          })
            .then(res => {
                window.history.back();
            })
            .catch(err => {
                alert(err.response.data);
            });
        
      }

      handleSubmit(event) {
        event.preventDefault();
        var {activity} = this.state;

        this.postDataToServer(activity.name, activity.description, activity.loggedMinutes);
    }

    componentDidMount() {		
        var activityId = this.props.match.params.id;

		axios({
            method: "GET",
            url: `${API_BASE_URL}activities/${activityId}`
          })
            .then(res => {
                this.setState({ activity: res.data, dataReady: true });
            })
            .catch(err => {
                alert(`Status code: ${err.response.status} \n Message: ${err.response.data}`);
            });
    }

    descriptionChange(event) {
        this.setState({ activity:  Object.assign({}, this.state.activity, {description: event.target.value}) });
    }

    nameChange(event) {
        this.setState({ activity:  Object.assign({}, this.state.activity, {name: event.target.value}) });
    }

    loggedMinutesChange(event) {
        this.setState({ activity:  Object.assign({}, this.state.activity, {loggedMinutes: event.target.value}) });
    }

    deleteActivity() {

        var confirmation = window.confirm("Are you sure you want to delete this activity?");

        if(confirmation === true) {

            var activityId = this.props.match.params.id;

            axios({
                method: "DELETE",
                url: `${API_BASE_URL}activities/${activityId}`
            })
                .then(res => {
                    window.history.back();
                })
                .catch(err => {
                    alert(`Status code: ${err.response.status} \n Message: ${err.response.data}`);
                });
        }
    }

    render() {
        const {activity, dataReady} = this.state;

        if(!dataReady) return null;

        return (
            <>
            <form onSubmit={this.handleSubmit}>
            
               <label htmlFor="name">Name</label><br/>
                <input minLength="5" type="text" id="name" value={activity.name} onChange={this.nameChange}/><br/>

                <label htmlFor="name">Description</label><br/>
                <input type="text" id="description" value={activity.description} onChange={this.descriptionChange}/><br/>


                <label htmlFor="loggedMinutes">Logged minutes</label><br/>
                <input type="number" min="30" id="loggedMinutes" value={activity.loggedMinutes} onChange = {this.loggedMinutesChange}/><br/><br/>

                <input type="submit" value="Save changes" />
            </form>

            <br/><br />
            <button onClick={this.deleteActivity}>DELETE ACTIVITY</button>
            <br />
            </>
        )
    }
}