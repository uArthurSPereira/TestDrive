import React, { useState, useEffect } from "react";

import TestDriveApi from '../../services/TestDriveApi';

const api = new TestDriveApi();

export default function Consultar(props) {

  const [agendamentos, setAgendamentos] = useState([]);
  const idLogin = props.location.state.login;

  const consultarClick = async () => {
    try {
      const resp = await api.ConsultarAgendamento(idLogin);
      setAgendamentos([...resp]);
      return resp;
    } catch (e) {
      console.log(e);
    }
  }

  useEffect(() => {
    console.log(props);
    consultarClick();
  }, []);

  return (
    <div>
      <h1>Meus Test Drives</h1>
      <table>
        <thead>
          <tr>
            <th>Carro</th>
            <th>Data/Hora</th>
            <th>Funcionario</th>
            <th>Status</th>
            <th>Estrelas</th>
            <th>Feeback</th>
          </tr>
        </thead>
        <tbody>
          {agendamentos.map(agendamento =>
            <tr key={agendamento.carro}>
              <td>{agendamento.carro}</td>
              <td>{agendamento.dataHora}</td>
              <td>{agendamento.funcionario}</td>
              <td>{agendamento.status}</td>
              <td>{agendamento.estrela}</td>
              <td>{agendamento.feedback}</td>
            </tr>
          )}
        </tbody>
      </table>
    </div>
  );
}
