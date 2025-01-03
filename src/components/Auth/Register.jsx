import AuthImage from "./Image/AuthImage";
import "./SharedAuth.css"

function Register() {
    return (
        <div className="auth-page d-flex rounded m-1">

            <div className="auth-image-container rounded">
                <AuthImage 
                    imageName="Register-bg.jpg"
                    mainText="Welcome!"
                    secondaryText="Register to continue begin journey"
                />
            </div>

            <div className='auth-content bg-dark'>
                <div className="auth-form-container rounded">
                    <form className="form-signin">
                        <h1 className="h3 mb-3 font-weight-normal text-center">Sign Up</h1>

                        <label htmlFor="email" className="sr-only">Email address</label>
                        <input
                            name="email"
                            type="email"
                            id="inputEmail"
                            className="form-control mb-2"
                            placeholder="Email address"
                            required
                            autoFocus
                        />
                        <span className="text-danger"></span>

                        <label htmlFor="password" className="sr-only">Password</label>
                        <input
                            name="password"
                            type="password"
                            id="inputPassword"
                            className="form-control mb-3"
                            placeholder="Password"
                            required
                        />
                        <span className="text-danger"></span>

                        <label htmlFor="passwordConfirmation" className="sr-only">Repeat Password</label>
                        <input
                            name="passwordConfirmation"
                            type="password"
                            id="inputPasswordConfirmation"
                            className="form-control mb-3"
                            placeholder="Repeat Password"
                            required
                        />
                        <span className="text-danger"></span>

                        <button className="btn btn-lg btn-primary btn-block w-100" type="submit">
                            Sign up
                        </button>

                        <p className="mt-5 mb-3 text-muted text-center">&copy; 2024-2025</p>
                    </form>
                </div>
            </div>
        </div>
    );
}

export default Register;