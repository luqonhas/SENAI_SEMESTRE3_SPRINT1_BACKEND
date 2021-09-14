import React from 'react'
import { Container, Row, Col } from 'react-bootstrap';
import Footer from '../../components/footer';
import Header from '../../components/header';
import FormLogin from '../../components/formLogin';
import FormCadastro from '../../components/formCadastro';

export const Inicio = () => {

    return(
        <>
            <Header />
            
            <Container>
                <Row>
                    <Col>
                        <FormLogin />
                    </Col>

                    <Col>
                        <FormCadastro />
                    </Col>
                </Row>
            </Container>

            <Footer />
        </>
    )
}

export default Inicio;