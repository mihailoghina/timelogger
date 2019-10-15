import React from 'react';
import './style.css';
import Project from './views/Project';
import { BrowserRouter as Router, Switch, Route, Link} from "react-router-dom";
import UserProjects from './views/UserProjects';
import Users from './views/Users';
import User from './views/User';
  
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
                            <ul>
                                <li><Link to="/">Users</Link></li>
                            </ul>

                            <Switch>
                                <Route exact path="/"><Users /></Route>
                                <Route exact path="/project/:id" component={Project} />
                                <Route exact path="/users" component={Users} />
                                <Route exact path="/users/:id" component={User} />
                            </Switch>
                        </div>
                    </Router>                
                </div>
            </main>
        </>
    );
}

  