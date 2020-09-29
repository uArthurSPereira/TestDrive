import React, { useState } from 'react';

import TestDriveApi from '../../Services/TestDriveApi';

import './login.css';

const api = new TestDriveApi();

export default function Agendar() {

    return(
        <div className="login">
            <div className="login-container">

                <h1 className="login-title">
                    <i>Login</i>
                </h1>

                <p>
                    <i>Realize o login para agendar o seu test-drive.</i>
                </p>

                <div className="login-input">
                    <input type="text" placeholder="Login"
                />
                </div>

                <div className="login-input">
                    <input type="password" placeholder="Password"
                />
                </div>

                <div className="login-button">
                    <button>Logar</button>
                </div>

            </div>
        </div>
    )
}