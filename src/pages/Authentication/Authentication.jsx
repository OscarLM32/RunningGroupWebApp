import { Router, Routes, Route, Navigate } from "react-router-dom";
import Login from "../../components/Auth/Login";
import Register from "../../components/Auth/Register";

function Authentication(){
    return (
        <div>
            <Routes>
                <Route path="login" element={<Login />}/>
                <Route path="register" element={<Register />} />

                <Route path="/auth" element={<Navigate to="login" />} />
            </Routes>
        </div>
    )
}

export default Authentication;