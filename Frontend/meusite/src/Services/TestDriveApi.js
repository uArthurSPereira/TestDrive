import axios from 'axios'

const api = axios.create({
    baseURL: 'http://localhost:5000'
})

export default class TestDriveApi {

    async login(td) {
        const resp = await api.post('/testdrive/Login', td);
        return resp;
    }

    async agendar(td) {
        const resp = await api.post('/testdrive/Agendar', td);
        return resp;
    }

    async consultar(id) {
        const resp = await api.get(`/testdrive/${id}`);
        return resp.data;
    }

}