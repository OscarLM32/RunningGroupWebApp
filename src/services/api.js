import axios from "axios";


const api = axios.create({
    baseURL: "http://localhost:5076",
    headers: {
        "Content-Type": "application/json"
    }
});

export default api;