import React from "react";
import Header from "../../components/header/header";
import { FaList } from "react-icons/fa";
import { BsFileEarmarkText } from "react-icons/bs"; // Cambié a un ícono de archivo para representar el reporte

import "./AdminPage.css"; // Importa tu archivo de estilos CSS
import { Link } from "react-router-dom";

const AdminPage = () => {
  return (
    <>
      <div className="reports__container">
        <Header showNav={true} />
        <div className="card-container">
          <section className="card generateReport_container">
            <BsFileEarmarkText className="icon" />
            <div>
              <h1>Reporte de empleados </h1>
              <p>Genera un informe detallado de los empleados.</p>
            </div>
            <Link to={"/reports"} className="btn-link">
              <button className="btn btn__container rounded">Generar</button>
            </Link>
          </section>
          <section className="card list_container">
            <FaList className="icon" />
            <div>
              <h1>Lista de Empleados</h1>
              <p>Visualiza y gestiona la lista completa de empleados.</p>
            </div>
            <Link to={"/employeeList"} className="btn-link">
              <button className="btn btn__container rounded">Ver Lista</button>
            </Link>
          </section>
        </div>
      </div>
    </>
  );
};

export default AdminPage;
