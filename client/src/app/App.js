import React from 'react';
import './style.css';
import Project from './views/Project';
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import Users from './views/Users';
import User from './views/User';
import AddProject from './views/AddProject';
import AddActivity from './views/AddActivity';
import EditProject from './views/EditProject';
  
export default function App() {
    return (
        <>
            <header>
                <nav className="navbar navbar-expand navbar-dark fixed-top bg-dark">
                    <div className="container">
                        <a className="navbar-brand" href="/">Timelogger</a>
                    </div>
                </nav>
            </header>
            
            <main>
                <div className="container">                       
                    <Router>
                        <div>
                            <Switch>
                                <Route exact path="/"><Users /></Route>
                                <Route exact path="/project/:id" component={Project} />
                                <Route exact path="/users" component={Users} />
                                <Route exact path="/users/:id" component={User} />
                                <Route exact path="/users/:id/addproject" component={AddProject} />
                                <Route exact path="/projects/:id/addactivity" component={AddActivity} />
                                <Route exact path="/projects/:id/edit" component={EditProject} />
                            </Switch>
                        </div>
                    </Router>                
                </div>
            </main>
        </>
    );
}

  