import React from 'react';
import { NavLink } from 'react-router-dom';

const Navbar: React.FC = () => (
  <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
    <div className="container-fluid">
      <NavLink className="navbar-brand" to="/calendar">PeakForm</NavLink>
      <div className="collapse navbar-collapse show">
        <ul className="navbar-nav me-auto mb-2 mb-lg-0">
          <li className="nav-item">
            <NavLink className="nav-link" to="/calendar">Calendar</NavLink>
          </li>
          <li className="nav-item">
            <NavLink className="nav-link" to="/food">Food</NavLink>
          </li>
          <li className="nav-item">
            <NavLink className="nav-link" to="/progress">Progress</NavLink>
          </li>
        </ul>
      </div>
    </div>
  </nav>
);

export default Navbar;
