import axios from 'axios'
import React, {Component, useEffect, useState } from 'react'


import { Form, Button } from 'react-bootstrap'

export const FormCadastro = () => {

    const [nome, setNome] = useState('')
    const [email, setEmail] = useState('')
    const [senha, setSenha] = useState('')
    const [tipoUsuario, setTipoUsuario] = useState(2)

    const Cadastrar = (event) => {

        event.preventDefault();

        axios.post('http://localhost:5000/v1/account/signup', {
            nome: nome,
            email: email,
            senha: senha,
            tipoUsuario: parseInt(tipoUsuario)
        })

        .then(resposta => {
            console.log(resposta.data);
        })

        .then(erro => console.log(erro))
    }
    
    
    const buscarUsuarios = () => {
        axios('http://localhost:5000/v1/account')

        .then(resposta => {
            console.log(resposta.data)
        })

        .catch(erro => console.log(erro))
    }

    useEffect(() => buscarUsuarios(), [])

    return(
        <>
        <Form className="form formCadastro" >

            <h2>Cadastro</h2>

            <Form.Group className="mb-3" controlId="formBasicNome">
                <Form.Label>Nome</Form.Label>

                <Form.Control type="Text" placeholder="Digite seu nome" value={nome} onChange={ (event) => setNome(event.target.value) } />
            </Form.Group>

            <Form.Group className="mb-3" controlId="formBasicEmail">
                <Form.Label>Email</Form.Label>

                <Form.Control type="email" placeholder="Digite seu e-mail" value={email} onChange={ (event) => setEmail(event.target.value) } />
            </Form.Group>

            <Form.Group className="mb-3" controlId="formBasicTipoUsuario">
                <Form.Label>Tipo de Usuário</Form.Label>

                <Form.Select onChange={(event) => setTipoUsuario(event.target.value)} >
                    <option value="2">Comum</option>
                    <option value="1">Administrador</option>
                </Form.Select>
            </Form.Group>

            <Form.Group className="mb-3" controlId="formBasicPassword">
                <Form.Label>Senha</Form.Label>
                <Form.Control type="password" placeholder="Digite uma senha" value={senha} onChange={ (event) => setSenha(event.target.value) } />
            </Form.Group>

            <Button variant="primary" type="submit" onClick={Cadastrar}>
                Cadastrar
            </Button>
        </Form>
        </>
    )
}

export default FormCadastro;