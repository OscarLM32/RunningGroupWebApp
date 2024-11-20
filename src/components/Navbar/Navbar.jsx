
export default function Navbar() {
    return (
        <header className="p-2 text-bg-dark rounded-2 m-1">
            <div className="container">
                <div className="d-flex flex-wrap align-items-center justify-content-between">
                    <a href="/" className="d-flex align-items-center mb-2 mb-lg-0 text-white text-decoration-none">
                        <svg className="bi me-2" width="40" height="32" role="img" aria-label="Bootstrap">
                            <use xlink:href="#bootstrap"></use>
                        </svg>
                    </a>

                    <ul className="nav col-12 col-lg-auto me-lg-auto mb-2 justify-content-center mb-md-0 gap-3">
                        <li><a href="#" className="nav-link px-2 text-secondary">Home</a></li>
                        <li><a href="#" className="nav-link px-2 text-white">Features</a></li>
                        <li><a href="#" className="nav-link px-2 text-white">Pricing</a></li>
                        <li><a href="#" className="nav-link px-2 text-white">FAQs</a></li>
                        <li><a href="#" className="nav-link px-2 text-white">About</a></li>
                    </ul>

                    <form className="col-12 col-lg-auto mb-3 mb-lg-0 me-lg-3" role="search">
                        <input type="search" className="form-control form-control-dark text-bg-dark rounded-2" placeholder="Search..." aria-label="Search" />
                    </form>

                    <div className="text-end">
                        <button type="button" className="btn btn-outline-light me-2 rounded-2">Login</button>
                        <button type="button" className="btn btn-warning rounded-2">Sign-up</button>
                    </div>
                </div>
            </div>
        </header>
    )
}