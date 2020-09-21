import React from 'react';
import { BrowserRouter, Switch, Route } from 'react-router-dom';

import Inicial from './Pages/Inicial'
import ConsultarAgendamento from './Pages/ConsultarAgendamento'
import Agendar from './Pages/Agendar'

function Routes() {  
    return(
        <BrowserRouter>
            <Switch>
                <Route path="/" exact={true} component={Inicial} />
                <Route path="/ConsultarAgendamento" component={ConsultarAgendamento} />
                <Route path="/Agendar" component={Agendar} />
            </Switch>
        </BrowserRouter>
    );
}

export default Routes;