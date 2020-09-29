import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';

import './agendar.css';

import TestDriveApi from '../../Services/TestDriveApi'

const api = new TestDriveApi();

export default function Agendar(props) {

    const nome = props.location.state.nome;
    const permissao = props.location.state.permissao;
    const login = props.location.state.login;

    const [carros, setCarros] = useState([]);

    const buscarCarro = async () => {
        try {
            const resp = await api.BuscarCarros();
            setCarros([...resp])
        } 
        catch (error) {
            console.log(e.response.data.mensage);
        }
    }

    useEffect(() => {
        buscarCarro();
    }, []);

    const [idCarro, setIdCarro] = useState(1);
    const [data, setData] = useState('');
    const [hora, setHora] = useState('08:00');
    const idLogin = props.location.state.login;
    const agendarRequest = {
        data,
        hora,
        idCarro,
        idLogin
    }

    const agendarClick = async () => {
        try {
            console.log(agendarRequest);
            const resp = await api.CadastrarAgendamento(agendarRequest)
            console.log(resp)
            return resp;
        } 
        catch (e) {
            console.log(e.response.data.mensage);
        }
    }

    let horarios = [
        "08:00",
        "08:30",
        "09:00",
        "09:30",
        "10:00",
        "10:30",
        "11:00",
        "11:30",
        "13:00",
        "13:30",
        "14:00",
        "14:30",
        "15:00",
        "15:30",
        "16:00",
        "16:30",
        "17:00"
      ];

    return(
        <div>
            <h1>Agende um Test Drive Já!</h1>
            <div>
                <div>
                    <h3>Escolha o carro</h3>
                    <select onChange={(e) => {setIdCarro(Number(e.target.value))}}>
                        {carros.map(carro =>
                        <option value={carro.idCarro} key={carro.idCarro}>{carro.carroPlaca}</option>
                        )}
                    </select>
                </div>
                <div>
                    <h3>Escolha a data</h3>
                    <input id="date" type="date" onChange={(e) => {setData(e.target.value)}}/>
                        <select id="hora" onChange={(e) => {setHora(e.target.value)}}>
                            {horarios.map(hora => (
                            <option value={hora} key={hora}>{hora}</option>
                            ))}
                        </select>
                </div>
            </div>
            <button onClick={agendarClick}>Agendar</button>
            <Link to={{
                pathname: '/meus-test-drives',
                state: { nome, permissao, login }
                }}>
                    Meus Test-Drives
            </Link>
        </div>
    )
}