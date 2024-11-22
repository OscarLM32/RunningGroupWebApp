import React from 'react';
import './Login.css'; // For styling
import { Link } from 'react-router-dom';

function Login(){
    return (
        <div className="auth-page d-flex rounded m-1">
            {/* Left Side: Image */}
            <div className="auth-image-container rounded">
                <img className='auth-image rounded' src='../../../images/Login-bg.jpg' />
                <div className="auth-image-overlay"></div>
                <div className='auth-image-text'>
                    <h1 className="text-light">Welcome Back!</h1>
                    <p className="text-light text-secondary fs-4">Login to continue your journey.</p>
                </div>
            </div>

            {/* Right Side: Login Form */}
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
                        Don't have an account? <Link to="/register">Register</Link>
                    </p>
                </div>
            </div>
        </div>
    );
}

export default Login;