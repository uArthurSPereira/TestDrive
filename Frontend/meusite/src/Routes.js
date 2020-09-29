import React from 'react';
import { BrowserRouter, Switch, Route } from 'react-router-dom';

import Login from './Pages/Login'
import Consultar from './Pages/ConsultarAgendamento'
import Agendar from './Pages/Agendar'

function Routes() {  
    return(
        <BrowserRouter>
            <Switch>
                <Route path="/" exact={true} component={Login} />
                <Route path="/meu-test" component={Consultar} />
                <Route path="/agendar" component={Agendar} />
            </Switch>
        </BrowserRouter>
    );
}

export default Routes;