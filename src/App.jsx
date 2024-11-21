import Navbar from "./components/navbar/navbar"
import Home from "./pages/Home/Home"
import Footer from "./components/Footer/Footer";
import 'bootstrap/dist/css/bootstrap.min.css';
import "./app.css"
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Authentication from "./pages/Authentication/Authentication";

export default function App (){    
    return(
        <Router>
            <Navbar />
            <Routes>
                <Route path="/" element={<Home />}/>
                <Route path="/auth" element={<Authentication />} />
            </Routes>
            <Footer />
        </Router>
    )
}