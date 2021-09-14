import React from 'react'
import { Container, Navbar } from 'react-bootstrap';

export const Header = () => {
    return(
        <>
            <Navbar bg="light">
                <Container>
                    <Navbar.Brand href="#home" className="logo">CodeTur</Navbar.Brand>
                </Container>
            </Navbar>
        </>
    )
}

export default Header;