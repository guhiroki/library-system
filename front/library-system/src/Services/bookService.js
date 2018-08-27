import API from '../Services/api';

export default module.exports = {
    get() {
        return API.get('Book');
    },
    post(book) {
        return API.post('Book', book);
    },
    delete(book) {
        return API.delete('Book/' + book);
    },
};