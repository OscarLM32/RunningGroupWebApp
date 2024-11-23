import { useMutation } from "react-query";

const registerEndpoint = authenticationEndpoint + "/register"

const register = async ({ email, password, confirmPassword }) => {
    try {
        const response = await api.post(registerEndpoint, { email, password, confirmPassword });
        return response.data;
    }
    catch (error) {
        throw new Error(error.response?.data?.message || 'Register failed');
    }
}

export const useRegister = () => {
    return useMutation({
        mutationFn: register,
        onSuccess: (data) => {

        },
        onError: (error) => {
            console.error('Registration failed:', error);
        },
    });
}