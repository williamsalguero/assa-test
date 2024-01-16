import axios from "axios";
import Swal from "sweetalert2";
const apiurl = import.meta.env.VITE_API_URL;

export const apiLogin = async (email, password) => {
  try {
    const response = await axios.post(`${apiurl}login`, {
      email,
      password,
    });
    const token = response.data.token;
    // Guardar token en el almacenamiento local
    token ? localStorage.setItem("token", token) : null;
    if (response) {
      Swal.fire({
        icon: "success",
        title: " ! Inicio de sesión completado ! ",
        text: " ¡ Correcto ! ",
        confirmButtonText: "Ok",
      });
    } else if (response) {
    }
    return token;
  } catch ({
    response: {
      data: { msg },
    },
  }) {
    Swal.fire({
      icon: "error",
      title: "Error al iniciar sesión",
      text: `${msg}`,
    });
    return false;
  }
};
