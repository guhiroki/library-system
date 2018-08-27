import React from 'react';
import API from '../Services/api';
import { Table, Row, Col } from 'react-bootstrap';

class BookListComponent extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            booksTableItems: []
        }

        this.buildAndOrderTable = this.buildAndOrderTable.bind(this);

        this.buildAndOrderTable()
    }
    buildAndOrderTable() {
        let promise = API.get('Book');
        promise.then(result => {
            let books = result.data.sort((book1, book2) => {
                if (book1 > book2)
                    return 1;
                if (book1 < book2)
                    return -1;

                return 0;
            });

            let booksTableItems = []

            books.forEach(element => {
                booksTableItems.push(
                    <tr key={element.BookId}>
                        <td>
                            {element.BookId}
                        </td>
                        <td>
                            {element.Name}
                        </td>
                        <td>
                            {element.Description}
                        </td>
                        <td>
                            {element.Edition}
                        </td>
                        <td>
                            {element.PublicationDate}
                        </td>
                        <td>
                            {element.WriterName}
                        </td>
                        <td>
                            <input type="button" value="Add" className="btn" onClick={() => this.props.update(element)} />
                            <input type="button" value="Delete" className="btn" onClick={() => this.props.delete(element)} />
                        </td>
                    </tr>
                );
            });

            this.setState({ booksTableItems });
        });
    }
    render() {
        return (
            <div className="container">
                <Row>
                    <Col>
                        <Table striped bordered condensed hover>
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>Name</th>
                                    <th>Description</th>
                                    <th>Edition</th>
                                    <th>Publication Date</th>
                                    <th>Writer Name</th>
                                </tr>
                            </thead>
                            <tbody>
                                {this.state.booksTableItems ? this.state.booksTableItems : ''}
                            </tbody>
                        </Table>
                    </Col>
                </Row>
            </div>
        )
    }
}

export default BookListComponent;