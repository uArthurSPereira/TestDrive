import React, { useState } from 'react';
import { ToastContainer } from 'react-toastify';

import TestDriveApi from '../../Services/TestDriveApi'

const api = new TestDriveApi();

export default function Agendar() {
    const [cliente, setCliente] = useState('')
    const [funcionario, setFuncionario] = useState('')
    const [marca, setMarca] = useState('')
    const [modelo, setModelo] = useState('')
    const [agendamento, setAgendamento] = useState('')
    const request = {
        cliente,
        funcionario,
        marca,
        modelo,
        agendamento
    };

    const salvarClick = async () => {
        const resp = await
            api.cadastrar(request); 
        return resp; 
    }

    return(
        <div>
            <h1>Agendar Test Drive</h1>

            <div>
                <input type="text" placeholder="Cliente"
                       value={cliente}
                       onChange={e => setCliente(e.target.value)}
                />
            </div>

            <div>
                 <input type="text" placeholder="Funcionario"
                        value={funcionario}
                        onChange={e => setFuncionario(e.target.value)}
                />
            </div>

            <div>
                <input type="text" placeholder="Marca"
                        value={marca}
                        onChange={e => setMarca(e.target.value)}    
                />
            </div>

            <div>
                <input type="text" placeholder="Modelo"
                        value={modelo}
                        onChange={e => setModelo(e.target.value)}
                />
            </div>

            <div>
                <label>Data do Test</label>
                <input type="date" 
                        value={agendamento}
                        onChange={e => setAgendamento(e.target.value)}
                />
            </div>

            <div>
                <button onClick={salvarClick}>Agendar</button>
            </div>

        </div>
    )
}