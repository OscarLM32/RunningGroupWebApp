import reacLogo from "../../../public/images/react.svg"
import "./navbar.css"

export default function Navbar() {
    return (
        <nav className="navbar">
            <img className="logo" src={reacLogo}/>
            <h3 className="title">ReactFacts</h3>
            <h4 className="subtitle">React Cours - Project 1</h4>
        </nav>
    )
}