import Navbar from "./components/navbar/navbar"
import Home from "./pages/Home/Home"
import Footer from "./components/Footer/Footer";
import 'bootstrap/dist/css/bootstrap.min.css';
import "./app.css"

export default function App (){    
    return(
        <div>
            <Navbar />
            <Home />
            <Footer />
        </div>
    )
}