import { useMutation } from "react-query";
import api from "../services/api"
import { authenticationEndpoint } from "../services/endpoints"
import Cookies from "js-cookie";
import authEvents from "../utils/authEvents";

const logoutEnpoint = authenticationEndpoint + "/logout";

const logoutRequest = async () =>{
    try{
        console.log(document.cookie);

        var response = api.post(logoutEnpoint, {}, {
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
            Cookies.remove("jwtToken");
            authEvents.emit("logout");
        },
        onError: (error) =>{
            console.log("Logout failed", error);
        }
    })
}