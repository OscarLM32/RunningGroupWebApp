import { useMutation } from "react-query";
import { authenticationEndpoint } from "../services/endpoints"
import api from "../services/api.js"
import { useNavigate } from "react-router-dom";

const loginEndpoint = authenticationEndpoint + "/login"

const loginRequest = async ({email, password}) => {
    try {
        const response = await api.post(loginEndpoint, { email, password });
        return response.data; 
    } catch (error) {
        console.error("Error during login request:", error); // Log error for debugging
        throw new Error(error.response?.data?.message || 'Login failed');
    }
}


export const useLogin = () => {
    const navigate = useNavigate();
    
    return useMutation({
        mutationFn: loginRequest,
        onSuccess: (data) => {
            console.log("Login successful:", data);
            navigate("/");
        },
        onError: (error) => {
            console.log("Login failed", error); 
        }
    })
}
