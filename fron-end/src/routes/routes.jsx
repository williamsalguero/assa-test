import { createBrowserRouter } from "react-router-dom";
import { AdminPage, Home, LandingPage, NotFound } from "../pages";
import Navbar from "../components/navbar/navbar";
import EmployeeList from "../components/employee/employeeList";
import Login from "../pages/login/login";
import EditUser from "../components/employee/crud/editUser";

export const routes = createBrowserRouter([
  {
    path: "/",
    exact: true,
    element: <Home />,
    errorElement: <NotFound />,
  },
  {
    path: "/adminPage",
    exact: true,
    element: <AdminPage />,
    errorElement: <NotFound />,
  },
  {
    path: "/employeeList",
    exact: true,
    element: <EmployeeList />,
    errorElement: <NotFound />,
  },
  {
    path: "/login",
    exact: true,
    element: <Login />,
    errorElement: <NotFound />,
  },
  {
    path: "/edit-user/:id",
    exact: true,
    element: <EditUser />,
    errorElement: <NotFound />,
  },
]);
