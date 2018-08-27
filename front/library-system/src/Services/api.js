import axios from 'axios';

export default axios.create({
    baseURL: 'http://localhost:56864/api/',
    timeout: 15000
  })
  