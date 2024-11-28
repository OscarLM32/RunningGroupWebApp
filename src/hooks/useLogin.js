import { useMutation } from "react-query";
import { authenticationEndpoint } from "../services/endpoints"
import api from "../services/api.js"

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
    return useMutation({
        mutationFn: loginRequest,
        onSuccess: (data) => {
            console.log("Login successful:", data);
        },
        onError: (error) => {
            console.log("Login failed", error); 
        }
    })
}
