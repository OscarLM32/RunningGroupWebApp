import { useMutation } from "react-query";
import { authenticationEndpoint } from "../services/endpoints";
import api from "../services/api.js";

const registerEndpoint = authenticationEndpoint + "/register"

const registerRequest = async ({ email, password, passwordConfirmation }) => {
    try {
        const response = await api.post(registerEndpoint, { email, password, passwordConfirmation });
        return response.data;
    }
    catch (error) {
        throw new Error(error.response?.data?.message || 'Register failed');
    }
}

export const useRegister = () => {
    return useMutation({
        mutationFn: registerRequest,
        onSuccess: (data) => {
            console.log("Registration successful")
            
        },
        onError: (error) => {
            console.error('Registration failed:', error);
        },
    });
}