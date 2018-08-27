import React from 'react';
import { Row, Col, FormControl } from 'react-bootstrap';

class FormBook extends React.Component {
    render() {
        let book = this.props.book;
        let handleChange = this.props.handleChange;
        return (
            this.props.showForm &&
            <div className="container">
                <Row>
                    <Col md={12}>
                        <h1>Name</h1>
                        <FormControl name="Name" placeholder="Name" value={book.Name} onChange={(e)=> {handleChange(e)}} />
                    </Col>
                    <Col md={5}>
                        <h1>Edition</h1>
                        <FormControl name="Edition" placeholder="Edition" value={book.Edition} onChange={(e)=> handleChange(e)} />
                    </Col>
                    <Col md={7}>
                        <h1>Author</h1>
                        <FormControl name="WriterName" placeholder="Writer name" value={book.WriterName} onChange={(e)=> handleChange(e)} />
                    </Col>
                    <Col md={12}>
                        <h1>Description</h1>
                        <FormControl name="Description" placeholder="Decription" value={book.Description} onChange={(e)=> handleChange(e)} />
                    </Col>
                    <Col md={3}>
                        <h1>Publication date</h1>
                        <FormControl name="PublicationDate" placeholder="Publication date" value={book.PublicationDate} onChange={(e)=> handleChange(e)} />
                    </Col>
                    <Col md={12}>
                        <h1>Publication date</h1>
                        <input type="button" value="Save" onClick={() => this.props.save(book)} />
                    </Col>
                </Row>
            </div>
        )
    }
}
export default FormBook;