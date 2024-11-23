import api from "../api.js"
import { authenticationEndpoint } from "../endpoints"

export const login = async(email, password) => {
    try{
        var response = await api.post(authenticationEndpoint, {email, password});
        return response.data;
    }
    catch(error){
        throw error.response ? error.response.data : error.message;
    }
}

export const register = async (email, password, passwordConfirmation) => {
    try {
        const response = await api.post('/auth/register', {
            email,
            password,
            passwordConfirmation,
        });
        return response.data;
    } 
    catch (error) {
        throw error.response ? error.response.data : error.message;
    }
};