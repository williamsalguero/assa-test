import React, { useState, useEffect } from "react";
import axios from "axios";
import "./EmployeeList.css"; // Importa tu archivo de estilos CSS
import { Link } from "react-router-dom";
import api from "../../api/api";

const EmployeeList = () => {
  const [employees, setEmployees] = useState([]);
  const [loading, setLoading] = useState(true);
  const [newEmployeeData, setNewEmployeeData] = useState({
    nombres: "",
    role: "",
    correo: "",
    // Agrega otros campos según tus necesidades
  });

  useEffect(() => {
    loadEmployees();
  }, []); // Se ejecuta una vez al montar el componente

  const loadEmployees = async () => {
    try {
      const response = await axios.get("http://localhost:3001/api/users/read");
      console.log("Respuesta de la API:", response.data);

      if (Array.isArray(response.data)) {
        setEmployees(response.data);
      } else if (typeof response.data === "object") {
        // Si la respuesta es un objeto, convertirlo en un arreglo
        setEmployees([response.data]);
      } else {
        setEmployees([]);
      }

      setLoading(false);
    } catch (error) {
      console.error("Error al obtener la lista de empleados:", error);
      setLoading(false);
    }
  };

  const handleEditClick = (employee) => {
    // Lógica para editar el empleado seleccionado
    console.log("Editar empleado:", employee);
  };

  const handleDeleteUser = async (codigoEmpleado) => {
    if (window.confirm("Are you sure you want to delete this user?")) {
      try {
        await api.delete(`api/users/delete/${codigoEmpleado}`);
        console.log("User deleted successfully");
        // Después de eliminar, recarga la lista de empleados
        loadEmployees();
      } catch (error) {
        console.error("Error deleting user:", error.message);
      }
    }
  };

  const handleAddEmployee = async () => {
    try {
      await api.post("http://localhost:3001/api/users/create", newEmployeeData);
      console.log("Employee added successfully");
      // Después de agregar, recarga la lista de empleados
      loadEmployees();
      // Limpia los datos del nuevo empleado después de agregar
      setNewEmployeeData({
        nombres: "",
        role: "",
        correo: "",
        // Limpia otros campos según tus necesidades
      });
    } catch (error) {
      console.error("Error adding employee:", error.message);
    }
  };

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setNewEmployeeData({
      ...newEmployeeData,
      [name]: value,
    });
  };

  return (
    <div>
      <h1>Lista de empleados</h1>
      <div className="employee-list">
        {loading ? (
          <p>Cargando empleados...</p>
        ) : (
          <>
            <div className="employee-form">
              <h2>Agregar Nuevo Empleado</h2>
              <label>Nombres:</label>
              <input
                type="text"
                name="nombres"
                value={newEmployeeData.nombres}
                onChange={handleInputChange}
              />
              <label>Apellidos:</label>
              <input
                type="text"
                name="apellidos"
                value={newEmployeeData.apellidos}
                onChange={handleInputChange}
              />
              <label>Correo:</label>
              <input
                type="text"
                name="correo"
                value={newEmployeeData.correo}
                onChange={handleInputChange}
              />
              <label>Password:</label>
              <input
                type="password"
                name="password"
                value={newEmployeeData.password}
                onChange={handleInputChange}
              />
              <label>DPI:</label>
              <input
                type="text"
                name="DPI"
                value={newEmployeeData.DPI}
                onChange={handleInputChange}
              />
              {/* Agrega otros campos del formulario según tus necesidades */}
              <button onClick={handleAddEmployee}>Agregar Empleado</button>
            </div>
            <div className="employee-list">
              {employees.map((employee) => (
                <div className="employee-card" key={employee.codigoEmpleado}>
                  {/* ... (código anterior) */}
                </div>
              ))}
            </div>
          </>
        )}
      </div>
    </div>
  );
};

export default EmployeeList;
