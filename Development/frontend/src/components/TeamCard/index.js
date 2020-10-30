import React, {useState} from 'react';

import TeamModal from '../TeamModal';

import { CardContent, Color, Content } from './styles';

export default function TeamCard() {

    const [isModalVisible,setIsModalVisible] = useState(false);

    return (
        <CardContent>

            <button onClick={() =>setIsModalVisible(true)}>
                <Color />
                <Content>
                    <h3>Título</h3>
                    <h1>18:00</h1>
                </Content>
            </button>

            {isModalVisible ? <TeamModal onClose={() => setIsModalVisible(false)}/> : null}

        </CardContent>
    );
}