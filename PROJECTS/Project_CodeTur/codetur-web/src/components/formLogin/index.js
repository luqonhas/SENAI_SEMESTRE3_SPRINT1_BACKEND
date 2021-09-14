// Libs
import React, { useState } from 'react';
import axios from 'axios';

// Styles
import { Form, Button } from 'react-bootstrap'



const FormLogin = () => {
    const [email, setEmail] = useState('');
    const [senha, setSenha] = useState('');
    const [mensagem, setMensagem] = useState('');
    const [isLoading, setIsLoading] = useState(false);


    const Login = (e) => {
        e.preventDefault();

        setMensagem('');
        setIsLoading(true);

        axios.post('https://localhost:5001/v1/account/signin', {
            email : email,
            senha : senha
        })

        .then(response => {
            alert('logado com sucesso!');
        })

        .catch(() => {
            setMensagem('E-mail e/ou senha inválido(s)! Tente novamente.');
            setIsLoading(false);
        })

    }



    return (
        <>
            <Form onSubmit={Login} className="form formLogin" >

                <h2>Login</h2>

                <Form.Group className="mb-3" controlId="formBasicEmail">
                    <Form.Label>Email</Form.Label>

                    <Form.Control value={email} onChange={(e) => setEmail(e.target.value)} type="email" placeholder="Digite seu e-mail" />
                </Form.Group>

                <Form.Group className="mb-3" controlId="formBasicPassword">
                    <Form.Label>Senha</Form.Label>
                    <Form.Control value={senha} onChange={(e) => setSenha(e.target.value)} type="password" placeholder="Senha" />
                </Form.Group>

                {
                    isLoading === true ? (
                        <Button variant="primary" type="submit" disabled>
                            Entrando...
                        </Button>
                    ) : (
                        <Button variant="primary" type="submit" disable={email === '' || senha === '' ? 'none' : ''}>
                            Entrar
                        </Button>
                    )
                }
                <p>
                    <a href="/">Esqueci minha senha</a>
                </p>

                <span>{mensagem}</span>
            </Form>
        </>
    )
}

export default FormLogin;