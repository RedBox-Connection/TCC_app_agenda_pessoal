import React, {useState} from 'react';
import { useDrag } from 'react-dnd';

import Modal from '../Modal';

import { CardContent, Color, Content } from './styles';

export default function Card() {

    const [{ isDragging }, dragRef ] = useDrag({
        item: {type: 'CARD'},
        collect: monitor => ({
            idDragging: monitor.isDragging(),
        }),
    });

    const [isModalVisible,setIsModalVisible] = useState(false);

    return (
        <CardContent ref={dragRef}>

            <button onClick={() =>setIsModalVisible(true)}>
                <Color />
                <Content>
                    <h3>Título</h3>
                    <h1>18:00</h1>
                </Content>
            </button>

            {isModalVisible ? <Modal onClose={() => setIsModalVisible(false)}/> : null}

        </CardContent>
    );
}
