import axios from "axios";


const api = axios.create({
    baseURL: "https://localhost:7065/api",
    headers: {
        "Content-Type": "application/json"
    },
    withCredentials: true
});

export default api;