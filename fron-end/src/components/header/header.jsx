import React from "react";
import Navbar from "../navbar/navbar";
import PropTypes from "prop-types";
import "./Header.css";

const Header = (props) => {
  return (
    <div className="header-container">
      <header>
        <h1>Sistema de Reportes</h1>
        <p>PERFILESSA</p>
      </header>
      {props.showNav && (
        <div className="nav-container">
          <hr />  
          <Navbar />
        </div>
      )}
    </div>
  );
};

Header.propTypes = {
  showNav: PropTypes.bool,
};

export default Header;
