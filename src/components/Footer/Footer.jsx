
function Footer(){
    return (
        <footer className="py-3 bg-dark text-bg-dark">
            <div className="container d-flex flex-wrap justify-content-between align-items-center">
                <p className="col-md-4 mb-0">&copy; 2024 Company, Inc</p>

                <a href="/" className="col-md-4 d-flex align-items-center justify-content-center mb-3 mb-md-0 me-md-auto text-decoration-none">
                    <svg className="bi me-2" width="40" height="32">
                        <use xlinkHref="#bootstrap"></use>
                    </svg>
                </a>

                <ul className="nav col-md-4 justify-content-end">
                    <li><a href="#" className="nav-link px-2 text-secondary">Home</a></li>
                    <li><a href="#" className="nav-link px-2 text-white">Features</a></li>
                    <li><a href="#" className="nav-link px-2 text-white">Pricing</a></li>
                    <li><a href="#" className="nav-link px-2 text-white">FAQs</a></li>
                    <li><a href="#" className="nav-link px-2 text-white">About</a></li>
                </ul>
            </div>
        </footer>
    )
}

export default Footer;