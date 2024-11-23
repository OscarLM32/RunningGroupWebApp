import { useMutation } from "react-query";
import { authenticationEndpoint } from "../services/endpoints"

const loginEndpoint = authenticationEndpoint + "/login"

const login = async ({email, password}) => {
    try {
        const response = await api.post(loginEndpoint, { email, password });
        return response.data; 
    } catch (error) {
        throw new Error(error.response?.data?.message || 'Login failed');
    }
}


export const useLogin = () => {
    return useMutation({
        mutationFn: login,
        onSuccess: (data) => {
            
        },
        onError: (error) => {
            console.log("Login failed", error); 
        }
    })
}
