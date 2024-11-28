import React, { useState } from 'react';
import './SharedAuth.css'; // For styling
import { Link } from 'react-router-dom';
import AuthImage from './Image/AuthImage';
import { useLogin } from '../../hooks/useLogin';

function Login(){
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    // Destructure the login hook to access the mutation and state
    const { mutate: loginRequest, isLoading, isError, error } = useLogin();

    const handleSubmit = (event) => {
        event.preventDefault();

        loginRequest({ email, password });
    };

    //#region JSX 
    return (
        <div className="auth-page d-flex rounded m-1">
            <div className="auth-image-container rounded">
                <AuthImage 
                    imageName = "Login-bg.jpg"
                    mainText = "Welcome Back!"
                    secondaryText = "Login to continue your journey"
                />
            </div>

            <div className='auth-content bg-dark'>
                <div className="auth-form-container rounded">
                    <h2 className="mb-4 text-center">Login</h2>
                    <form onSubmit={handleSubmit}>
                        <div className="mb-3">
                            <label htmlFor="email" className="form-label">Email</label>
                            <input
                                type="email"
                                className="form-control"
                                id="email"
                                placeholder="Enter your email"
                                value={email}
                                onChange={(e) => setEmail(e.target.value)}
                                required
                            />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="password" className="form-label">Password</label>
                            <input
                                type="password"
                                className="form-control"
                                id="password"
                                placeholder="Enter your password"
                                value={password}
                                onChange={(e) => setPassword(e.target.value)}
                                required
                            />
                        </div>
                        <button type="submit" className="btn btn-primary w-100" disabled={isLoading}>Login</button>

                        {isError && (
                            <p className="text-danger mt-2 text-center">
                                {error.message}
                            </p>
                        )}
                    </form>
                    <p className="mt-3 text-center">
                        Don't have an account? <Link to="/auth/register">Register</Link>
                    </p>
                </div>
            </div>
        </div>
    );
    //#endregion
}

export default Login;