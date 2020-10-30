import React from 'react';

import Card from '../../../components/Card';
import TeamCard from '../../../components/TeamCard';

import { CardContainer, Container } from './styles';

export default function Agenda() {

    return(  
        <Container>
         <CardContainer>
          <Card />
          <TeamCard />
        </CardContainer>
        </Container>
    )
}