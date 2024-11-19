import Navbar from "./components/navbar/navbar"
import Main from "./components/Main/Main"
import Footer from "./components/Footer/Footer";
import 'bootstrap/dist/css/bootstrap.min.css';
import "./app.css"

export default function App (){    
    return(
        <div>
            <Navbar />
            <Main />
            <Footer />
        </div>
    )
}