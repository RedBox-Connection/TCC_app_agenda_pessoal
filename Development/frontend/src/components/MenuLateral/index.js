import React from 'react';
import { Link } from 'react-router-dom';

import { Journal, CheckCircle, Alarm, Sliders, Calendar2Week } from 'react-bootstrap-icons';

import { Container, ItemLink } from './styles';


function MenuLateral(props) {

    const quadroType = props.quadroType;
    const idTipo = props.idTipo;
    const nomeQuadro = props.nomeQuadro;   

    if(quadroType === 'Time') {
        return (
            <Container>
                <ItemLink>
                    <Journal />
                    <Link to="/Inicial/Agenda">Agenda</Link>
                </ItemLink>
                <ItemLink>
                    <CheckCircle />
                    <Link to="/Inicial/Feitos">Feitos</Link>
                </ItemLink>
                <ItemLink>
                    <Alarm />
                    <Link to="/Inicial/Atrasados">Atrasados</Link>
                </ItemLink>
                <ItemLink>
                    <Sliders />
                    <Link to={
                        {
                            pathname: "/Inicial/ConfigurarTime",
                            state: {
                                idTipo,
                                nomeQuadro
                            }
                        }
                    }>Configurações</Link>
                </ItemLink>
            </Container>
        );   
    } else if(quadroType === 'Quadro') {
        return (
            <Container>
                <ItemLink>
                    <Journal />
                    <Link to="/Inicial/Agenda">Agenda</Link>
                </ItemLink>
                <ItemLink>
                    <CheckCircle />
                    <Link to="/Inicial/Feitos">Feitos</Link>
                </ItemLink>
                <ItemLink>
                    <Alarm />
                    <Link to="/Inicial/Atrasados">Atrasados</Link>
                </ItemLink>
                <ItemLink>
                    <Calendar2Week />
                    <Link to={
                        {
                            pathname: "/Inicial/InfoQuadro",
                            state: {
                                idTipo,
                                nomeQuadro
                            }
                        }
                    }>Configurações</Link>
                </ItemLink>
            </Container>
        );
    } else {
        return (
            <Container>
                <ItemLink>
                    <Journal />
                    <Link to="/Inicial/Agenda">Agenda</Link>
                </ItemLink>
                <ItemLink>
                    <CheckCircle />
                    <Link to="/Inicial/Feitos">Feitos</Link>
                </ItemLink>
                <ItemLink>
                    <Alarm />
                    <Link to="/Inicial/Atrasados">Atrasados</Link>
                </ItemLink>
            </Container>
        );
    }
}

export default MenuLateral;