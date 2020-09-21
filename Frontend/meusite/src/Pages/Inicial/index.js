import React from 'react';
import { Link } from 'react-router-dom';

import "./inicial.css";

export default function Inicial() {

    return(
        <div className="Inicial">
            <h1>Test Drive</h1>

            <div>
                <h3> <Link to="/Agendar"> Agendar </Link> </h3>
            </div>

            <div>
                <h3> <Link to="/ConsultarAgendamento"> Consultar Agendamento </Link> </h3>
            </div>
        </div>
    )
}