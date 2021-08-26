import axios, { AxiosResponse } from "axios"
import { ICliente } from "../Models/ICliente";


axios.defaults.baseURL = 'https://localhost:44322/api'


const responseBody = (response: AxiosResponse) => response.data;

const request = {
        get:(url: string) => axios.get(url).then(responseBody),
        post:(url: string, body:{}) => axios.post(url, body).then(responseBody),
        put:(url: string, body:{}) => axios.put(url, body).then(responseBody),
        delete:(url: string) => axios.delete(url).then(responseBody),
}


const Cliente = {
    list:() : Promise<ICliente[]>=> request.get('/cliente/list'),
    create: (cliente: ICliente) => request.post('/cliente/create', cliente),
}

export default {
    Cliente,
}


