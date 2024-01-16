import React from "react";

const EmployeeCard = ({ employee, onClick }) => {
  return (
    <div className="employee-card" onClick={onClick}>
      <h3>{employee.nombres}</h3>
      <p>{employee.role}</p> 
      <p>{employee.correo}</p>
    </div>
  );
};

export default EmployeeCard;
