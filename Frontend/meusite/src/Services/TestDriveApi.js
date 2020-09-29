import axios from 'axios'

const api = axios.create({
    baseURL: 'http://localhost:5000/testdrive'
})

export default class TestDriveApi {

    async Login(loginRequest) {
        const resp = await api.post("", loginRequest);
        return resp.data;
    }

    async BuscarCarros() {
        const resp = await api.get("/consultar/carro");
        return resp.data;
    }

    async CadastrarAgendamento(agendamentoRequest) {
        const resp = await api.post('/testdrive/Agendar', agendamentoRequest);
        return resp.data;
    }

    async consultar(id) {
        const resp = await api.get(`/testdrive/${id}`);
        return resp.data;
    }

}