import { useMutation } from "react-query";
import api from "../services/api"
import { authenticationEndpoint } from "../services/endpoints"
import Cookies from "js-cookie";
import authEvents from "../utils/authEvents";

const logoutEndpoint = authenticationEndpoint + "/logout";

const logoutRequest = async () =>{
    try{
        var response = api.post(logoutEndpoint, {}, {
            withCredentials:true
        });
        return response.data;
    }
    catch (error){
        console.error("Error logging out: ", error);
    }
}


export const useLogout = () => {
    return useMutation({
        mutationFn: logoutRequest,
        onSuccess: (data)=>{
            console.log("It worked!")
            Cookies.remove("jwtToken");
            authEvents.emit("logout");
        },
        onError: (error) =>{
            console.log("Logout failed", error);
        }
    })
}