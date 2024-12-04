import React, { useState } from 'react';
import AuthImage from "./Image/AuthImage";
import "./SharedAuth.css"
import { useRegister } from "../../hooks/useRegister";

function Register() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [passwordConfirmation, setPasswordConfirmation] = useState('');

    const { mutate: registerRequest, isLoading, isError, error} = useRegister();

    const handleSubmit = (event) => {
        event.preventDefault();

        registerRequest({email, password, passwordConfirmation});
    }


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
                    <form className="form-signin" onSubmit={handleSubmit}>
                        <h1 className="h3 mb-3 font-weight-normal text-center">Sign Up</h1>

                        <label htmlFor="email" className="sr-only">Email address</label>
                        <input
                            name="email"
                            type="email"
                            id="inputEmail"
                            className="form-control mb-2"
                            placeholder="Email address"
                            value={email}
                            onChange={(e) => {setEmail(e.target.value)}}
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
                            value={password}
                            onChange={(e) => {setPassword(e.target.value)}}
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
                            value={passwordConfirmation}
                            onChange={(e) => {setPasswordConfirmation(e.target.value)}}
                            required
                        />
                        <span className="text-danger"></span>

                        <button className="btn btn-lg btn-primary btn-block w-100" type="submit" disabled={isLoading}>
                            Sign up
                        </button>

                        {isError && (
                            <p className="text-danger mt-2 text-center">
                                {error.message}
                            </p>
                        )}

                        <p className="mt-5 mb-3 text-muted text-center">&copy; 2024-2025</p>
                    </form>
                </div>
            </div>
        </div>
    );
}

export default Register;