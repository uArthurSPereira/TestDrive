import React, { useState } from 'react';

import TestDriveApi from '../../Services/TestDriveApi'

import LoadingBar from 'react-top-loading-bar'

const api = new TestDriveApi();

export default function Consultar() {

    const [registros, setRegistros] = useState([])

    const consultarClick = async () => {
        const tds = await api.consultar()
        setRegistros([...tds])
    }

    return(
        <div>

            <h1>Consultar Agendamento</h1>

            <button onClick={consultarClick}>
                Consultar
            </button>

            <div>
                <table className="table">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Cliente</th>
                            <th>Funcionario</th>
                            <th>Marca</th>
                            <th>Modelo</th>
                            <th>Data</th>
                        </tr>
                    </thead>

                    <tbody>
                        {registros.map(item =>
                            <tr key={item.IdAgendamento}>
                                <th># {item.IdAgendamento}</th>
                                <td>{item.NmCliente}</td>
                                <td>{item.NmFuncionario}</td>
                                <td>{item.Marca}</td>
                                <td>{item.Modelo}</td>
                                <td>{new Date(item.Agendamento + 'Z' ).toLocaleDateString}</td>
                        </tr>
                        )}
                    </tbody>
                </table>
            </div>
        </div>
    )
}