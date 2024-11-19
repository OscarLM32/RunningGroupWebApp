import Navbar from "./components/navbar/navbar"
import Main from "./components/Main/main"
import 'bootstrap/dist/css/bootstrap.min.css';
import "./app.css"

export default function App (){    
    return(
        <div>
            <Navbar />
            <Main />
        </div>
    )
}