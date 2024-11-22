import React from 'react';
import './SharedAuth.css'; // For styling
import { Link } from 'react-router-dom';
import AuthImage from './Image/AuthImage';

function Login(){
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
                    <form>
                        <div className="mb-3">
                            <label htmlFor="email" className="form-label">Email</label>
                            <input
                                type="email"
                                className="form-control"
                                id="email"
                                placeholder="Enter your email"
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
                                required
                            />
                        </div>
                        <button type="submit" className="btn btn-primary w-100">Login</button>
                    </form>
                    <p className="mt-3 text-center">
                        Don't have an account? <Link to="/auth/register">Register</Link>
                    </p>
                </div>
            </div>
        </div>
    );
}

export default Login;