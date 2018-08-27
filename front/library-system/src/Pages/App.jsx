import React, { Component } from 'react';
import { Button, Row, Col } from 'react-bootstrap';
import './App.css';
import FormBook from '../Components/FormBook';
import BookList from '../Components/BookList'; import api from '../Services/api';
import axios from 'axios';


class App extends Component {
  constructor() {
    super()

    this.state = {
      book: {
        Name: '',
        Edition: '',
        WriterName: '',
        Description: '',
        PublicationDate: ''
      },
      shouldShowForm: false,
      showBooks: false
    }

    this.showForm = this.showForm.bind(this);
    this.handleChange = this.handleChange.bind(this);
    this.updateBook = this.updateBook.bind(this);
    this.deleteBook = this.deleteBook.bind(this);
  }
  showForm() {
    this.setState({ shouldShowForm: !this.state.shouldShowForm });
  }
  handleChange(event) {
    let name = event.target.name;
    let value = event.target.value;
    let book = JSON.parse(JSON.stringify(this.state.book));
    book[name] = value
    this.setState({ book });
  }
  updateBook(book) {
    this.setState({ book, shouldShowForm: true })
  }
  save(book) {
    axios({
      method: 'post',
      url: 'http://localhost:56864/api/Book',
      data: { value: book }
    }).then(res => {
      alert('Salvo com sucesso');
    });
  }
  deleteBook(book) {
    api.delete('Book', JSON.stringify({ value: book })).then(res => {
      alert('Deletado com sucesso');
    });
  }
  render() {
    return (
      <div className="App">
        <header className="App-header">
          <h1 className="App-title">Book system</h1>
        </header>
        <Row>
          <Col md={3}>
            <Button onClick={this.showForm} bsSize="large" >Add new</Button>
          </Col>
        </Row>
        {!this.shouldShowForm && <BookList update={this.updateBook} delete={this.deleteBook} />}
        <FormBook book={this.state.book} handleChange={this.handleChange} showForm={this.state.shouldShowForm} save={this.save} />
      </div>
    );
  }
}
export default App;
