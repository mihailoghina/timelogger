import axios from 'axios';
import {USER_ID} from '../constants';

const client = axios.create({ baseURL: 'http://localhost:3001/api' });

export function getAll() {
	return client.get('/projects').then(response => response.data);
}

export function getUserProjects() {
	return client.get('/users/' + USER_ID + '/projects').then(response => response.data);
}

export default {
	getAll, getUserProjects
};
