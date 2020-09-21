import axios from 'axios'

const api = axios.create({
    baseURL: 'http://localhost:5000'
})

export default class TestDriveApi {

    async cadastrar(td) {
        const resp = await api.post('/testdrive/Agendar', td);
        return resp;
    }

    async consultar(clienteId) {
        const resp = await api.get(`/testdrive/${clienteId}`);
        return resp.data;
    }
}