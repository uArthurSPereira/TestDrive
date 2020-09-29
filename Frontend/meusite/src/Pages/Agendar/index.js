import React, { useState } from 'react';
import { ToastContainer } from 'react-toastify';

import './agendar.css';

import TestDriveApi from '../../Services/TestDriveApi'

const api = new TestDriveApi();

export default function Agendar() {

    const [data, setData] = useState('')
    const [hora, setHora] = useState('')
    const [login, setLogin] = useState('')
    const [carro, setCarro] = useState('')

    const salvarClick = async () => {
        const resp = await
            api.agendar({
                Data: data,
                Hora: hora,
                IdLogin: login,
                IdCarro: carro
            })
    }

    return(
        <div className="agendar">
            <div className="agendar-container">
                <h1 className="agendar-title"><i>Agendar Test Drive</i></h1>

                <p><i>Agende agora se test.</i></p>

                <div className="agendar-input">
                    <label><i>Data do Test</i></label>
                    <input type="date"
                        value={data}
                        onChange={e => setData(e.target.value)}
                    />
                </div>

                <div className="agendar-input">
                    <input type="text" placeholder="Hora"
                        value={hora}
                        onChange={e => setHora(e.target.value)}    
                    />
                </div>

                <div className="agendar-input">
                    <input type="number" placeholder="Login"
                        value={login}
                        onChange={e => setLogin(e.target.value)}
                    />
                </div>

                <div className="agendar-input">
                    <input type="number" placeholder="Carro"
                        value={carro}
                        onChange={e => setCarro(e.target.value)}
                    />
                </div>

                <div className="agendar-button">
                    <button onClick={salvarClick}>Agendar</button>
                </div>
            </div>
        </div>
    )
}