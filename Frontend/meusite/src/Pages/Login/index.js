import React, { useState }  from "react";

//import api
import TestDriveApi from '../../services/TestDriveApi';
import { useHistory } from "react-router-dom";

const api = new TestDriveApi();

export default function Inicial() {

  const navegation = useHistory();

  const [email, setEmail] = useState('');
  const [senha, setSenha] = useState('');
  const loginRequest = { email, senha };

  const loginClick = async () => {
    try {
      const resp = await api.Login(loginRequest);
      console.log(resp);
      if(resp.permissao === 'cliente') {
        navegation.push({
          pathname: '/Agendar',
          state: {
             nome: resp.nome,
             permissao: resp.permissao,
             login: resp.login
          }
        });
      }
      // else esperando pela parte do funcionario

      return resp;
    } catch(e) {
      console.log(e.response.data.message);
    }
  }

  return (
    <div>
      <h1> Test Drive </h1>
      <div>
        Login
        <div>
          <input type="email" placeholder="E-mail" onChange={(e) => {setEmail(e.target.value)}}/>
          <input type="password" placeholder="Senha" onChange={(e) => {setSenha(e.target.value)}}/>
        </div>
        <button onClick={loginClick}>Entrar</button>
      </div>
    </div>
  );
}
